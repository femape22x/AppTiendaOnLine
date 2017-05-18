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
    public class ProductRepository : IProductRepository
    {
        public void Create(Product product)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString;

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
            
                SqlCommand cmd = conexion.CreateCommand();

                cmd.CommandText = "INSERT INTO Products (title,description,url,price,stars) VALUES(@title,@description,@url,@price,@stars)";

                cmd.Parameters.AddWithValue("title", product.Title);
                cmd.Parameters.AddWithValue("description", product.Description);
                cmd.Parameters.AddWithValue("url", product.Url);
                cmd.Parameters.AddWithValue("stars", product.Stars);
                cmd.Parameters.AddWithValue("price", product.Price);

                SqlDataReader reader = cmd.ExecuteReader();
            }
            
        }

        public List<Entities.Product> FindAll()
        {
            List<Product> lista = new List<Product>();

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
                    cmd.CommandText = "SELECT id_Product,Title,Description , Url , Price ,Stars FROM Products";

                    //4. Crear cursor y ejecutar consulta
                    SqlDataReader reader = cmd.ExecuteReader();

                    //5. Recorrer el cursor con la informacion
                    while (reader.Read())
                    {
                        string title        = Convert.ToString(reader["Title"]);
                        string description  = Convert.ToString(reader["Description"]);
                        string url          = Convert.ToString(reader["Url"]);
                        decimal price       = Convert.ToDecimal(reader["Price"]);
                        int stars = Convert.ToInt32(reader["Stars"]);

                        Product producto = new Product()
                        {
                            Title = title,
                            Description = description,
                            Url = url,
                            Price = price,
                            Stars = stars
                        };

                        lista.Add(producto);

                    }

                }
            }
            catch (Exception)
            {
                
                
            }
            return lista;
        }
    }
}
