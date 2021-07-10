using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
namespace GestionCmd
{
    public partial class Garticle : System.Web.UI.Page
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
               SqlCommand cmd = new SqlCommand("select id_article,libelle,pu from Article where id_cat=1", con);
               GridView1.DataSource = cmd.ExecuteReader();
               hide();
               if (!IsPostBack)
               {
                GridView1.DataBind();
                con.Close();
                con = new SqlConnection(source);
                cmd = new SqlCommand("select * from Categorie", con);
                con.Open();
                DropDownList1.DataSource = cmd.ExecuteReader();
                DropDownList1.DataTextField = "titre";
                DropDownList1.DataValueField = "id_cat";
                DropDownList1.DataBind();
                Label3.Text = DropDownList1.SelectedItem.Text;

                con.Close();
               }
               con.Close();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string source = "server=localhost ;integrated security=SSPI;database=Monprojet";
            SqlConnection con = new SqlConnection(source);
            con.Open();
            SqlCommand cmd = new SqlCommand("select id_article,libelle,pu from Article where id_cat=" + DropDownList1.SelectedValue, con);
            GridView1.DataSource = cmd.ExecuteReader();
            GridView1.DataBind();
            Label3.Text = DropDownList1.SelectedItem.Text;
            con.Close();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string source = "server=localhost ;integrated security=SSPI;database=Monprojet";
            SqlConnection con = new SqlConnection(source);
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Article set libelle=@libelle , pu=@pu  where id_article=@id", con);
            cmd.Parameters.Add(new SqlParameter("@libelle", (((TextBox)GridView1.Rows[e.RowIndex].Cells[3].Controls[0])).Text));
            cmd.Parameters.Add(new SqlParameter("@pu", float.Parse((((TextBox)GridView1.Rows[e.RowIndex].Cells[4].Controls[0])).Text)));
            cmd.Parameters.Add(new SqlParameter("@id", (((TextBox)GridView1.Rows[e.RowIndex].Cells[2].Controls[0])).Text));
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
            SqlCommand cmd = new SqlCommand("DELETE from Article where id_article=" + GridView1.Rows[e.RowIndex].Cells[2].Text, con);
            ; cmd.ExecuteNonQuery();
            afficher();
        }

        protected void afficher()
        {

            string source = "server=localhost ;integrated security=SSPI;database=Monprojet";
            SqlConnection con = new SqlConnection(source);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Article where id_cat=" + DropDownList1.SelectedValue, con);
            GridView1.DataSource = cmd.ExecuteReader();
            GridView1.DataBind();
            con.Close();
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
            SqlCommand cmd = new SqlCommand("INSERT INTO Article(libelle,pu,id_cat) values (@libelle,@pu,@id_cat)", con);
            cmd.Parameters.Add(new SqlParameter("@libelle", TextBox1.Text));
            cmd.Parameters.Add(new SqlParameter("@pu",float.Parse( TextBox2.Text)));
            cmd.Parameters.Add(new SqlParameter("@id_cat", Int16.Parse(DropDownList1.SelectedValue)));
            cmd.ExecuteNonQuery();
            afficher();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            show();
        }
        protected void hide() {
            Label5.Visible = false;
            Label6.Visible = false;
            TextBox1.Visible = false;
            TextBox2.Visible = false;
            Button3.Visible = false;
            Button4.Visible = false;
        }
        protected void show()
        {
            Label5.Visible = true;
            Label6.Visible = true;
            TextBox1.Visible = true;
            TextBox2.Visible = true;
            Button3.Visible = true;
            Button4.Visible = true;
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            hide();
        }
    }
}