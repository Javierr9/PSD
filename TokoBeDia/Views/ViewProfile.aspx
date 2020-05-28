<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/General.Master" AutoEventWireup="true" CodeBehind="ViewProfile.aspx.cs" Inherits="TokoBeDia.Views.ViewProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Profile</h2>
    <br />

    <div>
        <asp:Label Width="150px" runat="server" Text="Email"></asp:Label>
        <asp:Label ID="lblEmail" runat="server"></asp:Label>
        <br /><br />
        <asp:Label Width="150px" runat="server" Text="Name"></asp:Label>
        <asp:Label ID="lblName" runat="server"></asp:Label>
        <br /><br />
        <asp:Label runat="server" Text="Gender" Width="150px"></asp:Label>
        <asp:Label ID="lblGender" runat="server"></asp:Label>
        <br /><br />
    </div>

    <div>
        <asp:Button ID="btnUpdateProfile" runat="server" Text="Update Profile" OnClick="btnUpdateProfile_Click" />
    </div>
</asp:Content>
