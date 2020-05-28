<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/General.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="TokoBeDia.Views.ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Change Password</h2>
    <br />

    <div>
        <asp:Label Width="150px" runat="server" Text="Old Password"></asp:Label>
        <asp:TextBox ID="txtOldPassword" runat="server" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="reqOldPassword" runat="server" ControlToValidate="txtOldPassword" CssClass="validate" ErrorMessage="Must be filled"></asp:RequiredFieldValidator>
        <asp:Label ID="lblErrorChange" runat="server" Text="" CssClass="validate"></asp:Label>
        <br /><br />

        <asp:Label Width="150px" runat="server" Text="New Password"></asp:Label>
        <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="reqNewPassword" runat="server" ControlToValidate="txtNewPassword" CssClass="validate" ErrorMessage="Must be filled"></asp:RequiredFieldValidator>
        <asp:Label ID="lblErrorNewPassword" runat="server" Text="" CssClass="validate"></asp:Label>
        <br /><br />

        <asp:Label Width="150px" runat="server" Text="Confirm Password"></asp:Label>
        <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="reqConfirmPassword" runat="server" ControlToValidate="txtConfirmPassword" CssClass="validate" ErrorMessage="Must be filled"></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="compPassword" runat="server" ControlToCompare="txtNewPassword" ControlToValidate="txtConfirmPassword" CssClass="validate" ErrorMessage="Password must be same"></asp:CompareValidator>
        <br /><br />

        <asp:Button ID="btnChange" runat="server" Text="Change" OnClick="btnChange_Click" />
        <asp:Label ID="lblSuccess" runat="server" Text="Succesfully changed" CssClass="success" Visible="false"></asp:Label>
    </div>
</asp:Content>
