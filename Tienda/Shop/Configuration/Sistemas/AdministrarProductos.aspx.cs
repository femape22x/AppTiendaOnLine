using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using TecnoShop.Model.Repository;
using System.Text;

namespace Tienda.Shop.Configuration.Sistemas
{
    public partial class AdministrarProductos : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLSERVER;Initial Catalog=Tienda;User ID=admin;Password=12345");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!HttpContext.Current.User.IsInRole("administrador"))
            {
                Response.Redirect("~/Shop/Products.aspx");
            }
            if (!IsPostBack)
            {
                TextBox1.Attributes.Add("placeholder", "Digite Nombre...");
                TextBox2.Attributes.Add("placeholder", "Digite Descripción...");
                TextBox3.Attributes.Add("placeholder", "Digite Url...");
                TextBox4.Attributes.Add("placeholder", "Digite Precio...");
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                TecnoShop.Model.Entities.Product product = new TecnoShop.Model.Entities.Product();
                product.Title = TextBox1.Text;
                product.Description = TextBox2.Text;
                product.Url = TextBox3.Text;
                product.Price = Convert.ToDecimal(TextBox4.Text);
                product.Stars = Convert.ToInt16(0);
                RepositoryFactory.GetProductRepository().Create(product);
                grvListaProductos.DataBind();

                Mensaje("Producto registrado exitosamente...");
                LimpiarCampos();
            }
            catch (FormatException)
            {
                Mensaje("El campo precio solo recive valores númericos...");
            }
        }

        protected void Mensaje(string mensaje)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<script type='text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(mensaje);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
        }

        protected void LimpiarCampos()
        {
            TextBox1.Text = string.Empty;
            TextBox2.Text = string.Empty;
            TextBox3.Text = string.Empty;
            TextBox4.Text = string.Empty;
        }
    }
}