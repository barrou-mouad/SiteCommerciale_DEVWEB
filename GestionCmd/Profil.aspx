<%@ Page Title="" Language="C#" MasterPageFile="~/Master1.Master" AutoEventWireup="true" CodeBehind="Profil.aspx.cs" Inherits="GestionCmd.Profil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="table text-center my-4 container ">
    <tr>
        <td>
            Nom
        </td>
        <td>
             <asp:Label ID="nom" runat="server" Text="Label"></asp:Label>
        </td>
    </tr>
        <tr>
        <td>
            Prenom
        </td>
        <td>
             <asp:Label ID="prenom" runat="server" Text="Label"></asp:Label>
        </td>
    </tr>
            <tr>
        <td>
            email
        </td>
        <td>
             <asp:Label ID="email" runat="server" Text="Label"></asp:Label>
        </td>

    </tr>
        <tr>
        <td>
            Adresse
        </td>
        <td>
             <asp:Label ID="adresse" runat="server" Text="Label"></asp:Label>
        </td>

    </tr>
</table>
</asp:Content>
