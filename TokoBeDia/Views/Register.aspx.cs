using System;
using TokoBeDia.Controllers;

namespace TokoBeDia.Views
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            new RegisterController().validateRegister(txtEmail, txtName, txtPassword, rblGender, lblErrorEmail);
            
        }
    }
}