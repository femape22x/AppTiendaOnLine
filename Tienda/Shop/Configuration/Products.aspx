<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site1.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="Tienda.Shop.Configuration.Products" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Lista Productos 
    <asp:GridView ID="GridView1" CssClass="table table-bordered table-responsive table-hover"  DataKeyNames="id_Product,Stars" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnRowDataBound="GridView1_RowDataBound">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="id_Product" HeaderText="id_Product" InsertVisible="False" ReadOnly="True" SortExpression="id_Product" />
            <asp:TemplateField HeaderText="Title" SortExpression="Title">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Title") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <strong><%# Eval("Title") %></strong>   
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Description" SortExpression="Description">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Description") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <%#GetFormatDescription(Eval("Description")) %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Price" SortExpression="Price">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Price") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                     <%#GetFormatPrice(Eval("Price")) %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Stars" SortExpression="Stars">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Stars") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <%#GetStars(Eval("Stars")) %>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
</asp:GridView>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:shopConnectionString %>" SelectCommand="SELECT [id_Product], [Title], [Description], [Price], [Stars] FROM [Products]"></asp:SqlDataSource>
</asp:Content>

<asp:Content ID="TitlePage" ContentPlaceHolderID="TitlePage" runat="server">
    <title>Productos</title>
</asp:Content>
