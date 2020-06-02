<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/General.Master" AutoEventWireup="true" CodeBehind="ViewProduct.aspx.cs" Inherits="TokoBeDia.Views.ViewProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">   
    <h2>View Product</h2>
    <br />

    <div>
        <asp:Label ID="lblErrorDelete" runat="server" Text="The to-be-deleted product type cannot be referenced in another table in the database" CssClass="validate" Visible="false"></asp:Label>
        <asp:GridView ID="gridProduct" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" ItemStyle-Width="40" />
                <asp:BoundField DataField="ProductTypeID" HeaderText="Product Type" ItemStyle-Width="100" />
                <asp:BoundField DataField="Name" HeaderText="Name" ItemStyle-Width="150" />
                <asp:BoundField DataField="Price" HeaderText="Price" ItemStyle-Width="100" />
                <asp:BoundField DataField="Stock" HeaderText="Stock" ItemStyle-Width="100" />
                <asp:TemplateField Visible="false">
                    <ItemTemplate>
                        <asp:Button ID="btnUpdate" Text="Update" runat="server" OnClick="btnUpdate_Click" />
                        <asp:Button ID="btnDelete" Text="Delete" runat="server" OnClick="btnDelete_Click"/>
                    </ItemTemplate>

                </asp:TemplateField>
                 <asp:TemplateField  >
                    <ItemTemplate>
                     <asp:Button ID="btnAddToCart" Text="Add To Cart" runat="server" OnClick="btnAddToCart_click"/>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br />

        <asp:Button ID="btnInsertProduct" runat="server" Text="Insert Product" OnClick="btnInsertProduct_Click" Visible="false" />
    </div>
    
</asp:Content>
