using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Models;
using TokoBeDia.Factories;
using TokoBeDia.Handlers;

namespace TokoBeDia.Views
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Session["UserEmail"] == null && Session["RoleId"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnChange_Click(object sender, EventArgs e)
        {
            string oldPassword = txtOldPassword.Text;
            string email = Convert.ToString(Session["UserEmail"]);
            string newPassword = txtNewPassword.Text;

            if(newPassword.Length <= 5)
            {
                lblErrorNewPassword.Text = "Must be longer than 5 characters";
                return;
            }

            User check = new UserHandler().GetUserByEmailAndPass(email, oldPassword);
            if(check == null)
            {
                lblErrorChange.Text = "Mismatch password";
                return;
            }

            new UserHandler().UpdatePassword(check, newPassword);
            lblErrorChange.Text = "";
            lblErrorNewPassword.Text = "";
            lblSuccess.Visible = true;
                
        }
    }
}