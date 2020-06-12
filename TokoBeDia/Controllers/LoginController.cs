using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using TokoBeDia.Handlers;
using TokoBeDia.Models;

namespace TokoBeDia.Controllers
{
    public class LoginController
    {
        public void validateEmailPass(TextBox txtEmail, TextBox txtPassword, Label lblErrorLogin, CheckBox ckRememberMe)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            User check = new UserHandler().GetUserByEmailAndPass(email, password);
            if (check != null)
            {
                if (check.Status == "active")
                {
                    HttpContext.Current.Session["UserID"] = check.ID;
                    HttpContext.Current.Session["UserEmail"] = check.Email;
                    HttpContext.Current.Session["UserName"] = check.Name;
                    HttpContext.Current.Session["RoleId"] = check.RoleID;
                    HttpContext.Current.Session.Timeout = 60;
                    lblErrorLogin.Text = "";

                    if (ckRememberMe.Checked)
                    {
                        HttpContext.Current.Response.Cookies["AuthCookie"]["UserEmail"] = txtEmail.Text;
                        HttpContext.Current.Response.Cookies["AuthCookie"]["UserPassword"] = txtPassword.Text;
                        HttpContext.Current.Response.Cookies["AuthCookie"].Expires = DateTime.Now.AddDays(1);
                    }

                    HttpContext.Current.Response.Redirect("Home.aspx");
                }
                else if (check.Status == "blocked")
                {
                    lblErrorLogin.Text = "This account is currently banned";
                }
            }
            else
            {
                lblErrorLogin.Text = "Wrong email or password";
            }
        }
    }
}