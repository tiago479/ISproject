using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;

namespace projectIS.Validators
{
    class XMLValidator
    {
        public string XmlFilePath { get; set; }
        public string XsdFilePath { get; set; }
        private XElement XmlFile { get; set; }
        private XmlDocument xmlDoc;
        

        private bool isValid = true;
        public string resType { get; set; }
 
        private string validationMessage;
        public string ValidationMessage
        {
            get { return validationMessage; }
        }


        public XMLValidator(XElement xmlFile)
        {
            xmlDoc = new XmlDocument();
            XmlFile = xmlFile;
            XsdFilePath = "\\Validators\\validator.xsd";
        }


        #region Validate XML with XML Schema (xsd)
        public bool ValidateXML()
        {
            isValid = true;
            var path = new Uri(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase)).LocalPath;

            try
            {
                validationMessage = "";
                xmlDoc.Load(XmlFile.CreateReader());
                ValidationEventHandler eventHandler = new ValidationEventHandler(MyValidateMethod);
                xmlDoc.Schemas.Add(null, path + XsdFilePath);
                xmlDoc.Validate(eventHandler);

                resType = xmlDoc.SelectSingleNode("//Resource/*").Name.ToString();

                if (resourceType() != resType)
                {
                    isValid = false;
                    validationMessage = string.Format("ERROR: The resource {0} dosen't match with type {1}", resType, resourceType());
                }
            }
            catch (XmlException ex)
            {
                isValid = false;
                validationMessage = string.Format("ERROR: {0}", ex.ToString());
            }
            return isValid;
        }

        private void MyValidateMethod(object sender, ValidationEventArgs args)
        {
            isValid = false;
            switch (args.Severity)
            {
                case XmlSeverityType.Error:
                    validationMessage = string.Format("ERROR: {0}", args.Message);
                    break;
                case XmlSeverityType.Warning:
                    validationMessage = string.Format("WARNING: {0}", args.Message);
                    break;
                default:
                    break;
            }
        }

        public string resourceType()
        {
            return XmlFile.Attribute("type").Value;
        }
     
        #endregion


    }
}