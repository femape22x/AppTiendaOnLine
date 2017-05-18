using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TecnoShop.Model.Repository;

namespace Tienda.Shop.Configuration
{
    public partial class Cargar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string ruta = Server.MapPath("..\\..\\csv\\" + FileUpload1.FileName);

            FileUpload1.SaveAs(ruta);

            using (var fs = File.OpenRead(ruta))
            using (var reader = new StreamReader(fs))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');

                    TecnoShop.Model.Entities.Product product = new TecnoShop.Model.Entities.Product();
                    product.Title = values[0];
                    product.Description = values[1];
                    product.Url = values[2];
                    product.Price = Convert.ToDecimal(values[3]);
                    product.Stars = Convert.ToInt16(values[4]);

                    RepositoryFactory.GetProductRepository().Create(product);
                }
            }
        }
    }
}