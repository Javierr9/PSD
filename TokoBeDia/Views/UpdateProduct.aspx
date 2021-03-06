﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/General.Master" AutoEventWireup="true" CodeBehind="UpdateProduct.aspx.cs" Inherits="TokoBeDia.Views.UpdateProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Update Product</h2>
    <br />

    <div>
        <%-- Had to made this for the product type sake :) --%>
        <asp:Label Width="150px" runat="server" Text="Product Type"></asp:Label>
        <asp:DropDownList ID="ddlProductType" runat="server" AutoPostBack="true"/>
        <br /><br />

        <asp:Label Width="150px" runat="server" Text="Name"></asp:Label>
        <asp:TextBox ID="txtName" runat="server" ></asp:TextBox>
        <asp:RequiredFieldValidator ID="reqName" runat="server" ControlToValidate="txtName" CssClass="validate" ErrorMessage="Must be filled"></asp:RequiredFieldValidator>
        <br /><br />

        <asp:Label Width="150px" runat="server" Text="Stock"></asp:Label>
        <asp:TextBox ID="txtStock" runat="server" TextMode="Number"></asp:TextBox>
        <asp:RequiredFieldValidator ID="reqStock" runat="server" ControlToValidate="txtStock" CssClass="validate" ErrorMessage="Must be filled"></asp:RequiredFieldValidator>
        <asp:Label ID="lblErrorStock" runat="server" Text="Input must be 1 or more" CssClass="validate" Visible="false"></asp:Label>
        <br /><br />

        <asp:Label Width="150px" runat="server" Text="Price"></asp:Label>
        <asp:TextBox ID="txtPrice" runat="server" TextMode="Number"></asp:TextBox>
        <asp:RequiredFieldValidator ID="reqPrice" runat="server" ControlToValidate="txtPrice" CssClass="validate" ErrorMessage="Must be filled"></asp:RequiredFieldValidator>
        <asp:Label ID="lblErrorPrice" runat="server" Text="Input must be above 1000 and multiply of 1000" CssClass="validate" Visible="false"></asp:Label>
        <br /><br />

        <asp:Button ID="btnUpdateProduct" runat="server" Text="Update" OnClick="btnUpdateProduct_Click"  />
        <asp:Label ID="lblSuccess" runat="server" Text="Succesfully updated" CssClass="success" Visible="false"></asp:Label>
    </div>
</asp:Content>
