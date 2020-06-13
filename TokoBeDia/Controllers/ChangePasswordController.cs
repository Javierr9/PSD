using System;
using System.Web.UI.WebControls;
using TokoBeDia.Models;
using TokoBeDia.Handlers;

namespace TokoBeDia.Controllers
{
    public class ChangePasswordController
    {
        public void ChangePassword(TextBox txtOldPassword, object UserEmail, TextBox txtNewPassword, Label lblErrorNewPassword, Label lblErrorChange, Label lblSuccess )
           {
            string oldPassword = txtOldPassword.Text;
            string email = Convert.ToString(UserEmail);
            string newPassword = txtNewPassword.Text;

            if (newPassword.Length <= 5)
            {
                lblErrorNewPassword.Text = "Must be longer than 5 characters";
                return;
            }

            User check = new UserHandler().GetUserByEmailAndPass(email, oldPassword);
            if (check == null)
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