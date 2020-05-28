<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/General.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="TokoBeDia.Views.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Register</h2>
    <br />

    <div>
        <asp:Label Width="150px" runat="server" Text="Email"></asp:Label>
        <asp:TextBox ID="txtEmail" runat="server" TextMode="Email"></asp:TextBox>
        <asp:RequiredFieldValidator ID="reqEmail" runat="server" ControlToValidate="txtEmail" CssClass="validate" ErrorMessage="Enter a unique email"></asp:RequiredFieldValidator>
        <asp:Label ID="lblErrorEmail" runat="server" Text="Must be unique" CssClass="validate" Visible="false"></asp:Label>
        <br /><br />

        <asp:Label Width="150px" runat="server" Text="Name"></asp:Label>
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="reqName" runat="server" ControlToValidate="txtName" CssClass="validate" ErrorMessage="Enter a name"></asp:RequiredFieldValidator>
        <br /><br />

        <asp:Label Width="150px" runat="server" Text="Password"></asp:Label>
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="reqPassword" runat="server" ControlToValidate="txtPassword" CssClass="validate" ErrorMessage="Enter a password"></asp:RequiredFieldValidator>
        <br /><br />

        <asp:Label Width="150px" runat="server" Text="Confirm Password"></asp:Label>
        <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="reqConfirmPassword" runat="server" ControlToValidate="txtConfirmPassword" CssClass="validate" ErrorMessage="Confirm the password"></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="compPassword" runat="server" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" CssClass="validate" ErrorMessage="Password must be same"></asp:CompareValidator>
        <br /><br />

        <asp:Label runat="server" Text="Gender" Width="150px"></asp:Label>
        <asp:RequiredFieldValidator ID="reqGender" runat="server" ControlToValidate="rblGender" CssClass="validate" ErrorMessage="Choose a gender"></asp:RequiredFieldValidator>
        <asp:RadioButtonList ID="rblGender" runat="server" CssClass="radioButtonList">
            <asp:ListItem Text ="Male" />
            <asp:ListItem Text ="Female" />
        </asp:RadioButtonList>        
        <br /><br />

        <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />
    </div>
</asp:Content>
