using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sem4_Project
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                btnLogout.Visible=false;
            }
            if (Session["User"] != null)
            {
                lblUser.Text = "Welcome, " + Session["User"].ToString();
                btnLogout.Visible = true;
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Index.aspx");
        }
    }
}