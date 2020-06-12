using System;
using TokoBeDia.Controllers;

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
            new ChangePasswordController().ChangePassword(txtOldPassword, Session["UserEmail"], txtNewPassword, lblErrorNewPassword,lblErrorChange , lblSuccess);
            
                
        }
    }
}