<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/General.Master" AutoEventWireup="true" CodeBehind="ViewPaymentType.aspx.cs" Inherits="TokoBeDia.Views.ViewPaymentType" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>View Payment Type</h2>
    <br />

    <div>
        <asp:Label ID="lblErrorDelete" runat="server" Text="The to-be-deleted product type cannot be referenced in another table in the database" CssClass="validate" Visible="false"></asp:Label>
        <asp:GridView ID="gridPaymentType" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" ItemStyle-Width="50" />
                <asp:BoundField DataField="Type" HeaderText="Payment Type" ItemStyle-Width="200" />
                <asp:TemplateField>
                    <ItemStyle />
                    <ItemTemplate>
                        <asp:Button ID="btnUpdate" Text="Update" runat="server" OnClick="btnUpdate_Click"/>
                        <asp:Button ID="btnDelete" Text="Delete" runat="server" OnClick="btnDelete_Click"/>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br />

        <asp:Button ID="btnInsertPaymentType" runat="server" Text="Insert Payment Type" OnClick="btnInsertPaymentType_Click" />
    </div>
</asp:Content>
