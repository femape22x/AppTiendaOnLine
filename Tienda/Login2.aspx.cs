using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tienda
{
    public partial class Login2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                this.Session.Clear();
                this.Session.Abandon();
                FormsAuthentication.SignOut();
            }
        }

        protected void Login1_LoggedIn(object sender, EventArgs e)
        {
            Response.Redirect("~/Shop/Products.aspx");
        }
    }
}