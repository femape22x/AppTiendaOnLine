using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecnoShop.Model.Entities;

namespace TecnoShop.Model.Repository.Impl
{
    public class UserRepository : IUserRepository
    {
        public User FindUser(string userName, string password)
        {
            User user = null;
            if (string.IsNullOrEmpty(userName)) throw new ArgumentException("username is required");
            if (string.IsNullOrEmpty(password)) throw new ArgumentException("password is required");

            try
            {
                //0. Extraer cadena de conexion
                string connectionString = ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString;
                //1. Crear conexion
                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    //2. Abrir conexion
                    conexion.Open();

                    //3. Crear comando
                    SqlCommand cmd = conexion.CreateCommand();
                    //cmd.CommandText = "SELECT id_User,UserName,FirstName,SurName,LastName,Identification FROM Users WHERE UserName = @usuario AND Password = @clave";
                    //cmd.Parameters.AddWithValue("usuario", userName);
                    //cmd.Parameters.AddWithValue("clave", password);
                    
                    cmd.CommandText     = "dbo.Find_User";
                    cmd.CommandType     = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("userName", userName);
                    cmd.Parameters.AddWithValue("password", password);
                    
                    cmd.CommandTimeout  = 60;

                    //4. Crear cursor y ejecutar consulta
                    SqlDataReader reader = cmd.ExecuteReader();

                    //5. Recorrer el cursor con la informacion
                    while (reader.Read())
                    {
                        string idUser = Convert.ToString(reader["id_User"]);
                        string username = Convert.ToString(reader["UserName"]);
                        string firstName = Convert.ToString(reader["FirstName"]);
                        string surName = Convert.ToString(reader["SurName"]);
                        string lastName = Convert.ToString(reader["LastName"]);
                        string identification = Convert.ToString(reader["Identification"]);
                        //EntityFramework ORM ==> JPA

                        user = new User()
                        {
                            UserName = username,
                            FirstName = firstName,
                            SurName = surName,
                            LastName = lastName,
                            Identification = identification

                        };
                    }

                }
            }
            catch (Exception)
            {


            }

            return user;
        }
    }
}
