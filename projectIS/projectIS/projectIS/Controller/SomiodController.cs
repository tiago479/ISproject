using projectIS.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace projectIS.Controller
{
    [RoutePrefix("api/somiod")]
    public class SomiodController : ApiController
    {
        #region XML to model
        public RequestType xmlconvertToModel(string request, XElement xml)
        {
            XmlSerializer serializer = null;
            Application app = null;
            Module mod = null;
            Data data = null;
            Subscription sub = null;
            switch (request)
            {
                case "application":
                    app = new Application();
                    serializer = new XmlSerializer(typeof(Application));
                    return (Application)serializer.Deserialize(xml.CreateReader());
                case "module":
                    mod = new Module();
                    serializer = new XmlSerializer(typeof(Module));
                    return (Module)serializer.Deserialize(xml.CreateReader());
                case "data":
                    data = new Data();
                    serializer = new XmlSerializer(typeof(Data));
                    return (Data)serializer.Deserialize(xml.CreateReader());
                case "sub":
                    sub = new Subscription();
                    serializer = new XmlSerializer(typeof(Subscription));
                    return (Subscription)serializer.Deserialize(xml.CreateReader());
                default:
                    Console.WriteLine("Wrong request string");
                    return null;
            }
        }
        #endregion

        #region Bad Request Method
        public IHttpActionResult modelNull(RequestType model)
        {
            if (model == null)
            {
                return BadRequest("Bad data for the request.");
            }
            return null;
        }

        public IHttpActionResult modelNotValid(RequestType model, string type)
        {
            if (model.Res_type != type)
            {
                return BadRequest("Request type is not a " + type);
            }
            return null;
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
                ApplicationController app = new ApplicationController();
                List<Application> applications = app.GetApplications();
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
                ApplicationController app = new ApplicationController();
                Application application = app.GetApplication(id);
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
        public IHttpActionResult PostApplication([FromBody] XElement app)
        {
            //validar
            Application model = (Application)xmlconvertToModel("application", app);
            modelNull(model);
            modelNotValid(model, "application");
            
            try
            {
                ApplicationController application = new ApplicationController();
                bool response = application.Create(model);
                if (!response)
                {
                    return BadRequest("Operation Failed");
                }
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
        public IHttpActionResult PutApplication([FromBody] XElement app)
        {
            Application model = (Application)xmlconvertToModel("application", app);
            modelNull(model);
            modelNotValid(model, "application");

            try
            {
                ApplicationController application = new ApplicationController();
                bool response = application.Update(model);
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
        public IHttpActionResult DeleteApplication([FromBody] XElement applicationName)
        {
            Application model = (Application)xmlconvertToModel("application", applicationName);
            try
            {
                ApplicationController app = new ApplicationController();
                bool response = app.Delete(model.Name);
                if (!response)
                {
                    return BadRequest("Operation Failed");
                }
                return Ok("Application was deleted");
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
                ModuleController mod = new ModuleController();
                List<Module> response = mod.GetModules(appName);
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
        public IHttpActionResult GetModuleById(int id)
        {
            try
            {
                ModuleController mod = new ModuleController();
                Module response = mod.GetModule(id);
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
        public IHttpActionResult PostModule(string appName, [FromBody] XElement mod)
        {
            Module model = (Module)xmlconvertToModel("module", mod);
            modelNull(model);
            modelNotValid(model, "module");

            try
            {
                ModuleController module = new ModuleController();
                bool response = module.Create(model, appName);
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
        public IHttpActionResult PutModule([FromBody] XElement mod)
        {
            Module model = (Module)xmlconvertToModel("module", mod);
            modelNull(model);
            modelNotValid(model, "module");

            try
            {
                ModuleController module = new ModuleController();
                bool response = module.Update(model);
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

        #region Delete an Application
        [HttpDelete, Route("{appName}")]
        public IHttpActionResult DeleteModule([FromBody] XElement mod)
        {
            Module model = (Module)xmlconvertToModel("module", mod);
            try
            {
                ModuleController module = new ModuleController();
                bool response = module.Delete(model.Name);
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
        public IHttpActionResult PostData(string modName, [FromBody] XElement form)
        {
            Data model = (Data)xmlconvertToModel("data", form);
            modelNull(model);
            modelNotValid(model, "data");
            
            try
            {
                DataController data = new DataController();
                bool response = data.Create(model, modName);
                if (!response)
                {
                    return BadRequest("Operation Failed");
                }
                return Ok("A new data was created");
            }
            catch (Exception exception)
            {
                return InternalServerError(exception);
            }
        }
        #endregion

        #region Delete an Data
        [HttpDelete, Route("{appName}/{modName}")]
        public IHttpActionResult DeleteData([FromBody] XElement form)
        {
            Data model = (Data)xmlconvertToModel("data", form);
            modelNull(model);
            modelNotValid(model, "data");
            try
            {
                DataController data = new DataController();
                bool response = data.Delete(model.Id);
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
