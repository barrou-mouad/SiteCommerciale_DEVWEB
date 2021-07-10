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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] != null)
            {
                Response.Redirect("Home.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Boolean flag = false;
            string source = "server=localhost ;integrated security=SSPI;database=Monprojet";
            SqlConnection con = new SqlConnection(source);
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(1) from Client where email=@em and password=@pass", con);
            cmd.Parameters.Add(new SqlParameter("@em", TextBox1.Text));
            cmd.Parameters.Add(new SqlParameter("@pass", TextBox2.Text));
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count == 1) { 
            SqlDataAdapter sda = new SqlDataAdapter("select * from Client where email=@em and password=@pass", con);
            sda.SelectCommand.Parameters.AddWithValue("@em",  TextBox1.Text);
            sda.SelectCommand.Parameters.AddWithValue("@pass",TextBox2.Text);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DataRow dr= dt.Rows[0];

            Session["id"] = dr["id_client"].ToString();
            Session["nom"] = dr["nom"].ToString();
            Session["prenom"] = dr["prenom"].ToString();
            Session["email"] = dr["email"].ToString();
            Session["adresse"] = dr["adresse"].ToString();
            Response.Redirect("Home.aspx");
            flag = true;
            con.Close();
            }
            if (!flag) Label1.Text = "Email ou password invalide";
        }
          
          
} }
  

   
