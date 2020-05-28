<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/General.Master" AutoEventWireup="true" CodeBehind="ViewProductType.aspx.cs" Inherits="TokoBeDia.Views.ViewProductType" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>View Product Type</h2>
    <br />

    <div>
        <asp:Label ID="lblErrorDelete" runat="server" Text="The to-be-deleted product type cannot be referenced in another table in the database" CssClass="validate" Visible="false"></asp:Label>
        <asp:GridView ID="gridProductType" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" ItemStyle-Width="50" />
                <asp:BoundField DataField="Name" HeaderText="Product Type" ItemStyle-Width="100" />
                <asp:BoundField DataField="Description" HeaderText="Description" ItemStyle-Width="200" />
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

        <asp:Button ID="btnInsertProductType" runat="server" Text="Insert Product Type" OnClick="btnInsertProductType_Click"  />
    </div>
</asp:Content>
