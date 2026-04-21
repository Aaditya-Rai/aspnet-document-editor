using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace sem4_Project
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        { 

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            SqlConnection mycon = new SqlConnection();
            mycon.ConnectionString = "Data Source=DESKTOP-3D7519J;Initial Catalog=project;Integrated Security=True;Pooling=False;Encrypt=False;";

            string q = "SELECT UserID FROM Users WHERE Username=@u AND Password=@p";
            SqlCommand cmd = new SqlCommand(q, mycon);

            cmd.Parameters.AddWithValue("@u", username);
            cmd.Parameters.AddWithValue("@p", password);

            mycon.Open();

            object result = cmd.ExecuteScalar();

            mycon.Close();

            if (result != null)
            {
                Session["UserID"] = Convert.ToInt32(result);
                Session["User"] = username;

                Response.Redirect("Default.aspx");
            }
            else
            {
                lblMessage.Text = "Invalid Username or Password!";
            }
            
        }
    }
}