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

        //applications
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var client = new RestClient(url);
            string appName = comboBox1.Text;

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
                /*
                if(modules == null)
                {
                    comboBox2.SelectedText ="Não tem modulos";
                }
                */
                //Jerry nao estou conseguir meter para quando nao ha modulos aparecer mensagem 
                //tenta fazer essa validação
                //else
                comboBox2.Items.Clear();
                comboBox2.Text = null;
                foreach (Module mod in modules)
                {
                    comboBox2.Items.Add(mod.Name);
                }
            }
        }

        private void comboBox1_click(object sender, EventArgs e)
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

                comboBox1.Items.Clear();
                foreach (Application app in Applications)
                {
                    comboBox1.Items.Add(app.Name);
                }
            }
        }

        //Modules
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var client = new RestClient(url);

            string appName = comboBox1.Text;
            string modelName = comboBox2.Text;

            var request = new RestRequest($"{appName}/{modelName}", RestSharp.Method.Get);
            request.AddHeader("Accept", "application/xml");

            var response = client.Execute(request);

            var result = XElement.Parse(response.Content).Value; //se nao fizer isto aparece o microsoft shit

            string xmlWellFormated = RemoveAllNamespaces(result);

            // Create an instance of the XmlSerializer class
            XmlSerializer serializer = new XmlSerializer(typeof(List<Data>));

            using (StringReader reader = new StringReader(xmlWellFormated))
            {
                List<Data> datas = (List<Data>)serializer.Deserialize(reader);

                comboBox3.Items.Clear();
                foreach (Data data in datas)
                {
                    comboBox3.Items.Add(data.Id);
                }
            }
        }

        private void Publish_Click(object sender, EventArgs e)
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
            XmlElement content = doc.CreateElement("Id");
            content.InnerText = comboBox3.Text;
            data.AppendChild(content);

            var client = new RestSharp.RestClient(url);
            var request = new RestSharp.RestRequest($"{appName}/{modName}", RestSharp.Method.Delete);
            request.RequestFormat = RestSharp.DataFormat.Xml;
            request.AddParameter("application/xml", doc, ParameterType.RequestBody);
            RestSharp.RestResponse response = client.Execute(request);

            MessageBox.Show(response.ResponseStatus.ToString());
        }
    }
}
