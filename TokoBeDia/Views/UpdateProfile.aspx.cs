using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using TokoBeDia.Controllers;

namespace TokoBeDia.Views
{
    public partial class UpdateProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserEmail"] == null && Session["RoleId"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    new UpdateProfileController().initPage(txtEmail, txtName, rblGender);     
                }
                
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            new UpdateProfileController().validateUpdateProfile(txtEmail, txtName, rblGender, lblSuccess, lblErrorEmail);
        }
    }
}