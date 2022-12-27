using projectIS.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Http;

namespace projectIS.Controller
{
    [RoutePrefix("api/somiod")]
    public class ModuleController : ApiController
    {
            SqlConnection conn = null;
            List<Module> mods = new List<Module>();
            Module mod = null;

        static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["projectIS.Properties.Settings.ConnDB"].ConnectionString;

        [HttpGet, Route("{appName}")]
        public IEnumerable<Module> GetModules(string appName)
        {
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Module WHERE ApplicationId in " +
                    "(SELECT Id FROM Application WHERE Name = @appName)", conn);
                command.Parameters.AddWithValue("@appName", appName);
                SqlDataReader reader = command.ExecuteReader(); 
                while (reader.Read())
                {
                    mod = new Module
                    {
                        Name = (string)reader["Name"],
                        Id = (int)reader["Id"],
                        Created_at = (string)reader["Created_at"],
                        ApplicationId = (int)reader["ApplicationId"]
                    };
                    mods.Add(mod);

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

            return mods;
        }

        /*
        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }
        */

        // POST api/<controller>
        [HttpPost, Route("{appName}")]
        public IHttpActionResult PostModule(string appName, [FromBody] Module mod)
        {
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();

                string str = "INSERT INTO Module (Name, Created_at, ApplicationId) values(@name, @Created_at, " +
                    "(Select id From Application where name = @appName))";
                SqlCommand command = new SqlCommand(str, conn);
                command.Parameters.AddWithValue("@name", mod.Name);
                command.Parameters.AddWithValue("@Created_at", DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss"));
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

        [HttpPut, Route("{modName}")]
        public IHttpActionResult PutModule(string modName, [FromBody] Module mod)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();

                string str = "UPDATE Module set name= @name WHERE Name = @modName";
                SqlCommand command = new SqlCommand(str, conn);
                command.Parameters.AddWithValue("@name", mod.Name);
                command.Parameters.AddWithValue("@appName", modName);
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

        // DELETE api/<controller>/5
        [HttpDelete, Route("{modName}")]
        public IHttpActionResult DeleteModule(string modName)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();

                string str = "DELETE FROM Module WHERE Name = @modName";
                SqlCommand command = new SqlCommand(str, conn);
                command.Parameters.AddWithValue("@modName", modName);
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
    }
}