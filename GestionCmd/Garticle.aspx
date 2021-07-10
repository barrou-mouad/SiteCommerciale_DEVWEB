<%@ Page Title="" Language="C#" MasterPageFile="~/Master2.Master" AutoEventWireup="true" CodeBehind="Garticle.aspx.cs" Inherits="GestionCmd.Garticle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <div class="container">
    <p>
        <br />
        <asp:Label ID="Label1" runat="server" Text="Choisir une catégorie  "></asp:Label> :     <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
    </asp:DropDownList>
    </p><asp:Label ID="Label2" CssClass="mx-2" runat="server" Text="La catégorie choisis :"></asp:Label> 
    &nbsp; <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
    <asp:GridView ID="GridView1" CssClass="table text-center" runat="server" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:CommandField ButtonType="Button" ControlStyle-CssClass="btn btn-danger" ShowDeleteButton="True" >
<ControlStyle CssClass="btn btn-danger"></ControlStyle>
            </asp:CommandField>
            <asp:CommandField ButtonType="Button" ControlStyle-CssClass="btn btn-success" ShowEditButton="True" >
<ControlStyle CssClass="btn btn-success"></ControlStyle>
            </asp:CommandField>
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
    <br />
<asp:Label ID="Label4" runat="server" Text="Ajouter une nouvelle Article"></asp:Label> &nbsp;<asp:Button ID="Button5" runat="server" CssClass="btn btn-success" Text="Ajouter" OnClick="Button5_Click" />
<br />
    <br />
    <p>
        <asp:Label ID="Label5" runat="server" Text="Libelle"></asp:Label>
&nbsp;&nbsp;
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;
        <asp:Label ID="Label6" runat="server" Text="prix unitaire"></asp:Label>
&nbsp;<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
&nbsp;<asp:Button ID="Button3" runat="server" CssClass="btn btn-primary" OnClick="Button3_Click" Text="Valider" />
&nbsp;<asp:Button ID="Button4" runat="server" CssClass="btn btn-warning" Text="Annuler" OnClick="Button4_Click" />
    </p>
        </div>

</asp:Content>
