using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
namespace GestionCmd
{
    public partial class Gcommande : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {   if (Session["isloged"] == null)
            {

                Response.Redirect("LoginAdmin.aspx");
            }
            string source = "server=localhost ;integrated security=SSPI;database=Monprojet";
            SqlConnection con = new SqlConnection(source);
            con.Open();
            SqlCommand cmd = new SqlCommand("select Commande.id_cmd as 'commande',libelle as produit,qte as quantite , date_cmd as date , titre as categorie from Article,Contient,Commande,Categorie where  Contient.id_cmd=Commande.id_cmd and Contient.id_article=Article.id_article and Contient.id_article=Article.id_article and Categorie.id_cat=Article.id_cat and id_client=1", con);
            GridView1.DataSource = cmd.ExecuteReader();
        
            if (!IsPostBack)
            {
                GridView1.DataBind();
                con.Close();
                hide();
                con = new SqlConnection(source);
                cmd = new SqlCommand("select id_client , CONCAT(nom,' ',prenom) as name from Client", con);
                con.Open();
                DropDownList1.DataSource = cmd.ExecuteReader();
                DropDownList1.DataTextField = "name";
                DropDownList1.DataValueField = "id_client";
                DropDownList1.DataBind();
                Label2.Text = DropDownList1.SelectedItem.Text;
                con.Close();
                con = new SqlConnection(source);
                con.Open();
                cmd = new SqlCommand("select * from Categorie", con);
                DropDownList2.DataSource=cmd.ExecuteReader();
                DropDownList2.DataTextField = "titre";
                DropDownList2.DataValueField = "id_cat";
                DropDownList2.DataBind();
                con.Close();
                con = new SqlConnection(source);
                con.Open();
                cmd = new SqlCommand("select * from Article", con);
                DropDownList3.DataSource = cmd.ExecuteReader();
                DropDownList3.DataTextField = "libelle";
                DropDownList3.DataValueField = "id_article";
                DropDownList3.DataBind();

                con.Close();
            }
            con.Close();
        }
        protected void afficher()
        {
            string source = "server=localhost ;integrated security=SSPI;database=Monprojet";
            SqlConnection con = new SqlConnection(source);
            con.Open();
            SqlCommand cmd = new SqlCommand("select  Commande.id_cmd as 'commande', libelle as produit,qte as quantite ,  date_cmd as date , titre as categorie from Article,Contient,Commande,Categorie where  Contient.id_cmd=Commande.id_cmd and Contient.id_article=Article.id_article and Contient.id_article=Article.id_article and Categorie.id_cat=Article.id_cat and id_client=" + DropDownList1.SelectedValue, con);
            GridView1.DataSource = cmd.ExecuteReader();
            GridView1.DataBind();
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string source = "server=localhost ;integrated security=SSPI;database=Monprojet";
            SqlConnection con = new SqlConnection(source);
            con.Open();
            SqlCommand cmd = new SqlCommand("select  Commande.id_cmd as 'commande', libelle as produit,qte as quantite , date_cmd as date from Article,Contient,Commande where  Contient.id_cmd=Commande.id_cmd and Contient.id_article=Article.id_article and id_client=" + DropDownList1.SelectedValue, con);
            GridView1.DataSource = cmd.ExecuteReader();
            GridView1.DataBind();
            Label2.Text = DropDownList1.SelectedItem.Text;
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string source = "server=localhost ;integrated security=SSPI;database=Monprojet";
            SqlConnection con = new SqlConnection(source);
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Contient set qte=@qte  where id_cmd=@id", con);
            cmd.Parameters.Add(new SqlParameter("@id", (((TextBox)GridView1.Rows[e.RowIndex].Cells[2].Controls[0])).Text));
            cmd.Parameters.Add(new SqlParameter("@qte", float.Parse((((TextBox)GridView1.Rows[e.RowIndex].Cells[4].Controls[0])).Text)));
            
            cmd.ExecuteNonQuery();
            GridView1.EditIndex = -1;
            afficher();
            con.Close();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            afficher();

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string source = "server=localhost ;integrated security=SSPI;database=Monprojet";
            SqlConnection con = new SqlConnection(source);
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE from Commande where id_cmd=" + GridView1.Rows[e.RowIndex].Cells[2].Text, con);
            ; cmd.ExecuteNonQuery();
            afficher();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex =-1;
            afficher();
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Write("hello");
            string source = "server=localhost ;integrated security=SSPI;database=Monprojet";
            SqlConnection con = new SqlConnection(source);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Article where id_cat="+DropDownList2.SelectedValue, con);
            DropDownList3.DataSource = cmd.ExecuteReader();
            DropDownList3.DataTextField = "libelle";
            DropDownList3.DataValueField = "id_article";
            DropDownList3.DataBind();
            
            con.Close();
        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string source = "server=localhost ;integrated security=SSPI;database=Monprojet";
            SqlConnection con = new SqlConnection(source);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into commande (date_cmd,id_client) values (@date,@client)", con);
            cmd.Parameters.Add(new SqlParameter("@date", DateTime.Now));
            cmd.Parameters.Add(new SqlParameter("@client", DropDownList1.SelectedValue));
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand("select max(id_cmd) from commande", con);
            int id_cmd = Convert.ToInt32(cmd.ExecuteScalar());
            cmd = new SqlCommand("insert into contient(qte,id_article,id_cmd)  values (" + TextBox1.Text + "," +DropDownList2.SelectedValue + "," + id_cmd + ")", con);
            cmd.ExecuteReader();
            con.Close();
            afficher();
        }
        protected void hide() {
            Label3.Visible = false;
            DropDownList2.Visible = false;
            Label4.Visible = false;
            DropDownList3.Visible = false;
            Label5.Visible = false;
            Button3.Visible = false;
            Button4.Visible = false;
            TextBox1.Visible = false;
        }
        protected void show() {
            Label3.Visible = true;
            DropDownList2.Visible = true;
            Label4.Visible = true;
            DropDownList3.Visible = true;
            Label5.Visible = true;
            Button3.Visible = true;
            Button4.Visible = true;
            TextBox1.Visible = true;
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            show();

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            hide();
        }
    }
    }
