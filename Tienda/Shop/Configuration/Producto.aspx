<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site1.Master" AutoEventWireup="true" CodeBehind="Producto.aspx.cs" Inherits="Tienda.Shop.Configuration.Producto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitlePage" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:FormView ID="FormView1" runat="server" DataKeyNames="Expr1" DataSourceID="SqlDataSource1">
        <EditItemTemplate>
            Expr1:
            <asp:Label ID="Expr1Label1" runat="server" Text='<%# Eval("Expr1") %>' />
            <br />
            Expr2:
            <asp:TextBox ID="Expr2TextBox" runat="server" Text='<%# Bind("Expr2") %>' />
            <br />
            Expr3:
            <asp:TextBox ID="Expr3TextBox" runat="server" Text='<%# Bind("Expr3") %>' />
            <br />
            Expr4:
            <asp:TextBox ID="Expr4TextBox" runat="server" Text='<%# Bind("Expr4") %>' />
            <br />
            Expr5:
            <asp:TextBox ID="Expr5TextBox" runat="server" Text='<%# Bind("Expr5") %>' />
            <br />
            Expr6:
            <asp:TextBox ID="Expr6TextBox" runat="server" Text='<%# Bind("Expr6") %>' />
            <br />
            <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Actualizar" />
            &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancelar" />
        </EditItemTemplate>
        <InsertItemTemplate>
            Expr2:
            <asp:TextBox ID="Expr2TextBox" runat="server" Text='<%# Bind("Expr2") %>' />
            <br />
            Expr3:
            <asp:TextBox ID="Expr3TextBox" runat="server" Text='<%# Bind("Expr3") %>' />
            <br />
            Expr4:
            <asp:TextBox ID="Expr4TextBox" runat="server" Text='<%# Bind("Expr4") %>' />
            <br />
            Expr5:
            <asp:TextBox ID="Expr5TextBox" runat="server" Text='<%# Bind("Expr5") %>' />
            <br />
            Expr6:
            <asp:TextBox ID="Expr6TextBox" runat="server" Text='<%# Bind("Expr6") %>' />
            <br />
            <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insertar" />
            &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancelar" />
        </InsertItemTemplate>
        <ItemTemplate>
            Expr1:
            <asp:Label ID="Expr1Label" runat="server" Text='<%# Eval("Expr1") %>' />
            <br />
            Expr2:
            <asp:Label ID="Expr2Label" runat="server" Text='<%# Bind("Expr2") %>' />
            <br />
            Expr3:
            <asp:Label ID="Expr3Label" runat="server" Text='<%# Bind("Expr3") %>' />
            <br />
            Expr4:
            <asp:Label ID="Expr4Label" runat="server" Text='<%# Bind("Expr4") %>' />
            <br />
            Expr5:
            <asp:Label ID="Expr5Label" runat="server" Text='<%# Bind("Expr5") %>' />
            <br />
            Expr6:
            <asp:Label ID="Expr6Label" runat="server" Text='<%# Bind("Expr6") %>' />
            <br />
            <asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New" Text="Nuevo" />
        </ItemTemplate>
    </asp:FormView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:shopConnectionString %>" InsertCommand="INSERT INTO Products(Title, Description, Url, Price) VALUES (@title,@description,@url,@price)" SelectCommand="SELECT id_Product AS Expr1, Title AS Expr2, Description AS Expr3, Url AS Expr4, Price AS Expr5, Stars AS Expr6 FROM Products">
        <InsertParameters>
            <asp:Parameter Name="title" />
            <asp:Parameter Name="description" />
            <asp:Parameter Name="url" />
            <asp:Parameter Name="price" />
        </InsertParameters>
    </asp:SqlDataSource>
</asp:Content>
