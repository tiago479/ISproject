using projectIS.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;

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
                    Console.WriteLine(ex.Message);
                }

            }

            return mods;
        }
        /*
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

        
        public Module GetModule(int id)
        {
            try
            {
                Connect();
                SetSqlComand("SELECT * FROM modules WHERE Id=@id");
                Select(id);
                Disconnect();

                if (this.modules[0] == null)
                {
                    return null;
                }
                return this.modules[0];

            }
            catch (Exception)
            {
                //fechar ligação à DB
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    Disconnect();
                }
                return null;
                //return BadRequest();
            }
        }

        public int GetModuleByName(string name)
        {
            try
            {
                Connect();
                SetSqlComand("SELECT * FROM modules WHERE name = @name");
                SelectByName(name);
                Disconnect();

                return modules.Count() > 0 ? modules[0].Id : -1;
            }
            catch (Exception)
            {
                if (conn.State == System.Data.ConnectionState.Open) Disconnect();
                return -1;
            }
        }

        public bool Store(Module module, int parent_id)
        {
            try
            {
                Connect();

                string sql = "INSERT INTO modules VALUES (@Name, @Creation_dt, @Parent)";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@Name", module.Name);
                cmd.Parameters.AddWithValue("@Creation_dt", DateTime.Now);
                cmd.Parameters.AddWithValue("@Parent", parent_id);

                SetSqlComand(sql);

                int numRow = InsertOrUpdate(cmd);

                Disconnect();

                return numRow == 1;
            }
            catch (Exception)
            {
                if (conn.State == System.Data.ConnectionState.Open) Disconnect();
                return false;
            }
        }

        public bool UpdateModule(Module module, int id)
        {
            try
            {
                Connect();

                string sql = "UPDATE modules SET name = @Name, creation_dt = @Creation_dt WHERE id = @id";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@Name", module.Name);
                cmd.Parameters.AddWithValue("@Creation_dt", DateTime.Now);

                SetSqlComand(sql);

                int numRow = InsertOrUpdate(cmd);

                Disconnect();
                return numRow == 1;
            }
            catch (Exception)
            {
                if (conn.State == System.Data.ConnectionState.Open) Disconnect();
                return false;
            }
        }

        public bool DeleteModule(int id)
        {
            try
            {
                Connect();
                SetSqlComand("DELETE FROM modules WHERE id = @id");
                int numRow = Delete(id);
                Disconnect();

                return numRow == 1;
            }
            catch (Exception)
            {
                if (conn.State == System.Data.ConnectionState.Open) Disconnect();
                return false;
            }
        }

        public override void ReaderIterator(SqlDataReader reader)
        {
            this.modules = new List<Module>();
            while (reader.Read())
            {
                Module module = new Module
                {
                    Id = (int)reader["id"],
                    Name = (string)reader["name"],
                    Creation_dt = new DateTime(),//TODO: verificar data
                    Parent = (int)reader["parent"],
                };

                this.modules.Add(module);
            }
        }
               */
    }

}