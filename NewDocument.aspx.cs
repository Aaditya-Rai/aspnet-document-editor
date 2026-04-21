using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sem4_Project
{
    public partial class NewDocument : System.Web.UI.Page
    {
        SqlConnection mycon = new SqlConnection(
        "Data Source=DESKTOP-3D7519J;Initial Catalog=project;Integrated Security=True;Pooling=False;Encrypt=False;");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text.Trim();
            string content = txtContent.Text.Trim();

            string q = "INSERT INTO Documents (Title, Content, CreatedDate, OwnerID) VALUES (@t,@c,@d,@o)";

            SqlCommand cmd = new SqlCommand(q, mycon);

            cmd.Parameters.AddWithValue("@t", title);
            cmd.Parameters.AddWithValue("@c", content);
            cmd.Parameters.AddWithValue("@d", DateTime.Now);
            cmd.Parameters.AddWithValue("@o", Session["UserID"]);

            mycon.Open();
            cmd.ExecuteNonQuery();
            mycon.Close();

            lblMsg.Text = "Document Saved Successfully!";

            txtTitle.Text = "";
            txtContent.Text = "";
        }
    }
}