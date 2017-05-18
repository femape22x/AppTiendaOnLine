<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site1.Master" AutoEventWireup="true" CodeBehind="AsignacionRoles.aspx.cs" Inherits="Tienda.Shop.Configuration.Sistemas.AsignacionRoles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitlePage" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="panel panel-default">
        <div class="panel-heading">Asignación de roles</div>
            <div class="panel-body">
                <p>
                <label>Seleccionar Usuario</label>
                <asp:DropDownList ID="ddlUserList" runat="server" OnTextChanged="ddlUserList_TextChanged" OnSelectedIndexChanged="ddlUserList_SelectedIndexChanged"></asp:DropDownList>
                </p>
                <br />
                <p>
                <label>Asignar Role</label>
                <br />
                <asp:Repeater ID="repRoleList" runat="server">
                    <ItemTemplate>
                        <asp:CheckBox ID="cbxRoles" runat="server" AutoPostBack="true" 
                             Text='<%# Container.DataItem %>' OnCheckedChanged="cbxRoles_CheckedChanged"/>
                        <br />
                    </ItemTemplate>
                </asp:Repeater>
                </p>
                <br />
                <asp:Label ID="lblInfo" runat="server" Text="" CssClass="alert alert-success"></asp:Label>
            </div>
        </div>
</asp:Content>
