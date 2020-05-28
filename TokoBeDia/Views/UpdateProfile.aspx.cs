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
                    User dataUser = new UserRepository().GetUserByEmail(Convert.ToString(Session["UserEmail"]));

                    txtEmail.Text = dataUser.Email;
                    txtName.Text = dataUser.Name;

                    if (rblGender.Items.FindByText(dataUser.Gender) != null)
                    {
                        rblGender.Items.FindByText(dataUser.Gender).Selected = true;
                    }
                }
                
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string currentEmail = Convert.ToString(Session["UserEmail"]);
            string newEmail = txtEmail.Text;
            string newName = txtName.Text;
            string gender = rblGender.Text;
            int roleId = Convert.ToInt32(Session["RoleId"]);

            User newData = new UserFactory().CreteUser(newEmail, newName, null, gender, roleId, null);

            new UserRepository().UpdateUser(newData, currentEmail);

            lblSuccess.Visible = true;
        }
    }
}