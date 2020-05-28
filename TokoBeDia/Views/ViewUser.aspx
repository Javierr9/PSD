<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/General.Master" AutoEventWireup="true" CodeBehind="ViewUser.aspx.cs" Inherits="TokoBeDia.Views.ViewUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>View User</h2>
    <br />

    <asp:Label runat="server" Text="You can't change your own data" ID="lblErrorChange" CssClass="validate" Visible="false"/>
    <div>
        <asp:GridView ID="gridUser" runat="server" AutoGenerateColumns="false" >
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" ItemStyle-Width="50" />
                <asp:BoundField DataField="RoleID" HeaderText="RoleID" ItemStyle-Width="50" />
                <asp:BoundField DataField="Email" HeaderText="Email" ItemStyle-Width="200" />
                <asp:BoundField DataField="Status" HeaderText="Status" ItemStyle-Width="100" />
                <asp:TemplateField>
                    <ItemStyle />
                    <ItemTemplate>
                        <asp:Button ID="btnChangeStatus" Text="Change Status" runat="server" OnClick="btnChangeStatus_Click"/>
                        <asp:Button ID="btnChangeRole" Text="Change Role" runat="server" OnClick="btnChangeRole_Click"/>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
