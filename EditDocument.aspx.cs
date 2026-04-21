using System;
using System.Data.SqlClient;

namespace sem4_Project
{
    public partial class EditDocument : System.Web.UI.Page
    {
        const string ConnStr =
            "Data Source=DESKTOP-3D7519J;Initial Catalog=project;Integrated Security=True;";

        int docID
        {
            get { return ViewState["docID"] != null ? (int)ViewState["docID"] : 0; }
            set { ViewState["docID"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                    docID = Convert.ToInt32(Request.QueryString["id"]);

                LoadDocument();

                string permission = GetPermission();
                if (permission == "View")
                {
                    txtContent.ReadOnly = true;
                    txtTitle.ReadOnly = true;
                    btnUpdate.Enabled = false;
                }
            }
        }

        void LoadDocument()
        {
            if (docID == 0) return;

            string q = "SELECT Title, Content FROM Documents WHERE DocumentID=@id";

            using (SqlConnection con = new SqlConnection(ConnStr))
            using (SqlCommand cmd = new SqlCommand(q, con))
            {
                cmd.Parameters.AddWithValue("@id", docID);
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        txtTitle.Text = reader["Title"].ToString();
                        txtContent.Text = reader["Content"].ToString();
                    }
                }
            }
        }

        void LoadDocumentIfChanged()
        {
            if (docID == 0) return;

            int userID = Convert.ToInt32(Session["UserID"]);

            string q = "SELECT Title, Content FROM Documents WHERE DocumentID=@id AND LastModifiedBy != @u";

            using (SqlConnection con = new SqlConnection(ConnStr))
            using (SqlCommand cmd = new SqlCommand(q, con))
            {
                cmd.Parameters.AddWithValue("@id", docID);
                cmd.Parameters.AddWithValue("@u", userID);
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        txtTitle.Text = reader["Title"].ToString();
                        txtContent.Text = reader["Content"].ToString();
                        lblAuto.Text = "Updated by another user at " + DateTime.Now.ToLongTimeString();
                    }
                }
            }
        }

        string GetPermission()
        {
            if (Session["UserID"] == null) return "View";

            int userID = Convert.ToInt32(Session["UserID"]);

            string q = "SELECT Permission FROM DocumentAccess WHERE DocumentID=@d AND UserID=@u";

            using (SqlConnection con = new SqlConnection(ConnStr))
            using (SqlCommand cmd = new SqlCommand(q, con))
            {
                cmd.Parameters.AddWithValue("@d", docID);
                cmd.Parameters.AddWithValue("@u", userID);
                con.Open();
                object result = cmd.ExecuteScalar();
                return result != null ? result.ToString() : "Owner";
            }
        }

        void AutoSave()
        {
            if (docID == 0) return;

            int userID = Convert.ToInt32(Session["UserID"]);

            string q = "UPDATE Documents SET Title=@t, Content=@c, LastModifiedBy=@u WHERE DocumentID=@id";

            using (SqlConnection con = new SqlConnection(ConnStr))
            using (SqlCommand cmd = new SqlCommand(q, con))
            {
                cmd.Parameters.AddWithValue("@t", txtTitle.Text);
                cmd.Parameters.AddWithValue("@c", txtContent.Text);
                cmd.Parameters.AddWithValue("@u", userID);
                cmd.Parameters.AddWithValue("@id", docID);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            AutoSave();
            lblMsg.Text = "Document Updated Successfully!";
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            string permission = GetPermission();

            if (permission == "Edit" || permission == "Owner")
            {
                AutoSave();
                lblAuto.Text = "Auto-saved at " + DateTime.Now.ToLongTimeString();
            }

            LoadDocumentIfChanged();
        }
    }
}