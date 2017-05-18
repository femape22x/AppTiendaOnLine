using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tienda.Shop.Configuration
{
    public partial class Products : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        public String GetStars(object stars)
        {
            int limite = Convert.ToInt32(stars);
            int maximo = 5;
            int resultado = maximo - limite;

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

        public String GetFormatPrice(object price)
        {
            StringBuilder str = new StringBuilder();
            
            str.Append("$ " + string.Format("{0:n}", Convert.ToDecimal(price) / 100));
           
            return str.ToString();
        }

        public String GetFormatDescription(object description)
        {
            StringBuilder str = new StringBuilder();
            
            string  desc = Convert.ToString(description);
            
            String text = "";

            if (desc.Length > 15)
            {
                text = desc.Substring(0, 15) + "...";
            }
            else 
            {
                text = desc;
            }

            str.Append(text);
            
            return str.ToString();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType == DataControlRowType.DataRow)
            {
                string sStars = Convert.ToString(GridView1.DataKeys[e.Row.RowIndex].Values["Stars"]);

                int stars = 0;

                int.TryParse(sStars, out stars);

                string cssClass = "";

                if(stars <= 3)
                {
                    cssClass = "danger";
                }

                if (stars == 5)
                {
                    cssClass = "success";
                }

                e.Row.CssClass = cssClass;
            }
        }
    }
}