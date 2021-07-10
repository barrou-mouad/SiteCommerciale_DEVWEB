using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
namespace GestionCmd
{
    public partial class Gcategorie : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["isloged"] == null)
            {

                Response.Redirect("LoginAdmin.aspx");
            }
            string source = "server=localhost ;integrated security=SSPI;database=Monprojet";
            SqlConnection con = new SqlConnection(source);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Categorie", con);
            GridView1.DataSource = cmd.ExecuteReader();
            hide();
         
            if (!IsPostBack)
            {
                GridView1.DataBind();
            }
            con.Close();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string source = "server=localhost ;integrated security=SSPI;database=Monprojet";
            SqlConnection con = new SqlConnection(source);
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE from Categorie where id_cat="+ GridView1.Rows[e.RowIndex].Cells[2].Text, con);
;           cmd.ExecuteNonQuery();
            afficher();
        }
        protected void afficher()
        {
            string source = "server=localhost ;integrated security=SSPI;database=Monprojet";
            SqlConnection con = new SqlConnection(source);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Categorie", con);
            GridView1.DataSource = cmd.ExecuteReader();
            GridView1.DataBind();
            con.Close();

        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string source = "server=localhost ;integrated security=SSPI;database=Monprojet";
            SqlConnection con = new SqlConnection(source);
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Categorie set titre=@title where id_cat=@id", con);
            cmd.Parameters.Add(new SqlParameter("@title", (((TextBox)GridView1.Rows[e.RowIndex].Cells[3].Controls[0])).Text));
            cmd.Parameters.Add(new SqlParameter("@id", (((TextBox)GridView1.Rows[e.RowIndex].Cells[2].Controls[0])).Text));
            cmd.ExecuteNonQuery();
            GridView1.EditIndex = -1;          
            afficher();
            con.Close();
            
        }

        protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            GridView1.EditIndex = -1;
            afficher();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            afficher();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            afficher();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string source = "server=localhost ;integrated security=SSPI;database=Monprojet";
            SqlConnection con = new SqlConnection(source);
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Categorie(titre) values (@val)", con);
            cmd.Parameters.Add(new SqlParameter("@val", TextBox1.Text));
            cmd.ExecuteNonQuery();
            TextBox1.Text = "";
            hide();
            afficher();
        }
        protected void show()
        {
            Label1.Visible = true;
            Label2.Visible = true;
            Button3.Visible = true;
            TextBox1.Visible = true;
        }
        protected void hide()
        {
            Label1.Visible = false;
            Label2.Visible = false;
            Button3.Visible = false;
            TextBox1.Visible = false;
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            show();
        }
    }
}