using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;
using RestSharp;
using projectIS.Model;
using Application = projectIS.Model.Application;
using Module = projectIS.Model.Module;
using System.Xml;
using System.Text.RegularExpressions;

namespace MaltApp
{
    public partial class SOMIOD : Form
    {
        string url = "https://localhost:44356/api/somiod/";

        public SOMIOD()
        {
            InitializeComponent();
        }

        private void SOMIOD_Load(object sender, EventArgs e)
        {

            dataGridViewModules.Columns.Clear();

            dataGridViewModules.Columns.Add("mid", "ID");
            dataGridViewModules.Columns.Add("mparent", "Parent");
            dataGridViewModules.Columns.Add("mname", "Name");
            dataGridViewModules.Columns.Add("created", "Careated");

        }


        #region Aux Functions

        //inicio metodo para tirar "lixo" do xml
        public static string RemoveAllNamespaces(string xmlDocument) //colocar no tipo para puder remover namespaces
        {
            XElement xmlDocumentWithoutNs = RemoveAllNamespaces(XElement.Parse(xmlDocument)); //esta no tipo que precisamos ja podemos fazer alteracao de xml vamos para metodo de baixo (core function recursio)

            return xmlDocumentWithoutNs.ToString();
        }

        //metodo para tirar "lixo" do xml
        private static XElement RemoveAllNamespaces(XElement xmlDocument) //remover namespaces
        {
            if (!xmlDocument.HasElements) //se nao tiver elementos filho entra
            {
                XElement xElement = new XElement(xmlDocument.Name.LocalName);
                xElement.Value = xmlDocument.Value;

                foreach (XAttribute attribute in xmlDocument.Attributes())
                    xElement.Add(attribute);

                return xElement;
            }
            return new XElement(xmlDocument.Name.LocalName, xmlDocument.Elements().Select(el => RemoveAllNamespaces(el))); //recursivo .... 0> (lambda expression(=>) method call para o parametro el ...)
        }

        #endregion


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private async void btnGetAllApp_Click(object sender, EventArgs e)
        {
           
            string initialBtnText = btnGetAllApp.Text;
            btnGetAllApp.Enabled = false;
            btnGetAllApp.Text = "Loading...";

            var client = new RestClient(url);

            var request = new RestRequest("");
            request.AddHeader("Accept", "application/xml");

            var response = await client.ExecuteGetAsync(request);

            if (!response.IsSuccessful)
            {
                btnGetAllApp.Enabled = true;
                btnGetAllApp.Text = initialBtnText;

                MessageBox.Show("Oops! Something went wrong while fetching data.");
                return;
            }

            //Clear Gridview current data
            dataGridViewApp.Rows.Clear();
            dataGridViewApp.Refresh();


            var result = XElement.Parse(response.Content).Value; //se nao fizer isto aparece o microsoft shit

            string xmlWellFormated = RemoveAllNamespaces(result);

            // Create an instance of the XmlSerializer class
            XmlSerializer serializer = new XmlSerializer(typeof(List<Application>));

            using (StringReader reader = new StringReader(xmlWellFormated))
            {
                List<Application> Applications = (List<Application>)serializer.Deserialize(reader);

                foreach (Application app in Applications)
                {
                    dataGridViewApp.Rows.Add(app.Id, app.Name, app.Creation_dt);
                }
                  
            }

            btnGetAllApp.Enabled = true;
            btnGetAllApp.Text = initialBtnText;

        }

        private void listBoxAllApp_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public string RemoveSpecialChars(string input)
        {
            return Regex.Replace(input, @"[^0-9a-zA-Z-_]+", string.Empty);
        }

        private async void btnCreateApp_Click(object sender, EventArgs e)
        {

            string appName = RemoveSpecialChars(textNewAppName.Text);


            if (appName.Trim().Length <= 0)
            {
                MessageBox.Show("Please enter the application name.");
                return;
            }

            btnCreateApp.Enabled = false;

            XmlDocument doc = new XmlDocument();

            // Create the root element
            XmlElement root = doc.CreateElement("Resource");
            root.SetAttribute("type", "Application");
            doc.AppendChild(root);

            // Create the Application element
            XmlElement application = doc.CreateElement("Application");
            root.AppendChild(application);

            // Create the Name element
            XmlElement name = doc.CreateElement("Name");
            name.InnerText = appName;
            application.AppendChild(name);

            var client = new RestClient(url);
            var request = new RestRequest("");
            request.RequestFormat = DataFormat.Xml;
            request.AddParameter("application/xml", doc, ParameterType.RequestBody);
            RestResponse response = await client.ExecutePostAsync(request);
            btnCreateApp.Enabled = true;

            string message = XElement.Parse(response.Content).Value;

            if (response.IsSuccessful && dataGridViewApp.Rows != null)
            {
                //If success reload the Application list
                btnGetAllApp.PerformClick();

            }

            MessageBox.Show(message);

            textNewAppName.Text = "";
            //textNewAppName.Focus();

        }

        private void dataGridViewApp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxApplicationModule.Text = dataGridViewApp.Rows[e.RowIndex].Cells["name"].Value.ToString();
        }

        private void textNewAppName_TextChanged(object sender, EventArgs e)
        {
         
        }

        private async void btnGetAppById_Click(object sender, EventArgs e)
        {
            var id = textAppById.Text;

            if (string.IsNullOrEmpty(id) || !int.TryParse(id, out _)) 
            {
                MessageBox.Show("Only numbers.");
                return;
            }
                

            listShowById.Text = "";

            btnGetAppById.Enabled = false;

            var client = new RestClient(url);

            var request = new RestRequest($"{id}");
            request.AddHeader("Accept", "application/xml");

            var response = await client.ExecuteGetAsync(request);

            btnGetAppById.Enabled = true;

            if (!response.IsSuccessful)
            {
                listShowById.Text = "Application not found";
                return;
            }
            
            var result = XElement.Parse(response.Content).Value; //se nao fizer isto aparece o microsoft shit

            string xmlWellFormated = RemoveAllNamespaces(result);

            // Create an instance of the XmlSerializer class
            XmlSerializer serializer = new XmlSerializer(typeof(Application));

                using (StringReader reader = new StringReader(xmlWellFormated))
                {
                    Application app = (Application)serializer.Deserialize(reader);
               
                listShowById.AppendText($"[ID]:  {app.Id} {Environment.NewLine}[NAME]:  {app.Name} {Environment.NewLine}[CREATED AT]: {app.Creation_dt}");
                    
                }

            }

        private async void btnUpdateApp_Click(object sender, EventArgs e)
        {

            string appName = RemoveSpecialChars(textAppName.Text);
            string appOldName = textOldAppName.Text;
            if (appName.Trim().Length <= 0 || appOldName.Trim().Length <= 0)
            {
                MessageBox.Show("Please fill out both fields: \"Old\" and \"New\" name.");
                return;
            }

            btnUpdateApp.Enabled = false;

            XmlDocument doc = new XmlDocument();

            // Create the root element
            XmlElement root = doc.CreateElement("Resource");
            root.SetAttribute("type", "Application");
            doc.AppendChild(root);

            // Create the Application element
            XmlElement application = doc.CreateElement("Application");
            root.AppendChild(application);

            // Create the Name element
            XmlElement name = doc.CreateElement("Name");
            name.InnerText = appName;
            application.AppendChild(name);

            //Create the oldName Element
            XmlElement oldName = doc.CreateElement("OldName");
            oldName.InnerText = appOldName;
            application.AppendChild(oldName);

            var client = new RestClient(url);
            var request = new RestRequest("");
            request.RequestFormat = DataFormat.Xml;
            request.AddParameter("application/xml", doc, ParameterType.RequestBody);
            RestResponse response = await client.ExecutePutAsync(request);

            if (response.IsSuccessful && dataGridViewApp.Rows != null)
            {
                btnGetAllApp.PerformClick();
            }


            string message = XElement.Parse(response.Content).Value;

            MessageBox.Show(message);

            btnUpdateApp.Enabled = true;
        }

        private void btnDeleteApp_Click(object sender, EventArgs e)
        {
            
            int index = dataGridViewApp.SelectedCells[0].RowIndex;
            string deleteApp = dataGridViewApp.Rows[index].Cells["name"].Value.ToString();

            if (!confirmDelete($"Are you sure to delete app: {deleteApp}")) return;

            btnDeleteApp.Enabled = false;
            XmlDocument doc = new XmlDocument();
            // Create the root element
            XmlElement root = doc.CreateElement("Resource");
            root.SetAttribute("type", "Application");
            doc.AppendChild(root);
            // Create the Application element
            XmlElement application = doc.CreateElement("Application");
            root.AppendChild(application);
            // Create the Name element
            XmlElement name = doc.CreateElement("Name");
            name.InnerText = deleteApp;
            application.AppendChild(name);

            var client = new RestClient(url);
            var request = new RestRequest("", Method.Delete);
            request.RequestFormat = DataFormat.Xml;
            request.AddParameter("application/xml", doc, ParameterType.RequestBody);
            RestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                btnGetAllApp.PerformClick();
            }

            string message = XElement.Parse(response.Content).Value;

            MessageBox.Show(message);

            btnDeleteApp.Enabled = true;
        }

        private void dataGridViewApp_SelectionChanged(object sender, EventArgs e)
        {

            int selectedCellCount = dataGridViewApp.GetCellCount(DataGridViewElementStates.Selected);
            btnDeleteApp.Enabled = selectedCellCount > 0;
            btnClearAppSelection.Enabled = selectedCellCount > 0;
        }

        private bool confirmDelete(string message) 
        {
            DialogResult confirmResult = MessageBox.Show(message, "Confirm Delete!!", MessageBoxButtons.YesNo);

            return confirmResult == DialogResult.Yes;
        }

        private bool validateAppName(string appName)
        {
            return appName.Trim().Length <= 0;
        }

        private async void btnCreateModule_Click(object sender, EventArgs e)
        {

            string appName = textBoxApplicationModule.Text;

            if (validateAppName(appName))
            {
                MessageBox.Show("Please select/enter the application name.");
                return;
            }

            string moduleName = RemoveSpecialChars(textModuleName.Text);

            if (moduleName.Trim().Length <= 0)
            {
                MessageBox.Show("Please enter the module name.");
                return;
            }


            btnCreateModule.Enabled = false;

            XmlDocument doc = new XmlDocument();

            // Create the root element
            XmlElement root = doc.CreateElement("Resource");
            root.SetAttribute("type", "Module");
            doc.AppendChild(root);

            // Create the Application element
            XmlElement module = doc.CreateElement("Module");
            root.AppendChild(module);

            // Create the Name element
            XmlElement name = doc.CreateElement("Name");
            name.InnerText = moduleName;
            module.AppendChild(name);

            var client = new RestClient(url);
            var request = new RestRequest($"{appName}");
            request.RequestFormat = DataFormat.Xml;
            request.AddParameter("application/xml", doc, ParameterType.RequestBody);
            RestResponse response = await client.ExecutePostAsync(request);


            btnCreateModule.Enabled = true;

            string message = XElement.Parse(response.Content).Value;

            if (response.IsSuccessful && dataGridViewModules.Rows != null)
            {
                //If success reload the Application list
                btnGetAllModules.PerformClick();

            }

            MessageBox.Show(message);

            textModuleName.Text = "";

        }

        private async void btnGetAllModules_Click(object sender, EventArgs e)
        {

            string appName = textBoxApplicationModule.Text;

            if (appName.Trim().Length <= 0)
            {
                MessageBox.Show("Please select/enter the application name.");
                return;
            }
            btnGetAllModules.Enabled = false;

            var client = new RestClient(url);
            

            var request = new RestRequest($"{appName}");
            request.AddHeader("Accept", "application/xml");

            var response = await client.ExecuteGetAsync(request);

            if (!response.IsSuccessful)
            {
                btnGetAllModules.Enabled = true;

                try 
                {
                    MessageBox.Show(XElement.Parse(response.Content).Value);

                } catch (Exception exception)
                {
                    MessageBox.Show("Something went wrong....");
                }

                return;
            }

            var result = XElement.Parse(response.Content).Value; //se nao fizer isto aparece o microsoft shit

            string xmlWellFormated = RemoveAllNamespaces(result);

            //Clear Gridview current data
            dataGridViewModules.Rows.Clear();
            dataGridViewModules.Refresh();


            // Create an instance of the XmlSerializer class
            XmlSerializer serializer = new XmlSerializer(typeof(List<Module>));

            using (StringReader reader = new StringReader(xmlWellFormated))
            {
                List<Module> modules = (List<Module>)serializer.Deserialize(reader);

                foreach (Module mod in modules)
                {
                    dataGridViewModules.Rows.Add(mod.Id, mod.Parent, mod.Name, mod.Creation_dt);
                }
                 
                       // getAllMods.AppendText($"created at: {mod.Id} {Environment.NewLine} Module Name: {mod.Name} {Environment.NewLine} created at: {mod.Creation_dt} {Environment.NewLine} module parent: {mod.Parent}");
                    
            }

            btnGetAllModules.Enabled = true;
        }

        private void dataGridViewModules_SelectionChanged(object sender, EventArgs e)
        {

            int selectedCellCount = dataGridViewModules.GetCellCount(DataGridViewElementStates.Selected);
            btnDeleteModule.Enabled = selectedCellCount > 0;
            btnCreateData.Enabled = selectedCellCount > 0;
            textDataContent.Enabled = selectedCellCount > 0;
            btnClearModuleSelection.Enabled = selectedCellCount > 0;
        }

        private async void btnDeleteModule_Click(object sender, EventArgs e)
        {

            int index = dataGridViewModules.SelectedCells[0].RowIndex;
            string moduleName = dataGridViewModules.Rows[index].Cells["mname"].Value.ToString();
            string appName = textBoxApplicationModule.Text;

            if (appName.Trim().Length <= 0)
            {
                MessageBox.Show("Please select/enter the application name.");
                return;
            }

            if (!confirmDelete($"Are you sure to delete module: {moduleName}")) return;

            btnDeleteModule.Enabled = false;

            

            XmlDocument doc = new XmlDocument();
            // Create the root element
            XmlElement root = doc.CreateElement("Resource");
            root.SetAttribute("type", "Module");
            doc.AppendChild(root);
            // Create the Application element
            XmlElement module = doc.CreateElement("Module");
            root.AppendChild(module);
            // Create the Name element
            XmlElement name = doc.CreateElement("Name");
            name.InnerText = moduleName;
            module.AppendChild(name);

            var client = new RestClient(url);
            var request = new RestRequest($"{appName}",Method.Delete);
            request.RequestFormat = DataFormat.Xml;
            request.AddParameter("application/xml", doc, ParameterType.RequestBody);
            RestResponse response = await client.ExecuteAsync(request);


            if (response.IsSuccessful)
            {
                btnGetAllModules.PerformClick();
            }

            string message = XElement.Parse(response.Content).Value;

            MessageBox.Show(message);

            btnDeleteModule.Enabled = true;

       
        }

        private async void btnUpdateModule_Click(object sender, EventArgs e)
        {

            string moduleName = RemoveSpecialChars(textNewModuleName.Text);
            string moduleOldName = textOldModuleName.Text;
            string appName = textBoxApplicationModule.Text;

            if (appName.Trim().Length <= 0)
            {
                MessageBox.Show("Please select/enter the application name.");
                return;
            }

            if (moduleName.Trim().Length <= 0 || moduleOldName.Trim().Length <= 0)
            {
                MessageBox.Show("Please fill out both fields: \"Old\" and \"New\" name.");
                return;
            }

            btnUpdateModule.Enabled = false;

            XmlDocument doc = new XmlDocument();

            // Create the root element
            XmlElement root = doc.CreateElement("Resource");
            root.SetAttribute("type", "Module");
            doc.AppendChild(root);

            // Create the Application element
            XmlElement module = doc.CreateElement("Module");
            root.AppendChild(module);

            // Create the Name element
            XmlElement name = doc.CreateElement("Name");
            name.InnerText = moduleName;
            module.AppendChild(name);

            //Create the oldName Element
            XmlElement oldName = doc.CreateElement("OldName");
            oldName.InnerText = moduleOldName;
            module.AppendChild(oldName);

            var client = new RestClient(url);
            var request = new RestRequest($"{appName}");
            request.RequestFormat = DataFormat.Xml;
            request.AddParameter("application/xml", doc, ParameterType.RequestBody);
            RestResponse response = await client.ExecutePutAsync(request);

            if (response.IsSuccessful)
            {
                btnGetAllModules.PerformClick();
                textNewModuleName.Text = "";
                textOldModuleName.Text = "";
            }

            string message = XElement.Parse(response.Content).Value;

            MessageBox.Show(message);

            btnUpdateModule.Enabled = true;
        }

        private async void btnFindModuleById_Click(object sender, EventArgs e)
        {
            var id = moduleId.Text;
            string appName = textBoxApplicationModule.Text;

             if (string.IsNullOrEmpty(id) || !int.TryParse(id, out _)) 
            {
                MessageBox.Show("Only numbers.");
                return;
            }

            if (appName.Trim().Length <= 0)
            {
                MessageBox.Show("Please select/enter the application name.");
                return;
            }

            btnFindModuleById.Enabled = false;
            var client = new RestClient(url);

            var request = new RestRequest($"{appName}/{id}");
            request.AddHeader("Accept", "application/xml");

            var response = await client.ExecuteGetAsync(request);

            btnFindModuleById.Enabled = true;

            if (!response.IsSuccessful)
            {
                moduleDetail.Text = "Module not found";
                return;
            }

            var result = XElement.Parse(response.Content).Value; //se nao fizer isto aparece o microsoft shit

                string xmlWellFormated = RemoveAllNamespaces(result);

                // Create an instance of the XmlSerializer class
                XmlSerializer serializer = new XmlSerializer(typeof(Module));

                using (StringReader reader = new StringReader(xmlWellFormated))
                {
                    Module mod = (Module)serializer.Deserialize(reader);

                    moduleDetail.AppendText($"[ID]:  {mod.Id} {Environment.NewLine}[PARENT]:  {mod.Parent} {Environment.NewLine}[NAME]:  {mod.Name} {Environment.NewLine}[CREATED AT]: {mod.Creation_dt}");
                  
                }

        }

        private async void btnCreateData_Click(object sender, EventArgs e)
        {
            string appName = textBoxApplicationModule.Text;
            string modName = selectedModuleData.Text;
            string dataContent = textDataContent.Text;

            if (dataContent.Trim().Length <= 0)
            {
                MessageBox.Show("Please enter the content.");
                return;
            }

            btnCreateData.Enabled = false;

            XmlDocument doc = new XmlDocument();
            // Create the root element
            XmlElement root = doc.CreateElement("Resource");
            root.SetAttribute("type", "Data");
            doc.AppendChild(root);
            // Create the Application element
            XmlElement data = doc.CreateElement("Data");
            root.AppendChild(data);
            // Create the Name element
            XmlElement name = doc.CreateElement("Content");
            name.InnerText = textDataContent.Text;
            data.AppendChild(name);

            var client = new RestClient(url);
            var request = new RestRequest($"{appName}/{modName}");
            request.RequestFormat = DataFormat.Xml;
            request.AddParameter("application/xml", doc, ParameterType.RequestBody);
            RestResponse response = await client.ExecutePostAsync(request);

            string message = XElement.Parse(response.Content).Value;

            MessageBox.Show(message);

            btnCreateData.Enabled = true;

        }

        private void dataGridViewModules_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //selectedModuleData.Text = e.RowIndex.ToString();
            selectedModuleData.Text  = dataGridViewModules.Rows[e.RowIndex].Cells["mname"].Value.ToString() ??  "<Select Module>";
        }

        private void btnClearAppSelection_Click(object sender, EventArgs e)
        {
            dataGridViewApp.ClearSelection();

        }

        private void btnClearModuleSelection_Click(object sender, EventArgs e)
        {
            dataGridViewModules.ClearSelection();
        }
    }
}
