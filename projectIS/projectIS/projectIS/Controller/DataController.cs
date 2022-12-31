using projectIS.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace projectIS.Controller
{
    public class DataController : ApiController
    {
        private SqlConnection conn = null;
        private List<Data> datas = null;
        private Data data = null;

        private static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["projectIS.Properties.Settings.ConnDB"].ConnectionString;
        public DataController()
        {
            this.datas = new List<Data>();
        }
        
        #region Post
        public bool Create(Data data, string name)
        {
            bool validation = false;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                string str = "INSERT INTO Datas (Content, Creation_dt, Parent) values(@Content, @Creation_dt, " +
                    "(Select Id From Module where Name = @appName))";
                SqlCommand command = new SqlCommand(str, conn);
                command.Parameters.AddWithValue("@Content", data.Content);
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

        #region Delete
        public bool Delete(int id)
        {
            bool validation = false;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();

                string str = "DELETE FROM Datas WHERE Id = @Id";
                SqlCommand command = new SqlCommand(str, conn);
                command.Parameters.AddWithValue("@Id", id);
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

        #region Extra Defesa
        /*

        #region Put
        public bool Update(Data data)
        {
            bool validation = false;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();

                string str = "UPDATE Datas set Content = @Content WHERE Content = @OldContent";
                SqlCommand command = new SqlCommand(str, conn);
                command.Parameters.AddWithValue("@Content", data.Content);
                command.Parameters.AddWithValue("@OldContent", data.OldContent);
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

        #region Get All
        public List<Data> GetDatas(string name)
        {

            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Datas WHERE Parent in " +
                    "(SELECT Id FROM Module WHERE Name = @appName)", conn);
                command.Parameters.AddWithValue("@appName", name);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    data = new Data
                    {
                        Content = (string)reader["Content"],
                        Id = (int)reader["Id"],
                        Creation_dt = (string)reader["Creation_dt"],
                        Parent = (int)reader["Parent"]
                    };
                    datas.Add(data);

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

            return datas;
        }
        #endregion

        #region Get by id
        public Data GetData(int id)
        {
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Datas WHERE Id = @id ORDER BY Id", conn);
                command.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    data = new Data
                    {
                        Content = (string)reader["Content"],
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

            return data;
        }
        #endregion
        */
        #endregion
    }
}