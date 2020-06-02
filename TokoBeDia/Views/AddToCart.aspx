<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/General.Master" AutoEventWireup="true" CodeBehind="AddToCart.aspx.cs" Inherits="TokoBeDia.Views.AddToCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div>
         <br /><br />
        <asp:Label Width="150px" runat="server" Text="Name"></asp:Label>
        <asp:Label Width="150px" runat="server" ID="Name"></asp:Label>
        <br /><br />
        <asp:Label Width="150px" runat="server" Text="Price"></asp:Label>
        <asp:Label Width="150px" runat="server" ID="Price"></asp:Label>
        <br /><br />
        <asp:Label Width="150px" runat="server" Text="Stock"></asp:Label>
        <asp:Label Width="150px" runat="server" ID="Stock"></asp:Label>
        <br /><br />
        <asp:Label Width="150px" runat="server" Text="Product Type"></asp:Label>
        <asp:Label Width="150px" runat="server" ID="ProductTypeLabel"></asp:Label>
        <br /><br />
        <asp:Label Width="150px" runat="server" Text="Quantity"></asp:Label>
        <asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="txtQuantityValidator" runat="server" ErrorMessage="Please input integers only" CssClass="validate" ControlToValidate="txtQuantity" ValidationExpression="\d+"></asp:RegularExpressionValidator> 
        <br /><br />
       
        <asp:Button ID="btnSubmit" runat="server" Text="Add" OnClick="btnAdd_Click"/>
        <br /><br />
        <asp:Label ID="lblErrorSubmit" runat="server" Text="Please input a valid quantity" CssClass="validate"></asp:Label>

    </div>
</asp:Content>
