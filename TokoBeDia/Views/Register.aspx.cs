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
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string name = txtName.Text;
            string password = txtPassword.Text;
            string gender = rblGender.Text;
            //bcz it's only for member registration
            int roleId = 1;
            string status = "active";

            bool check = new UserRepository().GetSameEmailInsert(email);
            if(check == true)
            {
                lblErrorEmail.Visible = true;
                return;
            }

            User newMember = new UserFactory().CreteUser(email, name, password, gender, roleId, status);

            new UserRepository().InsertUser(newMember);

            txtEmail.Text = "";
            txtName.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            rblGender.SelectedIndex = -1;
            lblErrorEmail.Visible = false;

            Response.Redirect("Home.aspx");
        }
    }
}