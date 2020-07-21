<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/General.Master" AutoEventWireup="true" CodeBehind="TransactionHistoryPage.aspx.cs" Inherits="TokoBeDia.Views.TransactionHistoryPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>View Transaction History</h2>
    <br />

    <div>
        <asp:GridView ID="gridTransaction" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="UserName" HeaderText="User Name" ItemStyle-Width="150" Visible="false"/>
                <asp:BoundField DataField="Date" HeaderText="Transaction Date" ItemStyle-Width="150" />
                <asp:BoundField DataField="Type" HeaderText="Payment Type" ItemStyle-Width="150" />
                <asp:BoundField DataField="Name" HeaderText="Product Name" ItemStyle-Width="100" />
                <asp:BoundField DataField="Quantity" HeaderText="Product Quantity" ItemStyle-Width="100" />
                <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" ItemStyle-Width="100" />
            </Columns>
        </asp:GridView>

    </div>
</asp:Content>