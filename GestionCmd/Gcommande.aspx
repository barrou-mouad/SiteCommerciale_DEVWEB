<%@ Page Title="" Language="C#" MasterPageFile="~/Master2.Master" AutoEventWireup="true" CodeBehind="Gcommande.aspx.cs" Inherits="GestionCmd.Gcommande" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container my-1">
    <asp:Label ID="Label1" runat="server" Text="Choisir Le client"></asp:Label>
&nbsp;<asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
    </asp:DropDownList>
    <br />
&nbsp;La liste des commandes de client :
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
&nbsp;<p>
        <asp:GridView ID="GridView1" CssClass="table text-center" runat="server" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" CellPadding="4" ForeColor="#333333" GridLines="None">
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
        <asp:Button ID="Button5" CssClass="btn btn-primary my-2" runat="server" Text="Ajouter une commande" OnClick="Button5_Click" /><br />
       <asp:Label ID="Label3" runat="server" Text=" La catégorie"></asp:Label>
        <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
        </asp:DropDownList>
&nbsp;   <asp:Label ID="Label4" runat="server" Text="Le produit"></asp:Label>
        <asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged">
        </asp:DropDownList><asp:Label ID="Label5" runat="server" Text="La Quantite"></asp:Label> <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>

        &nbsp;
        <asp:Button ID="Button3" runat="server" CssClass="btn btn-primary" OnClick="Button3_Click" Text="Ajouter" />
        <asp:Button ID="Button4" CssClass="btn btn-warning" runat="server" Text="Annuler" OnClick="Button4_Click" />
    </p>
        <p>
            
           
            
            
           
    </p>
        </div>
</asp:Content>
