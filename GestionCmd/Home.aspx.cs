using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
namespace GestionCmd
{
    public partial class Home : System.Web.UI.Page
    {
        int id_art;
        int id_cmd;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null) Response.Redirect("LoginClient.aspx");
            string source = "server=localhost ;integrated security=SSPI;database=Monprojet";
            SqlConnection con = new SqlConnection(source);
            con.Open();
            SqlCommand cmd = new SqlCommand("select id_article as 'numéro de commande',libelle as produit,pu as 'prix unitaire' from Article where id_cat=1", con);
            GridView1.DataSource= cmd.ExecuteReader();

                Label2.Visible = false;
                Label4.Visible = false;
                TextBox1.Visible = false;
                Button3.Visible = false;
                Button4.Visible = false;
                if (!IsPostBack) {
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
            SqlCommand cmd = new SqlCommand("select id_article as 'numéro de commande',libelle as produit,pu as 'prix unitaire'  from Article where id_cat=" + DropDownList1.SelectedValue + "", con);
            Label3.Text = DropDownList1.SelectedItem.Text;
            GridView1.DataSource = cmd.ExecuteReader();
            GridView1.DataBind();
            con.Close();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["id_art"] = Int16.Parse(GridView1.SelectedRow.Cells[1].Text);
            Label4.Visible = true;
            TextBox1.Visible = true;
            Button3.Visible = true;
            Button4.Visible = true;
            Response.Write(id_art);
            if (!IsPostBack) {
                id_art = Int16.Parse(GridView1.SelectedRow.Cells[1].Text);
                Label4.Visible = true;
                TextBox1.Visible = true;
                Button3.Visible = true;
                Button4.Visible = true;
                Response.Write(id_art);
            }

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
                if (Session["id"] == null) Response.Redirect("LoginClient.aspx");
                Object o = Session["id_art"];
                string source = "server=localhost ;integrated security=SSPI;database=Monprojet";
                SqlConnection con = new SqlConnection(source);
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into commande (date_cmd,id_client) values (@date,@client)", con);
                cmd.Parameters.Add(new SqlParameter("@date", DateTime.Now));
                cmd.Parameters.Add(new SqlParameter("@client", Session["id"].ToString() ));
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand("select max(id_cmd) from commande", con);
                id_cmd = Convert.ToInt32(cmd.ExecuteScalar());
                cmd = new SqlCommand("insert into contient(qte,id_article,id_cmd)  values ("+TextBox1.Text+","+o.ToString()+","+ id_cmd +")", con);
                cmd.ExecuteReader();
                con.Close();
                Label2.Visible = true;
        }
    }
} 