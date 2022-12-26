using SOMOID.core.Interfaces;
using SOMOID.core.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SOMOID.core.Services
{
    public class SomoidDB : ISomoidDB
    {
        private readonly string connectionString;
                 //string interpolation {0} é para colocar variaveis para uma string


        public SomoidDB(string connectionString, string dbName)
        {
            string atualDiretory = Directory.GetCurrentDirectory(); //buscar diretoria onde esta este servico
            var dbDiretory = Path.Combine(atualDiretory, "SOMOID.core", dbName);//junta duas string e mete como diretoria
            this.connectionString = String.Format(connectionString, dbDiretory); //format substitui {0} pelo parametros que quizermos
        }

        public string GetUserPassword(Guid originUser)
        {
            throw new NotImplementedException();
        }

        /*
public string GetUserPassword(Guid originUser)
{
   SqlConnection connection = new SqlConnection(connectionString);
   try
   {
       connection.Open();
       //AQUI METEMOS SELECT, UPDATES, DELETE ETC.....     AppA -> PostApp (SomoidHttpClient) -> SOMOID.API (PostApp) -> SomoidDB (InsertApp) 
       SqlCommand command = new SqlCommand(@"SELECT Password
                                             FROM [User] WHERE Id = @Id", connection);
       command.Parameters.AddWithValue("Id", originUser);
       using (SqlDataReader reader = command.ExecuteReader())
       {
           if (reader.Read())
           {
               password = reader.GetString(0);
           }
       }
   }
   catch (Exception ex)
   {
       connection.Close();
       return new VcardDBResultObject<string>
       {
           ErrorMessage = ex.Message,
           Success = false
       };
   }
   finally
   {
       connection.Close();
   }
   return new VcardDBResultObject<string>
   {
       Success = true,
       Result = password
   };
}
*/
        public Application CreateApplication(Application model)
        {
            var application = new Application();
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(@"INSERT INTO [application] (Id, Name, Created_at) VALUES(@Id, @Name, @Created_at)", connection);
                command.Parameters.AddWithValue("@Name", model.GetName());
                command.Parameters.AddWithValue("@Created_at", DateTime.UtcNow);

                var success = command.ExecuteNonQuery() > 0;

                if (!success)
                {
                    throw new Exception("Failed inserting on Application");
                }

                //implementar a class dos erros

            }
            catch (Exception ex)
            {
                connection.Close();
                //implementar a class dos erros 
            }
            finally
            {
                connection.Close();
            }
            return application;
        }
    }
}
