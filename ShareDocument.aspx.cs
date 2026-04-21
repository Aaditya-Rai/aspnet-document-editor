using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sem4_Project
{
    public partial class ShareDocument : System.Web.UI.Page
    {
        SqlConnection mycon = new SqlConnection(
        "Data Source=DESKTOP-3D7519J;Initial Catalog=project;Integrated Security=True;");

        int docID;

        protected void Page_Load(object sender, EventArgs e)
        {
            docID = Convert.ToInt32(Request.QueryString["id"]);

            if (!IsPostBack)
            {
                LoadUsers();

            }
        }

        void LoadUsers()
        {
            string q = "SELECT UserID, Username FROM Users";

            SqlDataAdapter da = new SqlDataAdapter(q, mycon);
            DataTable dt = new DataTable();
            da.Fill(dt);

            ddlUsers.DataSource = dt;
            ddlUsers.DataTextField = "Username";
            ddlUsers.DataValueField = "UserID";
            ddlUsers.DataBind();
        }

        protected void btnShare_Click(object sender, EventArgs e)
        {
            int userID = Convert.ToInt32(ddlUsers.SelectedValue);
            string permission = ddlPermission.SelectedValue;

            string q = "INSERT INTO DocumentAccess (DocumentID, UserID, Permission) VALUES (@d,@u,@p)";

            SqlCommand cmd = new SqlCommand(q, mycon);

            cmd.Parameters.AddWithValue("@d", docID);
            cmd.Parameters.AddWithValue("@u", userID);
            cmd.Parameters.AddWithValue("@p", permission);

            mycon.Open();
            cmd.ExecuteNonQuery();
            mycon.Close();

            lblMsg.Text = "Document Shared Successfully!";
        }
    }
}