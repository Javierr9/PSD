<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/General.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TokoBeDia.Views.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Login</h2>
    <br />

    <div>
        <asp:Label Width="150px" runat="server" Text="Email"></asp:Label>
        <asp:TextBox ID="txtEmail" runat="server" TextMode="Email"></asp:TextBox>
        <asp:RequiredFieldValidator ID="reqEmail" runat="server" ControlToValidate="txtEmail" CssClass="validate" ErrorMessage="Enter a unique email"></asp:RequiredFieldValidator>
        <br /><br />

        <asp:Label Width="150px" runat="server" Text="Password"></asp:Label>
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="reqPassword" runat="server" ControlToValidate="txtPassword" CssClass="validate" ErrorMessage="Enter a password"></asp:RequiredFieldValidator>
        <br /><br />

        <asp:CheckBox ID="ckRememberMe" runat="server" />
        <asp:Label runat="server" Text="Remember Me"></asp:Label>
        <br /><br />

        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
        <asp:Label ID="lblErrorLogin" runat="server" Text="" CssClass="validate"></asp:Label>
    </div>
</asp:Content>
