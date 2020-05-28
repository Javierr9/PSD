using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TokoBeDia.Views
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["Username"] == null)
            {
                lblUsername.Text = "Guest";
            }
            else
            {
                lblUsername.Text = Convert.ToString(Session["Username"]);
            }
        }
    }
}