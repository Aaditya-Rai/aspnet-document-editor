using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sem4_Project
{
    public partial class register : System.Web.UI.Page
    {
         
        SqlConnection mycon = new SqlConnection(
        "Data Source=DESKTOP-3D7519J;Initial Catalog=project;Integrated Security=True;");

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string confirm = txtConfirm.Text.Trim();

             
            if (username == "" || password == "")
            {
                lblMsg.Text = "Please fill all fields!";
                return;
            }

            if (password != confirm)
            {
                lblMsg.Text = "Passwords do not match!";
                return;
            }

            // 🔴 Check if user exists
            string checkQ = "SELECT COUNT(*) FROM Users WHERE Username=@u";
            SqlCommand checkCmd = new SqlCommand(checkQ, mycon);
            checkCmd.Parameters.AddWithValue("@u", username);

            mycon.Open();
            int count = (int)checkCmd.ExecuteScalar();
            mycon.Close();

            if (count > 0)
            {
                lblMsg.Text = "Username already exists!";
                return;
            }

           
            string q = "INSERT INTO Users (Username, Password) VALUES (@u,@p)";
            SqlCommand cmd = new SqlCommand(q, mycon);

            cmd.Parameters.AddWithValue("@u", username);
            cmd.Parameters.AddWithValue("@p", password);

            mycon.Open();
            cmd.ExecuteNonQuery();
            mycon.Close();

            lblMsg.ForeColor = System.Drawing.Color.Green;
            lblMsg.Text = "Registration successful!";

            
            Response.Redirect("Index.aspx");
        }
    }
}