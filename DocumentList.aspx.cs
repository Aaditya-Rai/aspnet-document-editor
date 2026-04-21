using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sem4_Project
{

    public partial class DocumentList : System.Web.UI.Page
    {
        SqlConnection mycon = new SqlConnection(
       "Data Source=DESKTOP-3D7519J;Initial Catalog=project;Integrated Security=True;Pooling=False;Encrypt=False;");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDocuments();
            }
        }

        void LoadDocuments()
        {
            string q = @"SELECT * FROM Documents 
    WHERE OwnerID = @uid 
    OR DocumentID IN 
    (
        SELECT DocumentID FROM DocumentAccess WHERE UserID = @uid
    )";

            SqlCommand cmd = new SqlCommand(q, mycon);

             
            cmd.Parameters.AddWithValue("@uid", Session["UserID"]);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);

            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            int docID = Convert.ToInt32(GridView1.Rows[index].Cells[0].Text);

             
            if (e.CommandName == "OpenDoc")
            {
                Response.Redirect("EditDocument.aspx?id=" + docID);
            }
            if (e.CommandName == "ShareDoc")
            {
                Response.Redirect("ShareDocument.aspx?id=" + docID);
            }
             
            if (e.CommandName == "DeleteDoc")
            {
                int userID = Convert.ToInt32(Session["UserID"]);

                
                string checkQ = "SELECT OwnerID FROM Documents WHERE DocumentID=@id";
                SqlCommand checkCmd = new SqlCommand(checkQ, mycon);
                checkCmd.Parameters.AddWithValue("@id", docID);

                mycon.Open();
                int ownerID = Convert.ToInt32(checkCmd.ExecuteScalar());
                mycon.Close();

                if (ownerID == userID)
                {
                    mycon.Open();

                    string q = "DELETE FROM Documents WHERE DocumentID=@id";
                    SqlCommand cmd = new SqlCommand(q, mycon);
                    cmd.Parameters.AddWithValue("@id", docID);

                    cmd.ExecuteNonQuery();
                    mycon.Close();

                    LoadDocuments();
                }
                else
                {
                    Response.Write("<script>alert('You are not allowed to delete this document');</script>");
                }
            }
        }
    }
}