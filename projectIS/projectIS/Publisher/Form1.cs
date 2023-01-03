using projectIS.Model;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Application = projectIS.Model.Application;
using Module = projectIS.Model.Module;

namespace Publisher
{
    public partial class Form1 : Form
    {
        string url = "https://localhost:44356/api/somiod/";

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
        public Form1()
        {
            InitializeComponent();
        }


        private void PUBLISHER_Load(object sender, EventArgs e)
        {

            loadAllApp();

        }

        private async void loadAllApp()
        {
            comboBox1.Enabled = false;

            changeComboPlaceholder(comboBox1, "Loading...");

            var client = new RestClient(url);

            var request = new RestRequest($"");
            request.AddHeader("Accept", "application/xml");

            var response = await client.ExecuteGetAsync(request);

            if (!response.IsSuccessful)
            {
                changeComboPlaceholder(comboBox1, "We could not fetch applications");
                return;
            }

            var result = XElement.Parse(response.Content).Value;

            string xmlWellFormated = RemoveAllNamespaces(result);

            // Create an instance of the XmlSerializer class
            XmlSerializer serializer = new XmlSerializer(typeof(List<Application>));

            using (StringReader reader = new StringReader(xmlWellFormated))
            {
                List<Application> Applications = (List<Application>)serializer.Deserialize(reader);

                if(Applications.Count <= 0 ) 
                {
                    changeComboPlaceholder(comboBox1, "We can't find any applications.");
                    return; 
                }

                changeComboPlaceholder(comboBox1, " -- Select Application --");
                comboBox1.Items.Clear();
                foreach (Application app in Applications)
                {
                    comboBox1.Items.Add(app.Name);
                }
            }

            comboBox1.Enabled = true;
        }

        //applications

        private void changeComboPlaceholder(System.Windows.Forms.ComboBox comboBox, string text) 
        {
            comboBox.Text = text;
            //comboBox.Items.Insert(0, text);
            //comboBox.SelectedIndex = 0;
        }
        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (comboBox1.SelectedIndex == 0) 
            //{
            //    return;
            //}

            comboBox2.Enabled = false;
            comboBox3.Enabled = false;
            Publish.Enabled = false;
            button1.Enabled = false;

            changeComboPlaceholder(comboBox2, "Loading...");

            var client = new RestClient(url);
            string appName = comboBox1.Text;

            var request = new RestRequest($"{appName}");
            request.AddHeader("Accept", "application/xml");

            var response = await client.ExecuteGetAsync(request);

            if (!response.IsSuccessful)
            {
                changeComboPlaceholder(comboBox2, "We could not fetch app modules");
                return;
            }


            var result = XElement.Parse(response.Content).Value; //se nao fizer isto aparece o microsoft shit

            string xmlWellFormated = RemoveAllNamespaces(result);

            // Create an instance of the XmlSerializer class
            XmlSerializer serializer = new XmlSerializer(typeof(List<Module>));

            using (StringReader reader = new StringReader(xmlWellFormated))
            {
                List<Module> modules = (List<Module>)serializer.Deserialize(reader);

                if (modules.Count <= 0)
                {
                    changeComboPlaceholder(comboBox2, "We can't find any module.");
                    return;
                }

                comboBox2.Items.Clear();
                comboBox2.Text = "-- Select Module --";

                foreach (Module mod in modules)
                {
                    comboBox2.Items.Add(mod.Name);
                }
            }
            comboBox2.Enabled = true;
        }

        private void comboBox1_click(object sender, EventArgs e)
        {

        }

        //Modules
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

  

            changeComboPlaceholder(comboBox3, "Loading...");
            Publish.Enabled = false;
            button1.Enabled = false;

            var client = new RestClient(url);

            string appName = comboBox1.Text;
            string modelName = comboBox2.Text;

            var request = new RestRequest($"{appName}/{modelName}", RestSharp.Method.Get);
            request.AddHeader("Accept", "application/xml");

            var response = client.Execute(request);

            comboBox3.Enabled = true;
            Publish.Enabled = true;
            button1.Enabled = true;

            if (!response.IsSuccessful)
            {
                changeComboPlaceholder(comboBox3, "");
                return;
            }

            var result = XElement.Parse(response.Content).Value; //se nao fizer isto aparece o microsoft shit

            string xmlWellFormated = RemoveAllNamespaces(result);

            // Create an instance of the XmlSerializer class
            XmlSerializer serializer = new XmlSerializer(typeof(List<Data>));

            using (StringReader reader = new StringReader(xmlWellFormated))
            {
                List<Data> datas = (List<Data>)serializer.Deserialize(reader);

                if (datas.Count <= 0)
                {
                    changeComboPlaceholder(comboBox3, "");
                    return;
                }

                comboBox3.Text = "-- Select Data --";
                comboBox3.Items.Clear();
                foreach (Data data in datas)
                {
                    comboBox3.Items.Add(data.Content);
                }
            }
       
        }

        private async void Publish_Click(object sender, EventArgs e)
        {
            string appName = comboBox1.Text;
            string modName = comboBox2.Text;

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
            content.InnerText = comboBox3.Text;
            data.AppendChild(content);

            var client = new RestClient(url);
            var request = new RestRequest($"{appName}/{modName}");
            request.RequestFormat = DataFormat.Xml;
            request.AddParameter("application/xml", doc, ParameterType.RequestBody);
            RestResponse response = await client.ExecutePostAsync(request);

            try
            {
                string message = XElement.Parse(response.Content).Value;
                MessageBox.Show(message);

            }
            catch
            {
                MessageBox.Show("Error parsing server response.");
            }


        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string appName = comboBox1.Text;
            string modName = comboBox2.Text;

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
            content.InnerText = comboBox3.Text;
            data.AppendChild(content);

            var client = new RestClient(url);
            var request = new RestRequest($"{appName}/{modName}", Method.Delete);
            request.RequestFormat = DataFormat.Xml;
            request.AddParameter("application/xml", doc, ParameterType.RequestBody);
            RestResponse response = await client.ExecuteAsync(request);

            try
            {
                string message = XElement.Parse(response.Content).Value;
                MessageBox.Show(message);

            }
            catch
            {
                MessageBox.Show("Error parsing server response.");
            }

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadAllApp();

            comboBox2.Enabled = false;
            comboBox3.Enabled = false;
            changeComboPlaceholder(comboBox2, "");
            changeComboPlaceholder(comboBox3, "");
        }
    }
}
