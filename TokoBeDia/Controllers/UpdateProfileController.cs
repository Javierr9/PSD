using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using TokoBeDia.Models;
using TokoBeDia.Factories;
using TokoBeDia.Handlers;

namespace TokoBeDia.Controllers
{
    public class UpdateProfileController
    {
        public void validateUpdateProfile(TextBox txtEmail, TextBox txtName, RadioButtonList rblGender, Label lblSuccess, Label lblErrorEmail)
        {
            string currentEmail = Convert.ToString(HttpContext.Current.Session["UserEmail"]);
            string newEmail = txtEmail.Text;
            string newName = txtName.Text;
            string gender = rblGender.Text;
            int roleId = Convert.ToInt32(HttpContext.Current.Session["RoleId"]);

            bool check = new UserHandler().GetSameEmailInsert(newEmail);
            if (check == true)
            {
                lblErrorEmail.Visible = true;
                return;
            }

            User newData = new UserFactory().CreteUser(newEmail, newName, null, gender, roleId, null);

            new UserHandler().UpdateUser(newData, currentEmail);

            lblSuccess.Visible = true;
        }

        public void initPage(TextBox txtEmail, TextBox txtName, RadioButtonList rblGender)
        {
            User dataUser = new UserHandler().GetUserByEmail(Convert.ToString(HttpContext.Current.Session["UserEmail"]));

            txtEmail.Text = dataUser.Email;
            txtName.Text = dataUser.Name;

            if (rblGender.Items.FindByText(dataUser.Gender) != null)
            {
                rblGender.Items.FindByText(dataUser.Gender).Selected = true;
            }
        }
    }
}