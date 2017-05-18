<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site1.Master" AutoEventWireup="true" CodeBehind="Cargar.aspx.cs" Inherits="Tienda.Shop.Configuration.Cargar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitlePage" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:FileUpload ID="FileUpload1" runat="server" />
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Subir" CssClass="btn btn-succes fa fa-file-excel-o"/>
</asp:Content>
