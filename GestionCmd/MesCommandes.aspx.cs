using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
namespace GestionCmd
{
    public partial class MesCommandes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null)
            {

                Response.Redirect("LoginAdmin.aspx");
            }
            string source = "server=localhost ;integrated security=SSPI;database=Monprojet";
            SqlConnection con = new SqlConnection(source);
            con.Open();
            SqlCommand cmd = new SqlCommand("select libelle as produit,qte as quantite , pu*qte as prix , date_cmd as date from Article,Contient,Commande where  Contient.id_cmd=Commande.id_cmd and Contient.id_article=Article.id_article and id_cat=1 and id_client="+Session["id"].ToString(), con);
            GridView1.DataSource = cmd.ExecuteReader();

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
                Label2.Text = DropDownList1.SelectedItem.Text;

                con.Close();
            }
            con.Close();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string source = "server=localhost ;integrated security=SSPI;database=Monprojet";
            SqlConnection con = new SqlConnection(source);
            con.Open();
            SqlCommand cmd = new SqlCommand("select libelle as produit,qte as quantite , pu*qte as prix , date_cmd as date from Article,Contient,Commande where  Contient.id_cmd=Commande.id_cmd and Contient.id_article=Article.id_article and id_cat=" + DropDownList1.SelectedValue + "and id_client=" + Session["id"].ToString(), con);
            Label2.Text = DropDownList1.SelectedItem.Text;
            GridView1.DataSource = cmd.ExecuteReader();
            GridView1.DataBind();
            con.Close();
        }
    }
}