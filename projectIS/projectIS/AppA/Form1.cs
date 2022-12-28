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
using System.Text.Json.Serialization;

namespace AppA
{
    public partial class Form1 : Form
    {
        string url = @"http://localhost:54833/api/somiod";
        public Form1()
        {
            InitializeComponent();
        }

        private void createButton_Click(object sender, EventArgs e)
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
    }
}
