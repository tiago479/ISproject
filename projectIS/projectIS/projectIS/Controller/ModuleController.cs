using Newtonsoft.Json.Linq;
using projectIS.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;
using System.Xml.Linq;

namespace projectIS.Controller
{
    public class ModuleController : ApiController
    {
        private SqlConnection conn = null;
        private List<Module> mods = null;
        private Module mod = null;

        private static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["projectIS.Properties.Settings.ConnDB"].ConnectionString;
        public ModuleController()
        {
            this.mods = new List<Module>();
        }

        #region Get All
        public List<Module> GetModules(string name)
        {

            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Module WHERE Parent in " +
                    "(SELECT Id FROM Application WHERE Name = @appName)", conn);
                command.Parameters.AddWithValue("@appName", name);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    mod = new Module
                    {
                        Name = (string)reader["Name"],
                        Id = (int)reader["Id"],
                        Creation_dt = (string)reader["Creation_dt"],
                        Parent = (int)reader["Parent"]
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
                }
                throw ex;
            }

            return mods;
        }
        #endregion

        #region Get by id
        public Module GetModule(int id)
        {
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Module WHERE Id = @id ORDER BY Id", conn);
                command.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    mod = new Module
                    {
                        Name = (string)reader["Name"],
                        Id = (int)reader["Id"],
                        Creation_dt = (string)reader["Creation_dt"],
                        Parent = (int)reader["Parent"]
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
                }
                throw ex;
            }

            return mod;
        }
        #endregion

        #region Post
        public bool Create(Module mod, string name)
        {
            bool validation = false;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                string str = "INSERT INTO Module (Name, Creation_dt, Parent) values(@name, @Creation_dt, " +
                    "(Select Id From Application where Name = @appName))";
                SqlCommand command = new SqlCommand(str, conn);
                command.Parameters.AddWithValue("@name", mod.Name);
                command.Parameters.AddWithValue("@Creation_dt", DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss"));
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

        #region Put
        public bool Update(Module module)
        {
            bool validation = false;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();

                string str = "UPDATE Module set Name= @name WHERE Name = @appName";
                SqlCommand command = new SqlCommand(str, conn);
                command.Parameters.AddWithValue("@name", module.Name);
                command.Parameters.AddWithValue("@appName", module.OldName);
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
        
        public bool Delete(string name)
        {
            bool validation = false;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();

                string str = "DELETE FROM Module WHERE Name = @appName";
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
    }
}