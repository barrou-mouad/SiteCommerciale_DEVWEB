using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
namespace GestionCmd
{
    public partial class LoginAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Boolean flag = false;
            string source = "server=localhost ;integrated security=SSPI;database=Monprojet";
            SqlConnection con = new SqlConnection(source);
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(1) from Admin where email=@em and password=@pass", con);
            cmd.Parameters.Add(new SqlParameter("@em", TextBox1.Text));
            cmd.Parameters.Add(new SqlParameter("@pass", TextBox2.Text));
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count == 1)
            {
               
               
                flag = true;
                con.Close();
                Session["isloged"] = "ok";
                Response.Redirect("Gcategorie.aspx");
            }
            if (!flag) Label1.Text = "Email ou password invalide";
        }
    }
    }
