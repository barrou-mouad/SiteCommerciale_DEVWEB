<%@ Page Title="" Language="C#" MasterPageFile="~/Master2.Master" AutoEventWireup="true" CodeBehind="Gcategorie.aspx.cs" Inherits="GestionCmd.Gcategorie" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div class="container">
    <p>
        <br />
    </p>
        <asp:GridView ID="GridView1" CssClass="table text-center" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdated="GridView1_RowUpdated" OnRowUpdating="GridView1_RowUpdating">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
        <asp:CommandField ControlStyle-CssClass="btn btn-danger" ButtonType="Button" ShowDeleteButton="True" />
        <asp:CommandField ButtonType="Button" ControlStyle-CssClass="btn btn-success" ShowEditButton="True" />
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
    <asp:Button ID="Button4" CssClass="my-3" runat="server" Text="Ajouter une catégorie" OnClick="Button4_Click" />
    <p>
        <asp:Label ID="Label1" runat="server" Text="L'ajout de Nouvelle Catégorie"></asp:Label>
&nbsp;</p>
    <asp:Label ID="Label2" runat="server" Text="Le titre de catégorie : "></asp:Label>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;  <asp:Button ID="Button3" runat="server" Text="Ajouter" CssClass="btn btn-primary" OnClick="Button3_Click" /><p>
       
    </p>
      </div>
</asp:Content>
