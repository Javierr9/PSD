<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/General.Master" AutoEventWireup="true" CodeBehind="UpdatePaymentType.aspx.cs" Inherits="TokoBeDia.Views.UpdatePaymentType" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Update Payment Type</h2>
    <br />

    <div>
        <asp:Label Width="150px" runat="server" Text="Payment Type"></asp:Label>
        <asp:TextBox ID="txtPaymentType" runat="server" ></asp:TextBox>
        <asp:RequiredFieldValidator ID="reqProductType" runat="server" ControlToValidate="txtPaymentType" CssClass="validate" ErrorMessage="Must be filled"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "txtPaymentType" ID="regexProductType" ValidationExpression = "^[\s\S]{3,}$" runat="server" ErrorMessage="Must consists of 3 characters or more" CssClass="validate"></asp:RegularExpressionValidator>
        <asp:Label ID="lblErrorPaymentType" runat="server" Text="Must be unique" CssClass="validate" Visible="false"></asp:Label>
        <br /><br />

        <asp:Button ID="btnUpdatePaymentType" runat="server" Text="Update" OnClick="btnUpdatePaymentType_Click"/>
        <asp:Label ID="lblSuccess" runat="server" Text="Succesfully updated" CssClass="success" Visible="false"></asp:Label>
    </div>
</asp:Content>
