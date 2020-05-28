<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/General.Master" AutoEventWireup="true" CodeBehind="UpdateProductType.aspx.cs" Inherits="TokoBeDia.Views.UpdateProductType" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Update Product Type</h2>
    <br />

    <div>
        <asp:Label Width="150px" runat="server" Text="Product Type"></asp:Label>
        <asp:TextBox ID="txtProductType" runat="server" ></asp:TextBox>
        <asp:RequiredFieldValidator ID="reqProductType" runat="server" ControlToValidate="txtProductType" CssClass="validate" ErrorMessage="Must be filled"></asp:RequiredFieldValidator>
        <asp:Label ID="lblErrorProductType" runat="server" Text="Must be unique" CssClass="validate" Visible="false"></asp:Label>
        <br /><br />

        <asp:Label Width="150px" runat="server" Text="Description"></asp:Label>
        <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="reqDescription" runat="server" ControlToValidate="txtDescription" CssClass="validate" ErrorMessage="Must be filled"></asp:RequiredFieldValidator>
        <br /><br />

        <asp:Button ID="btnUpdateProductType" runat="server" Text="Update" OnClick="btnUpdateProductType_Click"/>
        <asp:Label ID="lblSuccess" runat="server" Text="Succesfully updated" CssClass="success" Visible="false"></asp:Label>
    </div>
</asp:Content>
