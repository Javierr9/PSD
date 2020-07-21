using System;
using System.Web;
using TokoBeDia.Controllers;

namespace TokoBeDia.Views
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Request.Cookies["AuthCookie"] != null)
            {
                HttpCookie cookie = Request.Cookies["AuthCookie"];

                txtEmail.Text = cookie["UserEmail"];
                txtPassword.Attributes.Add("value", Convert.ToString(cookie["UserPassword"]));               

            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            new LoginController().validateEmailPass(txtEmail, txtPassword, lblErrorLogin, ckRememberMe);        
        }
    }
}