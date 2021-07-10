using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
namespace GestionCmd
{
    public partial class Profil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null)
            {

                Response.Redirect("LoginClient.aspx");
            }
            nom.Text = Session["nom"].ToString();
            prenom.Text = Session["prenom"].ToString();
            email.Text = Session["email"].ToString();
            adresse.Text = Session["adresse"].ToString();
        }
    }
}