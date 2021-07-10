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
    <asp:GridView ID="GridView1" CssClass="table text-center" runat="server" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit">
        <Columns>
            <asp:CommandField ButtonType="Button" ControlStyle-CssClass="btn btn-danger" ShowDeleteButton="True" />
            <asp:CommandField ButtonType="Button" ControlStyle-CssClass="btn btn-success" ShowEditButton="True" />
        </Columns>
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
