using projectIS.Model;
using projectIS.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace projectIS.Controller
{
    [RoutePrefix("api/somiod")]
    public class SomiodController : ApiController
    {
        #region XML to model
        public ResourceType xmlconvertToModel(string request, XElement xml)
        {
            XmlSerializer serializer = null;

            switch (request)
            {
                case "Application":
                    serializer = new XmlSerializer(typeof(Application));
                    return (Application)serializer.Deserialize(xml.Element("Application").CreateReader());
                case "Module":
                    serializer = new XmlSerializer(typeof(Module));
                    return (Module)serializer.Deserialize(xml.Element("Module").CreateReader());
                case "Data":
                    serializer = new XmlSerializer(typeof(Data));
                    return (Data)serializer.Deserialize(xml.Element("Data").CreateReader());
                case "Subscription":
                    serializer = new XmlSerializer(typeof(Subscription));
                    return (Subscription)serializer.Deserialize(xml.Element("Subscription").CreateReader());
                default:
                    Console.WriteLine("Wrong request string");
                    return null;
            }
        }
        #endregion

        #region Bad Request Method
        public void emptyOrNull(ResourceType model)
        {
            if (model == null)
            {
                throw new ArgumentNullException();
            }
        }


        #endregion

        #region Response in XML
        public string ToXML(Object oObject)
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlSerializer xmlSerializer = new XmlSerializer(oObject.GetType());
            using (MemoryStream xmlStream = new MemoryStream())
            {
                xmlSerializer.Serialize(xmlStream, oObject);
                xmlStream.Position = 0;
                xmlDoc.Load(xmlStream);
                return xmlDoc.InnerXml;
            }
        }
        #endregion

        #region Aplication CRUD

        #region Get all applications 
        [HttpGet, Route("")]
        public IHttpActionResult GetApplications()
        {
            try
            {
                ApplicationController controller = new ApplicationController();
                List<Application> applications = controller.GetApplications();
                if (applications.Count <= 0)
                {
                    return BadRequest("Cannot find any applcation.");
                }
                string response = ToXML(applications);
                return Ok(response);
            }
            catch (Exception exception)
            {
                return InternalServerError(exception);
            }
        }
        #endregion

        #region Get an application by id
        [HttpGet, Route("{id:int}")]
        public IHttpActionResult GetApplicationById(int id)
        {
            try
            {
                ApplicationController controller = new ApplicationController();
                Application application = controller.GetApplication(id);
                emptyOrNull(application);
                string response = ToXML(application);
                return Ok(response);
            }
            catch (Exception exception)
            {
                return InternalServerError(exception);
            }
        }
        #endregion

        #region Post a new application
        [HttpPost, Route("")]
        public IHttpActionResult PostApplication([FromBody] XElement xml)
        {
     
            if (xml == null)
            {
                return BadRequest(new XmlException("Errors in the XML document").ToString());
            }
            XMLValidator validator = new XMLValidator(xml);

            if (!validator.ValidateXML())
            {
                return BadRequest(validator.ValidationMessage);
            }

            string res_type = validator.resType;

            Application app = (Application)xmlconvertToModel(res_type, xml);

            try
            {
                emptyOrNull(app);
                ApplicationController controller = new ApplicationController();
                bool response = controller.Create(app);
                if (!response)
                {
                    return BadRequest("Operation Failed");
                }
    
               // return Ok(new Success { Message = "A new application was created" });
                return Ok("A new application was created");
            }
            catch (Exception exception)
            {
                return InternalServerError(exception);
            }
        }
        #endregion

        #region Put update an application
        [HttpPut, Route("")]
        public IHttpActionResult PutApplication([FromBody] XElement xml)
        {
            if (xml == null)
            {
                return BadRequest(new XmlException("Errors in the XML document").ToString());
            }
            XMLValidator validator = new XMLValidator(xml);

            if (!validator.ValidateXML())
            {
                return BadRequest(validator.ValidationMessage);
            }

            string res_type = validator.resType;

            Application app = (Application)xmlconvertToModel(res_type, xml);

            try
            {
                emptyOrNull(app);
                ApplicationController controller = new ApplicationController();
                bool response = controller.Update(app);
                if (!response)
                {
                    return BadRequest("Operation Failed");
                }
                return Ok("Application was updated successfully!");
            }
            catch (Exception exception)
            {
                return InternalServerError(exception);
            }
        }
        #endregion

        #region Delete an Application
        [HttpDelete, Route("")]
        public IHttpActionResult DeleteApplication([FromBody] XElement xml)
        {
            if (xml == null)
            {
                return BadRequest(new XmlException("Errors in the XML document").ToString());
            }
            XMLValidator validator = new XMLValidator(xml);

            if (!validator.ValidateXML())
            {
                return BadRequest(validator.ValidationMessage);
            }

            string res_type = validator.resType;

            Application app = (Application)xmlconvertToModel(res_type, xml);

            try
            {
                emptyOrNull(app);
                ApplicationController controller = new ApplicationController();
                bool response = controller.Delete(app.Name);
                if (!response)
                {
                    return BadRequest($"Cannot Delete: {app.Name}");
                }
                return Ok($"Application {app.Name} was deleted");
            }
            catch (Exception exception)
            {
                return InternalServerError(exception);
            }
        }
        #endregion

        #endregion

        #region Module CRUD

        #region Get all module 
        [HttpGet, Route("{appName}")]
        public IHttpActionResult GetModules(string appName)
        {
            try
            {
                ModuleController controller = new ModuleController();
                List<Module> modules = controller.GetModules(appName);
                if (modules.Count <= 0)
                {
                    return BadRequest($"Cannot find modules for: {appName}");
                }
                string response = ToXML(modules);
                return Ok(response);
            }
            catch (Exception exception)
            {
                return InternalServerError(exception);
            }
        }
        #endregion

        #region Get an module by id
        [HttpGet, Route("{appName}/{id:int}")]
        public IHttpActionResult GetModuleById(string appName, int id)
        {
            try
            {
                ModuleController controller = new ModuleController();
                Module module = controller.GetModule(id, appName);
                emptyOrNull(module);
                string response = ToXML(module);
                return Ok(response);
            }
            catch (Exception exception)
            {
                return InternalServerError(exception);
            }
        }
        #endregion

        #region Post a new module
        [HttpPost, Route("{appName}")]
        public IHttpActionResult PostModule(string appName, [FromBody] XElement xml)
        {
            if (xml == null)
            {
                return BadRequest(new XmlException("Errors in the XML document").ToString());
            }
            XMLValidator validator = new XMLValidator(xml);

            if (!validator.ValidateXML())
            {
                return BadRequest(validator.ValidationMessage);
            }

            string res_type = validator.resType;

            Module mod = (Module)xmlconvertToModel(res_type, xml);

            try
            {
                emptyOrNull(mod);
                ModuleController controller = new ModuleController();
                bool response = controller.Create(mod, appName);
                if (!response)
                {
                    return BadRequest("Operation Failed");
                }
                return Ok("A new module was created");
            }
            catch (Exception exception)
            {
                return InternalServerError(exception);
            }
        }
        #endregion

        #region Put update an module
        [HttpPut, Route("{appName}")]
        public IHttpActionResult PutModule([FromBody] XElement xml)
        {
            if (xml == null)
            {
                return BadRequest(new XmlException("Errors in the XML document").ToString());
            }
            XMLValidator validator = new XMLValidator(xml);

            if (!validator.ValidateXML())
            {
                return BadRequest(validator.ValidationMessage);
            }

            string res_type = validator.resType;

            Module mod = (Module)xmlconvertToModel(res_type, xml);

            try
            {
                emptyOrNull(mod);
                ModuleController controller = new ModuleController();
                bool response = controller.Update(mod);
                if (!response)
                {
                    return BadRequest("Operation Failed");
                }
                return Ok("module was updated successfully!");
            }
            catch (Exception exception)
            {
                return InternalServerError(exception);
            }
        }
        #endregion

        #region Delete an Module
        [HttpDelete, Route("{appName}")]
        public IHttpActionResult DeleteModule([FromBody] XElement xml)
        {
            if (xml == null)
            {
                return BadRequest(new XmlException("Errors in the XML document").ToString());
            }
            XMLValidator validator = new XMLValidator(xml);

            if (!validator.ValidateXML())
            {
                return BadRequest(validator.ValidationMessage);
            }

            string res_type = validator.resType;

            Module mod = (Module)xmlconvertToModel(res_type, xml);
            try
            {
                ModuleController controller = new ModuleController();
                bool response = controller.Delete(mod.Name);
                if (!response)
                {
                    return BadRequest("Operation Failed");
                }
                return Ok("module was deleted");
            }
            catch (Exception exception)
            {
                return InternalServerError(exception);
            }

        }
        #endregion

        #endregion

        #region Data/Subscrition CRUD

        #region Post a new Data
        [HttpPost, Route("{appName}/{modName}")]
        public IHttpActionResult PostData(string modName, [FromBody] XElement xml)
        {
            if (xml == null)
            {
                return BadRequest(new XmlException("Errors in the XML document").ToString());
            }
            XMLValidator validator = new XMLValidator(xml);

            if (!validator.ValidateXML())
            {
                return BadRequest(validator.ValidationMessage);
            }

            string res_type = validator.resType;

            switch (res_type)
            {
                case "Data":
                    Data data = (Data)xmlconvertToModel(res_type, xml);

                    try
                    {
                        emptyOrNull(data);
                        DataController controller = new DataController();
                        bool response = controller.Create(data, modName);
                        if (!response)
                        {
                            return BadRequest("Operation Failed");
                        }
                        //criar metodo notifyChannel para ir buscar endPoint  
                        /*
                          MqttClient mClient = new MqttClient(IPAddress.Parse(endpoint));
                           string[] mStrTopicsInfo = { "news", "complaints" };
                         */ 
                        //enviar notificacao para o canal (mosquitto)
                        return Ok("A new data was created");
                    }
                    catch (Exception exception)
                    {
                        return InternalServerError(exception);
                    }

                case "Subscription":
                    Subscription sub = (Subscription)xmlconvertToModel(res_type, xml);

                    try
                    {
                        emptyOrNull(sub);
                        SubscriptionController controller = new SubscriptionController();
                        bool response = controller.Create(sub, modName);
                        if (!response)
                        {
                            return BadRequest("Operation Failed");
                        }
                        return Ok("A new subscription was created");
                    }
                    catch (Exception exception)
                    {
                        return InternalServerError(exception);
                    }
                default:
                    return BadRequest("Operation Failed");
            }


        }
        #endregion

        #region Delete an Data
        [HttpDelete, Route("{appName}/{modName}")]
        public IHttpActionResult DeleteData([FromBody] XElement xml)
        {
            if (xml == null)
            {
                return BadRequest(new XmlException("Errors in the XML document").ToString());
            }
            XMLValidator validator = new XMLValidator(xml);

            if (!validator.ValidateXML())
            {
                return BadRequest(validator.ValidationMessage);
            }

            string res_type = validator.resType;

            switch (res_type)
            {
                case "Data":
                    Data data = (Data)xmlconvertToModel(res_type, xml);
                    try
                    {
                        emptyOrNull(data);
                        DataController controller = new DataController();
                        bool response = controller.Delete(data.Id);
                        if (!response)
                        {
                            return BadRequest("Operation Failed");
                        }
                        return Ok("data was deleted");
                    }
                    catch (Exception exception)
                    {
                        return InternalServerError(exception);
                    }

                case "Subscription":
                    Subscription sub = (Subscription)xmlconvertToModel(res_type, xml);
                    try
                    {
                        emptyOrNull(sub);
                        SubscriptionController controller = new SubscriptionController();
                        bool response = controller.Delete(sub.Id);
                        if (!response)
                        {
                            return BadRequest("Operation Failed");
                        }
                        return Ok("subscription was deleted");
                    }
                    catch (Exception exception)
                    {
                        return InternalServerError(exception);
                    }
                default:
                    return BadRequest("Operation Failed");
            }

        }
        #endregion

        #region Extra para defesa
        /*
        #region Get all data 
        [HttpGet, Route("{appName}/{modName}")]
        public IHttpActionResult GetData(string modName)
        {
            try
            {
                DataController data = new DataController();
                List<Data> response = data.GetDatas(modName);
                return Ok(response);
            }
            catch (Exception exception)
            {
                return InternalServerError(exception);
            }
        }
        #endregion
        #region Get an data by id
        [HttpGet, Route("{appName}/{modName}/{id:int}")]
        public IHttpActionResult GetdataById(int id)
        {
            try
            {
                DataController data = new DataController();
                Data response = data.GetData(id);
                return Ok(response);
            }
            catch (Exception exception)
            {
                return InternalServerError(exception);
            }
        }
        #endregion
        #region Put update an data
        [HttpPut, Route("{appName}/{modName}")]
        public IHttpActionResult PutData([FromBody] XElement form)
        {
            Data model = (Data)xmlconvertToModel("data", form);
            modelNull(model);
            modelNotValid(model, "data");

            try
            {
                DataController data = new DataController();
                bool response = data.Update(model);
                if (!response)
                {
                    return BadRequest("Operation Failed");
                }
                return Ok("Application was updated successfully!");
            }
            catch (Exception exception)
            {
                return InternalServerError(exception);
            }
        }
        #endregion
        */
                        #endregion

                        #endregion

                    }
}
