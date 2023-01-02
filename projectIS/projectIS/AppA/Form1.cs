using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using System.Xml;
using RestSharp;
using System.Security.AccessControl;
using projectIS.Model;
using Application = projectIS.Model.Application;
using Module = projectIS.Model.Module;
using System.Threading;
using System.IO;
using System.Net;
using System.Xml.Serialization;
using RestSharp.Serializers.Xml;
using RestSharp.Serializers;
using System.Data.SqlTypes;
using System.Diagnostics;

namespace AppA
{
    public partial class Form1 : Form
    {
        string url = "https://localhost:44356/api/somiod/";
        public Form1()
        {
            InitializeComponent();
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

        #region APPLICATION

        //CREATE APPLICATION
        private void createButton_Click(object sender, EventArgs e)
        {
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
            name.InnerText = applicationName.Text;
            application.AppendChild(name);

            var client = new RestSharp.RestClient(url);
            var request = new RestSharp.RestRequest("", RestSharp.Method.Post);
            request.RequestFormat = RestSharp.DataFormat.Xml;
            request.AddParameter("application/xml", doc, ParameterType.RequestBody);
            RestSharp.RestResponse response = client.Execute(request);

            MessageBox.Show(response.ResponseStatus.ToString());
        }

        //GET MOD BY ID
        private void button1_Click(object sender, EventArgs e)
        {
            var id = findById.Text;

            if (String.IsNullOrEmpty(id) || Int32.Parse(id) < 1)
                return;

            var client = new RestClient(url);

            var request = new RestRequest($"{id}", RestSharp.Method.Get);
            request.AddHeader("Accept", "application/xml");

            var response = client.Execute(request);



            if (response.StatusCode == HttpStatusCode.OK)
            {

                var result = XElement.Parse(response.Content).Value; //se nao fizer isto aparece o microsoft shit

                string xmlWellFormated = RemoveAllNamespaces(result);

                // Create an instance of the XmlSerializer class
                XmlSerializer serializer = new XmlSerializer(typeof(Application));

                using (StringReader reader = new StringReader(xmlWellFormated))
                {
                    Application app = (Application)serializer.Deserialize(reader);

                    if (app.Id == 0)
                    {
                        showById.AppendText($"Application not found {Environment.NewLine}");
                    }
                    else
                    {
                        showById.AppendText($"created at: {app.Id} {Environment.NewLine} Application Name: {app.Name} {Environment.NewLine} created at: {app.Creation_dt}");
                    }
                }
            }

        }

        //GET ALL APPS
        private void getAllApps_Click(object sender, EventArgs e)
        {
            var client = new RestClient(url);

            var request = new RestRequest($"", RestSharp.Method.Get);
            request.AddHeader("Accept", "application/xml");

            var response = client.Execute(request);

            var result = XElement.Parse(response.Content).Value; //se nao fizer isto aparece o microsoft shit

            string xmlWellFormated = RemoveAllNamespaces(result);

            // Create an instance of the XmlSerializer class
            XmlSerializer serializer = new XmlSerializer(typeof(List<Application>));

            using (StringReader reader = new StringReader(xmlWellFormated))
            {
                List<Application> Applications = (List<Application>)serializer.Deserialize(reader);

                foreach (Application app in Applications)
                    if (app.Id == 0)
                    {
                        getAllAppsBox.AppendText($"Application not found {Environment.NewLine}");
                    }
                    else
                    {
                        getAllAppsBox.AppendText($"created at: {app.Id} {Environment.NewLine} Application Name: {app.Name} {Environment.NewLine} created at: {app.Creation_dt}");
                    }
            }
        }
        //Set App Name
        private void setApp_Click(object sender, EventArgs e)
        {
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
            name.InnerText = Name.Text;
            application.AppendChild(name);
            //Create the oldName Element
            XmlElement oldName = doc.CreateElement("OldName");
            oldName.InnerText = setAppName.Text;
            application.AppendChild(oldName);

            var client = new RestSharp.RestClient(url);
            var request = new RestSharp.RestRequest("", RestSharp.Method.Put);
            request.RequestFormat = RestSharp.DataFormat.Xml;
            request.AddParameter("application/xml", doc, ParameterType.RequestBody);
            RestSharp.RestResponse response = client.Execute(request);

            MessageBox.Show(response.ResponseStatus.ToString());
        }

        //Delete Application
        private void button4_Click_1(object sender, EventArgs e)
        {
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
            name.InnerText = deleteApp.Text;
            application.AppendChild(name);

            var client = new RestSharp.RestClient(url);
            var request = new RestSharp.RestRequest("", RestSharp.Method.Delete);
            request.RequestFormat = RestSharp.DataFormat.Xml;
            request.AddParameter("application/xml", doc, ParameterType.RequestBody);
            RestSharp.RestResponse response = client.Execute(request);

            MessageBox.Show(response.ResponseStatus.ToString());
        }

        #endregion

        #region MODULE

        //CREATE MODULE
        private void button2_Click(object sender, EventArgs e)
        {
            string appName = textBoxApplicationModule.Text;

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
            name.InnerText = textBox1.Text;
            module.AppendChild(name);

            var client = new RestSharp.RestClient(url);
            var request = new RestSharp.RestRequest($"{appName}", RestSharp.Method.Post);
            request.RequestFormat = RestSharp.DataFormat.Xml;
            request.AddParameter("application/xml", doc, ParameterType.RequestBody);
            RestSharp.RestResponse response = client.Execute(request);

            MessageBox.Show(response.ResponseStatus.ToString());
        }

        //GET MODULE BY ID
        private void button3_Click(object sender, EventArgs e)
        {
            var id = moduleId.Text;
            string appName = textBoxApplicationModule.Text;

            if (String.IsNullOrEmpty(id) || Int32.Parse(id) < 1)
                return;

            var client = new RestClient(url);

            var request = new RestRequest($"{appName}/{id}", RestSharp.Method.Get);
            request.AddHeader("Accept", "application/xml");

            var response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = XElement.Parse(response.Content).Value; //se nao fizer isto aparece o microsoft shit

                string xmlWellFormated = RemoveAllNamespaces(result);

                // Create an instance of the XmlSerializer class
                XmlSerializer serializer = new XmlSerializer(typeof(Module));

                using (StringReader reader = new StringReader(xmlWellFormated))
                {
                    Module mod = (Module)serializer.Deserialize(reader);

                    if (mod.Id == 0)
                    {
                        moduleByIdGet.AppendText($"Module not found {Environment.NewLine}");
                    }
                    else
                    {
                        moduleByIdGet.AppendText($"created at: {mod.Id} {Environment.NewLine} Module Name: {mod.Name} {Environment.NewLine} created at: {mod.Creation_dt} {Environment.NewLine} module parent: {mod.Parent}");
                    }
                }
            }
        }

        //GET ALL MODULES
        private void button4_Click(object sender, EventArgs e)
        {
            var client = new RestClient(url);
            string appName = textBoxApplicationModule.Text;

            var request = new RestRequest($"{appName}", RestSharp.Method.Get);
            request.AddHeader("Accept", "application/xml");

            var response = client.Execute(request);

            var result = XElement.Parse(response.Content).Value; //se nao fizer isto aparece o microsoft shit

            string xmlWellFormated = RemoveAllNamespaces(result);

            // Create an instance of the XmlSerializer class
            XmlSerializer serializer = new XmlSerializer(typeof(List<Module>));

            using (StringReader reader = new StringReader(xmlWellFormated))
            {
                List<Module> modules = (List<Module>)serializer.Deserialize(reader);

                foreach (Module mod in modules)
                    if (mod.Id == 0)
                    {
                        getAllMods.AppendText($"Module not found {Environment.NewLine}");
                    }
                    else
                    {
                        getAllMods.AppendText($"created at: {mod.Id} {Environment.NewLine} Module Name: {mod.Name} {Environment.NewLine} created at: {mod.Creation_dt} {Environment.NewLine} module parent: {mod.Parent}");
                    }
            }
        }

        //Delete Module

        private void DeleteModule_Click(object sender, EventArgs e)
        {
            string appName = textBoxApplicationModule.Text;

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
            name.InnerText = moduleName.Text;
            module.AppendChild(name);

            var client = new RestSharp.RestClient(url);
            var request = new RestSharp.RestRequest($"{appName}", RestSharp.Method.Delete);
            request.RequestFormat = RestSharp.DataFormat.Xml;
            request.AddParameter("application/xml", doc, ParameterType.RequestBody);
            RestSharp.RestResponse response = client.Execute(request);

            MessageBox.Show(response.ResponseStatus.ToString());
        }

        //set MODULE

        private void setModule_Click(object sender, EventArgs e)
        {
            string appName = textBoxApplicationModule.Text;

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
            name.InnerText = moduleName.Text;
            module.AppendChild(name);
            //Create the oldName Element
            XmlElement oldName = doc.CreateElement("OldName");
            oldName.InnerText = resType.Text;
            module.AppendChild(oldName);

            var client = new RestSharp.RestClient(url);
            var request = new RestSharp.RestRequest($"{appName}", RestSharp.Method.Put);
            request.RequestFormat = RestSharp.DataFormat.Xml;
            request.AddParameter("application/xml", doc, ParameterType.RequestBody);
            RestSharp.RestResponse response = client.Execute(request);

            MessageBox.Show(response.ResponseStatus.ToString());
        }

        #endregion

        private void createData_Click(object sender, EventArgs e)
        {
            string appName = textBoxApplicationModule.Text;
            string modName = moduleName.Text;

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
            name.InnerText = textBox2.Text;
            data.AppendChild(name);

            var client = new RestSharp.RestClient(url);
            var request = new RestSharp.RestRequest($"{appName}/{modName}", RestSharp.Method.Post);
            request.RequestFormat = RestSharp.DataFormat.Xml;
            request.AddParameter("application/xml", doc, ParameterType.RequestBody);
            RestSharp.RestResponse response = client.Execute(request);

            MessageBox.Show(response.ResponseStatus.ToString());
        }

        #region Data Without references
        /* Create
        string appName = textBoxApplicationModule.Text;
        string modName = moduleName.Text;

        XmlDocument doc = new XmlDocument();
        // Create the root element
        XmlElement root = doc.CreateElement("Resource");
        root.SetAttribute("type", "Data");
            doc.AppendChild(root);
            // Create the Application element
            XmlElement data = doc.CreateElement("Data");
        root.AppendChild(data);
            // Create the Name element
            XmlElement content = doc.CreateElement("Content");
        content.InnerText = falta textbox;
            data.AppendChild(content);

            var client = new RestSharp.RestClient(url);
        var request = new RestSharp.RestRequest($"{appName}/{modName}", RestSharp.Method.Post);
        request.RequestFormat = RestSharp.DataFormat.Xml;
            request.AddParameter("application/xml", doc, ParameterType.RequestBody);
            RestSharp.RestResponse response = client.Execute(request);

        MessageBox.Show(response.ResponseStatus.ToString());
        */

        /* Create
        string appName = textBoxApplicationModule.Text;
        string modName = moduleName.Text;

        XmlDocument doc = new XmlDocument();
        // Create the root element
        XmlElement root = doc.CreateElement("Resource");
        root.SetAttribute("type", "Data");
            doc.AppendChild(root);
            // Create the Application element
            XmlElement data = doc.CreateElement("Data");
        root.AppendChild(data);
            // Create the ID element
            XmlElement id = doc.CreateElement("Id");
        id.InnerText = falta textbox;
            data.AppendChild(id);

            var client = new RestSharp.RestClient(url);
        var request = new RestSharp.RestRequest($"{appName}/{modName}", RestSharp.Method.Delete);
        request.RequestFormat = RestSharp.DataFormat.Xml;
            request.AddParameter("application/xml", doc, ParameterType.RequestBody);
            RestSharp.RestResponse response = client.Execute(request);

        MessageBox.Show(response.ResponseStatus.ToString());
        */

        #endregion

        #region Sub Without references
        /* Create
        string appName = textBoxApplicationModule.Text;
        string modName = moduleName.Text;

        XmlDocument doc = new XmlDocument();
        // Create the root element
        XmlElement root = doc.CreateElement("Resource");
        root.SetAttribute("type", "Subscription");
            doc.AppendChild(root);
            // Create the Subscription element
            XmlElement sub = doc.CreateElement("Subscription");
        root.AppendChild(sub);
            // Create the Name element
            XmlElement name = doc.CreateElement("Name");
        name.InnerText = falta textbox;
            sub.AppendChild(name);
            XmlElement event = doc.CreateElement("Event");
        event.InnerText = falta textbox;
            sub.AppendChild(event);
            XmlElement endPoint = doc.CreateElement("EndPoint");
        endPoint.InnerText = falta textbox;
            sub.AppendChild(endPoint);

            var client = new RestSharp.RestClient(url);
        var request = new RestSharp.RestRequest($"{appName}/{modName}", RestSharp.Method.Post);
        request.RequestFormat = RestSharp.DataFormat.Xml;
            request.AddParameter("application/xml", doc, ParameterType.RequestBody);
            RestSharp.RestResponse response = client.Execute(request);

        MessageBox.Show(response.ResponseStatus.ToString());
        */

        /* Create
        string appName = textBoxApplicationModule.Text;
        string modName = moduleName.Text;

        XmlDocument doc = new XmlDocument();
        // Create the root element
        XmlElement root = doc.CreateElement("Resource");
        root.SetAttribute("type", "Subscription");
            doc.AppendChild(root);
            // Create the Subscription element
            XmlElement sub = doc.CreateElement("Subscription");
        root.AppendChild(sub);
            // Create the Name element
            XmlElement name = doc.CreateElement("Name");
        name.InnerText = falta textbox;
            sub.AppendChild(name);
            XmlElement event = doc.CreateElement("Event");
        event.InnerText = falta textbox;
            sub.AppendChild(event);
            XmlElement endPoint = doc.CreateElement("EndPoint");
        endPoint.InnerText = falta textbox;
            sub.AppendChild(endPoint);

            var client = new RestSharp.RestClient(url);
        var request = new RestSharp.RestRequest($"{appName}/{modName}", RestSharp.Method.Delete);
        request.RequestFormat = RestSharp.DataFormat.Xml;
            request.AddParameter("application/xml", doc, ParameterType.RequestBody);
            RestSharp.RestResponse response = client.Execute(request);

        MessageBox.Show(response.ResponseStatus.ToString());
        */

        #endregion
    }
}
