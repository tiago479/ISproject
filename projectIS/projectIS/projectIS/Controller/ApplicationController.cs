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
    public class ApplicationController : ApiController
    {
        private List<Application> apps = new List<Application>();
        private SqlConnection conn = null;
        private Application app = null;

        private static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["projectIS.Properties.Settings.ConnDB"].ConnectionString;

        public ApplicationController()
        {
            this.apps = new List<Application>();
        }

        #region Get All
        public List<Application> GetApplications()
        {
            apps = new List<Application>();
            conn = new SqlConnection(connectionString);
            conn.Open();
            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Application", conn);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    app = new Application
                    {
                        Name = (string)reader["Name"],
                        Id = (int)reader["Id"],
                        Creation_dt = (string)reader["Creation_dt"]
                    };
                    apps.Add(app);

                }
                reader.Close();
                conn.Close();
            }
            catch (Exception exception)
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
                throw exception;
            }

            return apps;
        }
        #endregion

        #region Get by id
        public Application GetApplication(int id)
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
                        Creation_dt = (string)reader["Creation_dt"],
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

            return app;
        }
        #endregion

        #region Create Application
        public bool Create(Application app)
        {
            bool validation = false;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();

                string str = "INSERT INTO Application (Name, Creation_dt) values(@name, @Creation_dt)";
                SqlCommand command = new SqlCommand(str, conn);
                command.Parameters.AddWithValue("@name", app.Name);
                command.Parameters.AddWithValue("@Creation_dt", DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss"));
                int rows = command.ExecuteNonQuery();
                validation = rows > 0;
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

            return validation;
        }
        #endregion

        #region Put
        public bool Update(Application value)
        {
            bool validation = false;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();

                string str = "UPDATE Application set Name= @name WHERE Name = @appName";
                SqlCommand command = new SqlCommand(str, conn);
                command.Parameters.AddWithValue("@name", value.Name);
                command.Parameters.AddWithValue("@appName", value.OldName);
                int rows = command.ExecuteNonQuery();
                validation = rows > 0;
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
            return validation;
        }
        #endregion

        #region Delete
        public bool Delete(string name)
        {
            bool validation = false;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();

                string str = "DELETE FROM Application WHERE Name = @appName";
                SqlCommand command = new SqlCommand(str, conn);
                command.Parameters.AddWithValue("@appName", name);
                int rows = command.ExecuteNonQuery();
                validation = rows > 0;
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
            return validation;
        }
        #endregion
    }
}