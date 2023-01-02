﻿using RestSharp;
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

namespace Subscriber
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

        private void comboBox1_Click(object sender, EventArgs e)
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
                comboBox2.Items.Clear();
                comboBox2.Text = null;
                foreach (Module mod in modules)
                {
                    comboBox2.Items.Add(mod.Name);
                }
            }
        }
     
        private void button1_Click(object sender, EventArgs e)
        {
            string appName = comboBox1.Text;
            string modName = comboBox2.Text;

            XmlDocument doc = new XmlDocument();
            // Create the root element
            XmlElement root = doc.CreateElement("Resource");
            root.SetAttribute("type", "Subscription");
            doc.AppendChild(root);
            // Create the Subscritipon element
            XmlElement sub = doc.CreateElement("Subscription");
            root.AppendChild(sub);
            // Create the Subname element
            XmlElement name = doc.CreateElement("Name");
            name.InnerText = comboBox1.Text + comboBox3.Text;
            sub.AppendChild(name);

            var client = new RestSharp.RestClient(url);
            var request = new RestSharp.RestRequest($"{appName}/{modName}", RestSharp.Method.Post);
            request.RequestFormat = RestSharp.DataFormat.Xml;
            request.AddParameter("application/xml", doc, ParameterType.RequestBody);
            RestSharp.RestResponse response = client.Execute(request);

            MessageBox.Show(response.ResponseStatus.ToString());
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            comboBox3.Items.Add("Creation");
            comboBox3.Items.Add("Deletion");
            comboBox3.Items.Add("Both");
        }
    }
}
