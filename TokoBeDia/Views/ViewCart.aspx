<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/General.Master" AutoEventWireup="true" CodeBehind="ViewCart.aspx.cs" Inherits="TokoBeDia.Views.ViewCart" EnableEventValidation="False" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>View Cart</h2>
    <br />

    <div>
        <asp:Label ID="lblErrorDelete" runat="server" Text="The to-be-deleted product type cannot be referenced in another table in the database" CssClass="validate" Visible="false"></asp:Label>
        <asp:GridView ID="gridCart" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" ItemStyle-Width="40" />
                <asp:BoundField DataField="Name" HeaderText="Name" ItemStyle-Width="150" />
                <asp:BoundField DataField="Price" HeaderText="Price" ItemStyle-Width="100" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" ItemStyle-Width="100" />
                <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" ItemStyle-Width="100" />
                <asp:TemplateField >
                    <ItemTemplate>
                        <asp:Button ID="btnUpdate" Text="Update" runat="server" OnClick="btnUpdate_click" CausesValidation="False" />
                        <asp:Button ID="btnDelete" Text="Delete" runat="server" OnClick="btnDelete_click"  CausesValidation="False" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

        </asp:GridView>
        <br />
        <asp:Label ID="grandTotalLabel" runat="server" Font-bold ="true" />
        <br />


    </div>
</asp:Content>
