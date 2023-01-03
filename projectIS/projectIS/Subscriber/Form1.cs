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
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
namespace Subscriber
{
    public partial class Form1 : Form
    {
        string url = "https://localhost:44356/api/somiod/";

        private List<string> subscribedTopics;

        private MqttClient mqttClient;

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

        //private void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        //{
        //    String status = "";
        //    MessageBox.Show("Received = " + Encoding.UTF8.GetString(e.Message));
        //    status = Encoding.UTF8.GetString(e.Message);

        //    richTextBox1.BeginInvoke((MethodInvoker)delegate { richTextBox1.AppendText($"{comboBox3.Text}" + " " + $"{status} {Environment.NewLine}"); });

        //}

        private void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            String status = "";
            MessageBox.Show("Received = " + Encoding.UTF8.GetString(e.Message));
            status = Encoding.UTF8.GetString(e.Message);
            richTextBox1.BeginInvoke((MethodInvoker)delegate { richTextBox1.AppendText($"{comboBox3.Text}" + " " + $"{status} {Environment.NewLine}"); });
            if (status == "Created: on")
            {
                pictureBox1.BeginInvoke((MethodInvoker)delegate { pictureBox1.Hide(); });
                pictureBox2.BeginInvoke((MethodInvoker)delegate { pictureBox2.Show(); });
            }
            if (status == "Created: off")
            {
                pictureBox1.BeginInvoke((MethodInvoker)delegate { pictureBox1.Show(); });
                pictureBox2.BeginInvoke((MethodInvoker)delegate { pictureBox2.Hide(); });
            }
        }

        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        private void SUBSCRIBER_Load(object sender, EventArgs e)
        {

            loadAllApp();

            comboBox3.Items.Add("Creation");
            comboBox3.Items.Add("Deletion");
            comboBox3.Items.Add("Both");
            pictureBox2.Hide();
            lblStatus.Text = "Disconnected";

            subscribedTopics = new List<string>();

        }

        private async void loadAllApp()
        {

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

                if (Applications.Count <= 0)
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


        private void changeComboPlaceholder(System.Windows.Forms.ComboBox comboBox, string text)
        {
            comboBox.Text = text;
        }


        private void comboBox1_Click(object sender, EventArgs e)
        {
  
        }
        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            comboBox2.Enabled = false;
            comboBox3.Enabled = false;
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
     
        private void button1_Click(object sender, EventArgs e)
        {
            mqttClient = new MqttClient(textBox1.Text);
            List<string> mStrTopicsInfo = new List<string>();
            List<byte> qosLevels = new List<byte>();
            qosLevels.Add(MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE);

            if (comboBox3.Text == "Both")
            {
                mStrTopicsInfo.Add($"{comboBox1.Text}/{comboBox2.Text}/Creation");
                mStrTopicsInfo.Add($"{comboBox1.Text}/{comboBox2.Text}/Deletion");
                qosLevels.Add(MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE);
            }
            else
            {
                mStrTopicsInfo.Add($"{comboBox1.Text}/{comboBox2.Text}/{comboBox3.Text}");
            }

            mqttClient.Connect(Guid.NewGuid().ToString());


            if (!mqttClient.IsConnected)
            {
                MessageBox.Show("Error connecting to mosquitto...");
                lblStatus.Text = "Disconnected";
                return;
            }

            mqttClient.MqttMsgPublishReceived += client_MqttMsgPublishReceived;

            mqttClient.Subscribe(mStrTopicsInfo.ToArray(), qosLevels.ToArray());

            lblStatus.Text = "Connected";

            button1.Enabled = false;

            foreach(string topic in mStrTopicsInfo)
            {
                subscribedTopics.Add(topic);
            }

         
            listBox1.DataSource = subscribedTopics.ToArray();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = !string.IsNullOrEmpty(comboBox3.SelectedItem.ToString());
        }

        private void eventClick3(object sender, EventArgs e)
        {
        
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Enabled =  !string.IsNullOrEmpty(comboBox2.SelectedItem.ToString());
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadAllApp();
            comboBox2.Enabled = false;
            comboBox3.Enabled = false;
            changeComboPlaceholder(comboBox2, "");
            changeComboPlaceholder(comboBox3, "");
            button1.Enabled = false;
        }

        private void btnUsub_Click(object sender, EventArgs e)
        {

            if(listBox1.Items.Count <= 0) 
            {
                return;
            }

            // Unsubscribe from a topic
            mqttClient.Unsubscribe(new string[] { listBox1.SelectedItem.ToString() });
            subscribedTopics.Remove(listBox1.SelectedItem.ToString());
            listBox1.DataSource = subscribedTopics.ToArray();



        }
    }
}
