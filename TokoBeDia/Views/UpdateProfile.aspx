<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/General.Master" AutoEventWireup="true" CodeBehind="UpdateProfile.aspx.cs" Inherits="TokoBeDia.Views.UpdateProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Update Profile</h2>
    <br />

    <div>
        <asp:Label Width="150px" runat="server" Text="Email"></asp:Label>
        <asp:TextBox ID="txtEmail" runat="server" TextMode="Email"></asp:TextBox>
        <asp:RequiredFieldValidator ID="reqEmail" runat="server" ControlToValidate="txtEmail" CssClass="validate" ErrorMessage="Must be filled"></asp:RequiredFieldValidator>
        <br /><br />

        <asp:Label Width="150px" runat="server" Text="Name"></asp:Label>
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="reqName" runat="server" ControlToValidate="txtName" CssClass="validate" ErrorMessage="Must be filled"></asp:RequiredFieldValidator>
        <br /><br />

        <asp:Label Width="150px" runat="server" Text="Gender"></asp:Label>
        <asp:RequiredFieldValidator ID="reqGender" runat="server" ControlToValidate="rblGender" CssClass="validate" ErrorMessage="Must be chosen"></asp:RequiredFieldValidator>
        <asp:RadioButtonList ID="rblGender" runat="server" CssClass="radioButtonList">
            <asp:ListItem Text ="Male" />
            <asp:ListItem Text ="Female" />
        </asp:RadioButtonList>   
        <br /><br />

        <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
        <asp:Label ID="lblSuccess" runat="server" Text="Succesfully updated" CssClass="success" Visible="false"></asp:Label>
    </div>
</asp:Content>
