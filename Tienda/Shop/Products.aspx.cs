using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using TecnoShop.Model.Repository;

namespace Tienda.Shop
{
    public partial class Products : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool estaAutenticado = Request.IsAuthenticated;
            MembershipUser user = Membership.GetUser();

            if (!IsPostBack)
            {
                List<TecnoShop.Model.Entities.Product> productos = RepositoryFactory.GetProductRepository().FindAll();
                this.rpt.DataSource = productos;
                this.rpt.DataBind();

            }
        }

        public String GetStars(object stars) 
        {
            int limite = Convert.ToInt32(stars);
            int maximo = 5;
            int resultado = maximo - limite;

            //
            StringBuilder str = new StringBuilder();

            for (int i = 1; i <= limite; i++)
            {
                str.Append("<span class='glyphicon glyphicon-star'></span>");
            }

            for (int i = 1; i <= resultado; i++)
            {
                str.Append("<span class='glyphicon glyphicon-star-empty'></span>");
            }
            return str.ToString();
        }
    }
}