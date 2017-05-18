using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TecnoShop.Model.Repository;

namespace Tienda
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Si es primera vez que inicia en la pagina
            if (!IsPostBack) 
            {
                this.Session.Clear();
                this.Session.Abandon();
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            
            string username = this.txtUsername.Value;
            string password = this.txtPassword.Value;

            IUserRepository repository = RepositoryFactory.GetUserRepository();

            TecnoShop.Model.Entities.User usuario = repository.FindUser(username, password);
            
            if (usuario != null)
            {
                this.Session.Add("usuario", usuario);
                Response.Redirect("~/Shop/Products.aspx");
            }
        }
    }
}