using projectIS.Model;
using System;
using System.Collections.Generic;
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
        #region Global Method
        public RequestType xmlconvertToModel(string request,XElement xml)
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

        #region Application CRUD

        #region Get all applications 
        [HttpGet, Route("")]
        public IHttpActionResult GetApplications()
        {
            try
            {
                ApplicationController app = new ApplicationController();
                List<Application> response = app.GetApplications();
                return Ok(response);
            }
            catch (Exception exception)
            {
                return InternalServerError(exception);
            }
        }
        #endregion

        #region Get an application by id
        [HttpGet, Route("{id}")]
        public IHttpActionResult GetApplicationById(int id)
        {
            try
            {
                ApplicationController app = new ApplicationController();
                Application response = app.GetApplication(id);
                return Ok(response);
            }
            catch (Exception exception)
            {
                return InternalServerError(exception);
            }
        }
        #endregion

        #region Post a new application Aplication controller esta em xml
        [HttpPost, Route("")]
        public IHttpActionResult PostApplication([FromBody] XElement app)
        {
            Application model = (Application)xmlconvertToModel("application", app);

            if (model == null)
            {
                return BadRequest("Please provide the required information for this request.");
            }

            if (model.Res_type != "application")
            {
                return BadRequest("Request type is different from 'application'.");
            }

            try
            {
                ApplicationController application = new ApplicationController();
                bool response = application.Create(model);
                if (!response)
                {
                    return BadRequest("Operation Failed");
                }
                return Ok("A new application was stored with success!");
            }
            catch (Exception exception)
            {
                return InternalServerError(exception);
            }
        }
        #endregion

        #region Put update an application ERRO 405
        [HttpPut, Route("{appName}")]
        public IHttpActionResult PutApplication(string appName, [FromBody] Application model)
        {
            if (model == null)
            {
                return BadRequest("Please provide the required information for this request.");
            }
            try
            {
                ApplicationController app = new ApplicationController();
                bool response = app.Update(model, appName);
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
        [HttpDelete, Route("{appName}")]
        public IHttpActionResult DeleteApplication(string appName)
        {
            try
            {
                ApplicationController app = new ApplicationController();
                bool response = app.Delete(appName);
                if (!response)
                {
                    return BadRequest("Operation Failed");
                }
                return Ok("Application was deleted successfully!");
            }
            catch (Exception exception)
            {
                return InternalServerError(exception);
            }
        }
        #endregion

        #endregion

    }
}
       