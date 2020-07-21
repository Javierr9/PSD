using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using TokoBeDia.Factories;
using TokoBeDia.Handlers;
using TokoBeDia.Models;

namespace TokoBeDia.Controllers
{
    public class RegisterController
    {
        public void validateRegister(TextBox txtEmail, TextBox txtName, TextBox txtPassword, RadioButtonList rblGender, Label lblErrorEmail)
        {
            string email = txtEmail.Text;
            string name = txtName.Text;
            string password = txtPassword.Text;
            string gender = rblGender.Text;
            int roleId = 1;
            string status = "active";

            bool check = new UserHandler().GetSameEmailInsert(email);
            if (check == true)
            {
                lblErrorEmail.Visible = true;
                return;
            }

            User newMember = new UserFactory().CreteUser(email, name, password, gender, roleId, status);

            new UserHandler().InsertUser(newMember);

            HttpContext.Current.Response.Redirect("Login.aspx");
        }
    }
}