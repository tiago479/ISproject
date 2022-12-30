using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace App
{
    public partial class Form1 : Form
    {
        string url = @"http://localhost:54833/api/somiod";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XmlDocument applicationXml = new XmlDocument();
            XmlElement applicationElement = (XmlElement)applicationXml.AppendChild(applicationXml.CreateElement("Application"));
            applicationElement.AppendChild(applicationXml.CreateElement("Name")).InnerText = applicationName.Text;
            Console.WriteLine(applicationXml.OuterXml);

            var client = new RestSharp.RestClient(url);
            var request = new RestSharp.RestRequest("", RestSharp.Method.Post);
            request.RequestFormat = RestSharp.DataFormat.Xml;
            request.AddParameter("application/xml", applicationXml, ParameterType.RequestBody);
            RestSharp.RestResponse response = client.Execute(request);

            MessageBox.Show(response.ResponseStatus.ToString());
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
