using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace Tienda.Shop.Configuration.Sistemas
{
    public partial class CrearRoles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DisplayRolesInGrid();
            }
        }

        protected void RoleList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Get the RoleNameLabel
            Label RoleNameLabel = RoleList.Rows[e.RowIndex].FindControl("lblRole") as Label;

            // Delete the role
            Roles.DeleteRole(RoleNameLabel.Text, false);

            // Rebind the data to the RoleList grid
            DisplayRolesInGrid();
        }

        private void DisplayRolesInGrid()
        {
            RoleList.DataSource = Roles.GetAllRoles();
            RoleList.DataBind();
        }

        protected void btnCrearRole_Click(object sender, EventArgs e)
        {
            string role = this.txtRole.Text.Trim();

            if (!string.IsNullOrEmpty(role) && !Roles.RoleExists(role))
            {
                Roles.CreateRole(role);
                DisplayRolesInGrid();
            }

            this.txtRole.Text = string.Empty;
        }
    }
}