using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
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

        [Route("")]
        public IEnumerable<Application> Get()
        {
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Application ORDER BY Id", conn);
                SqlDataReader reader = command.ExecuteReader(); // fazemos isto quando estamos a espera de dados, um insert ou update execute nonquery
                                                                //commamnd devolve data reader (tipo iterador)
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

        // GET api/<controller>/5
        [Route("{appName}")]
        public IHttpActionResult GetApplication(string appName)
        {
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Application WHERE Name = @appName ORDER BY Id", conn);
                command.Parameters.AddWithValue("@appName", appName);
                SqlDataReader reader = command.ExecuteReader(); // fazemos isto quando estamos a espera de dados, um insert ou update execute nonquery

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

        // POST api/<controller>
        [Route("")]
        public IHttpActionResult PostApplication([FromBody] Application app)
        {

            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();

                string str = "INSERT INTO Application (Name, Created_at) values(@name, @Created_at)";
                SqlCommand command = new SqlCommand(str, conn);
                command.Parameters.AddWithValue("@name", app.Name);
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

        // PUT api/<controller>/5
        [Route("{appName}")]
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


        [Route("{appName}")]
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
    }
}