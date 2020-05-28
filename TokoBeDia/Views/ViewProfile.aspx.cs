using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Models;
using TokoBeDia.Factories;
using TokoBeDia.Repositories;

namespace TokoBeDia.Views
{
    public partial class ViewProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserEmail"] == null && Session["RoleId"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                User dataUser = new UserRepository().GetUserByEmail(Convert.ToString(Session["UserEmail"]));

                lblEmail.Text = dataUser.Email;
                lblName.Text = dataUser.Name;
                lblGender.Text = dataUser.Gender;
            }
           
        }

        protected void btnUpdateProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdateProfile.aspx");
        }
    }
}