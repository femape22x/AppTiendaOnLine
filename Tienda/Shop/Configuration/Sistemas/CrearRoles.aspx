<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site1.Master" AutoEventWireup="true" CodeBehind="CrearRoles.aspx.cs" Inherits="Tienda.Shop.Configuration.Sistemas.CrearRoles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitlePage" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="panel panel-default">
        <div class="panel-heading">Creacion de roles</div>
        <div class="panel-body">
            <label>Crear nuevo Role: </label>
            <asp:TextBox ID="txtRole" runat="server"></asp:TextBox>
            <asp:Button ID="btnCrearRole" runat="server" Text="Crear Role" CssClass="btn btn-succes" OnClick="btnCrearRole_Click" />
        </div>
     </div>

     <asp:GridView ID="RoleList" runat="server" AutoGenerateColumns="False" OnRowDeleting="RoleList_RowDeleting" CssClass="table table-bordered">
         <Columns>
             <asp:TemplateField HeaderText="Role">
                 <ItemTemplate>
                     <asp:Label ID="lblRole" runat="server" Text='<%# Container.DataItem %>'/>
                 </ItemTemplate>
             </asp:TemplateField>
             <asp:CommandField ShowDeleteButton="True" />
         </Columns>
     </asp:GridView>
</asp:Content>
