using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Tienda.MasterPage
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public new string ResolveUrl(string link)
        {
            return this.ResolveClientUrl(link);
        }

        

        protected void lnkCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Session.Clear();
            this.Session.Abandon();
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }
    }
}