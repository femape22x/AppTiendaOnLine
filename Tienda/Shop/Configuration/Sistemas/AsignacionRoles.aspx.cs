using System;
using System.Collections.Generic;
using System.Configuration.Provider;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tienda.Shop.Configuration.Sistemas
{
    public partial class AsignacionRoles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblInfo.Visible = false;
            if (!Page.IsPostBack)
            {
                // Bind the users and roles 
                ListaUsuarios();
                ListarRoles();
                VerificarRoles();
            }
        }

        protected void ListaUsuarios()
        {
            // Get all of the user accounts 
            MembershipUserCollection users = Membership.GetAllUsers();
            ddlUserList.DataSource = users;
            ddlUserList.DataBind();
        }

        protected void ListarRoles()
        {
            // Get all of the roles 
            string[] roles = Roles.GetAllRoles();
            repRoleList.DataSource = roles;
            repRoleList.DataBind();
        }

        protected void VerificarRoles()
        {
            foreach (RepeaterItem item in repRoleList.Items)
            {
                CheckBox RolesCheck = item.FindControl("cbxRoles") as CheckBox;
                RolesCheck.Checked = false;
            }

            string usuarioSeleccionado = ddlUserList.SelectedValue;
            string[] rolesUsuario = Roles.GetRolesForUser(usuarioSeleccionado);

            // Loop through the Repeater's Items and check or uncheck the checkbox as needed 
            foreach (RepeaterItem item in repRoleList.Items)
            {
                // Programmatically reference the CheckBox 
                CheckBox RoleCheckBox = item.FindControl("cbxRoles") as CheckBox;
                // See if RoleCheckBox.Text is in selectedUsersRoles 
                if (rolesUsuario.Contains<string>(RoleCheckBox.Text))
                    RoleCheckBox.Checked = true;
                else
                    RoleCheckBox.Checked = false;
            }
        }

        protected void ddlUserList_SelectedIndexChanged(object sender, EventArgs e)
        {
            VerificarRoles();
        }

        protected void cbxRoles_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                // Reference the CheckBox that raised this event 
                CheckBox RoleCheckBox = sender as CheckBox;

                // Get the currently selected user and role 
                string selectedUserName = ddlUserList.SelectedValue;
                string roleName = RoleCheckBox.Text;

                // Determine if we need to add or remove the user from this role 
                if (RoleCheckBox.Checked)
                {
                    // Add the user to the role 
                    Roles.AddUserToRole(selectedUserName, roleName);
                    // Display a status message 
                    lblInfo.Visible = true;
                    lblInfo.Text = string.Format("El Usuario {0} ha sido agregado al rol {1}:", selectedUserName, roleName);
                }
                else
                {
                    // Remove the user from the role 
                    Roles.RemoveUserFromRole(selectedUserName, roleName);
                    // Display a status message 
                    lblInfo.Visible = true;
                    lblInfo.Text = string.Format("El Usuario {0} ha sido eliminado del rol {1}:", selectedUserName, roleName);
                }
            }
            catch (ProviderException ex)
            {
                lblInfo.Text = ex.Message.ToString();
            }
        }

        protected void ddlUserList_TextChanged(object sender, EventArgs e)
        {
            VerificarRoles();
        }
    }
}