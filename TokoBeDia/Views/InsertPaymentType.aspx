<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/General.Master" AutoEventWireup="true" CodeBehind="InsertPaymentType.aspx.cs" Inherits="TokoBeDia.Views.InsertPaymentType" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Insert Payment Type</h2>
    <br />

    <div>
        <asp:Label Width="150px" runat="server" Text="Payment Type"></asp:Label>
        <asp:TextBox ID="txtPaymentType" runat="server" ></asp:TextBox>
        <asp:RequiredFieldValidator ID="reqPaymentType" runat="server" ControlToValidate="txtPaymentType" CssClass="validate" ErrorMessage="Must be filled"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "txtPaymentType" ID="regexPaymentType" ValidationExpression = "^[\s\S]{3,}$" runat="server" ErrorMessage="Must consists of 3 characters or more" CssClass="validate"></asp:RegularExpressionValidator>
        <asp:Label ID="lblErrorPaymentType" runat="server" Text="" CssClass="validate"></asp:Label>
        <br /><br />

        <asp:Button ID="btnInsertPaymentType" runat="server" Text="Insert" OnClick="btnInsertPaymentType_Click" />
    </div>
</asp:Content>
