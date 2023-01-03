using projectIS.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace projectIS.Controller
{
    public class SubscriptionController : ApiController
    {
        private SqlConnection conn = null;
        private List<Subscription> subs = null;
        private Subscription sub = null;

        private static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["projectIS.Properties.Settings.ConnDB"].ConnectionString;
        public SubscriptionController()
        {
            this.subs = new List<Subscription>();
        }

        #region Post
        public bool Create(Subscription sub, string name)
        {
            bool validation = false;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();

                string str = "INSERT INTO Subscription (Name, Creation_dt, Event, EndPoint, Parent) values(@Name, @Creation_dt, @Event, @EndPoint, " +
                    "(Select Id From Module where Name = @modeName))";
                SqlCommand command = new SqlCommand(str, conn);
                command.Parameters.AddWithValue("@Name", sub.Name);
                command.Parameters.AddWithValue("@Event", sub.Event);
                command.Parameters.AddWithValue("@EndPoint", sub.EndPoint);
                //command.Parameters.AddWithValue("@EndPoint", "127.0.0.1");
                command.Parameters.AddWithValue("@Creation_dt", DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss"));
                command.Parameters.AddWithValue("@modeName", name);
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

                string str = "DELETE FROM Subscription WHERE Id = @Id";
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
    }
}