<%@ Page Title="" Language="C#" MasterPageFile="~/Master1.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="GestionCmd.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
<br />
<div class="container">
<asp:Label ID="Label1" runat="server" Text="Choisir une catégorie"></asp:Label> 
<asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
</asp:DropDownList><br /><br />

<div class="my-2"> catégorie choisis : <asp:Label ID="Label3" runat="server" Text=""></asp:Label> </div>
    <h3 class="text-center my-2">La liste des articles </h3>
<asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered text-center" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
<Columns>
<asp:ButtonField ButtonType="Button"  ControlStyle-CssClass="btn btn-primary text-center " CommandName="Select" Text="Commander" />
</Columns>
</asp:GridView>
<br />
<asp:Label ID="Label4" runat="server" Text="Donner la Quantité "></asp:Label>
&nbsp;<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;<asp:Button ID="Button3" runat="server" CssClass="btn btn-success" OnClick="Button3_Click" onClientClick="return Button3_Click();" Text="Valider" />
&nbsp;<asp:Button ID="Button4" runat="server" CssClass="btn btn-warning" Text="Annuler" />
<asp:Label ID="Label2" CssClass="alert alert-success" runat="server" Text="La commande est bien passée"></asp:Label>   
    </div>
    </p>

</asp:Content>
