using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Xml;
using System.Xml.Linq;
using projectIS.Model;

namespace projectIS.Controller
{
    [RoutePrefix("api/somiod")]
    public class ApplicationController : ApiController
    {
        List<Application> apps = new List<Application>();
        SqlConnection conn = null;
        Application app = null;

        static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["projectIS.Properties.Settings.ConnDB"].ConnectionString;

        #region READ ALL 

        [HttpGet, Route("")]
        public IEnumerable<Application> GetApplications()
        {
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Application ORDER BY Id", conn);
                SqlDataReader reader = command.ExecuteReader(); 
                while (reader.Read())
                {
                    app = new Application
                    {
                        Name = (string)reader["Name"],
                        Id = (int)reader["Id"],
                        Created_at = (string)reader["Created_at"],
                    };
                    apps.Add(app);

                }
                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                    Console.WriteLine(ex.Message);
                }

            }

            return apps;
        }

        #endregion

        #region READ BY ID

        // GET api/<controller>/5
        [HttpGet, Route("{id}")]
        public IHttpActionResult GetApplication(int id)
        {
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Application WHERE Id = @id ORDER BY Id", conn);
                command.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = command.ExecuteReader(); 

                if (reader.Read())
                {
                    app = new Application
                    {
                        Name = (string)reader["Name"],
                        Id = (int)reader["Id"],
                        Created_at = (string)reader["Created_at"],
                    };
                }
                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                    Console.WriteLine(ex.Message);
                }
            }

            return Ok(app);
        }

        #endregion

        #region CREATE

        // POST api/<controller>
        [HttpPost, Route("")]
        public IHttpActionResult PostApplication([FromBody] XElement app)
        {

            XElement xmlAppName = new XElement("app", from el in app.Elements() select el);
            string appName = xmlAppName.Value;

            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();

                string str = "INSERT INTO Application (Name, Created_at) values(@name, @Created_at)";
                SqlCommand command = new SqlCommand(str, conn);
                command.Parameters.AddWithValue("@name", appName);
                command.Parameters.AddWithValue("@Created_at", DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss"));
                int rows = command.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                    Console.WriteLine(ex.Message);
                }
            }
            return Ok();
        }

        #endregion

        #region UPDATE
        // PUT api/<controller>/5
        [HttpPut, Route("{appName}")]
        public IHttpActionResult PutApplication(string appName, [FromBody] Application ap)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();

                string str = "UPDATE Application set name= @name WHERE Name = @appName";
                SqlCommand command = new SqlCommand(str, conn);
                command.Parameters.AddWithValue("@name", ap.Name);
                command.Parameters.AddWithValue("@appName", appName);
                int rows = command.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                    Console.WriteLine(ex.Message);
                }
            }
            return Ok();
        }

        #endregion PUTS

        #region DELETE
        [HttpDelete, Route("{appName}")]
        public IHttpActionResult DeleteApplication(string appName)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();

                string str = "DELETE FROM Application WHERE Name = @appName";
                SqlCommand command = new SqlCommand(str, conn);
                command.Parameters.AddWithValue("@appName", appName);
                int rows = command.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                    Console.WriteLine(ex.Message);
                }
            }
            return Ok();
        }

        #endregion DELETES

    }

}