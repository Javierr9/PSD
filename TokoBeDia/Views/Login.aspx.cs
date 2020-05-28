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
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            User check = new UserRepository().GetUserByEmailAndPass(email, password);
            if (check != null)
            {
                if(check.Status == "active")
                {
                    Session["UserEmail"] = txtEmail.Text;
                    Session["UserName"] = check.Name;
                    Session["RoleId"] = check.RoleID; 
                    Session.Timeout = 60;

                    if (ckRememberMe.Checked)
                    {
                        Response.Cookies["AuthCookie"]["UserEmail"] = txtEmail.Text;
                        Response.Cookies["AuthCookie"]["UserPassword"] = txtPassword.Text;
                        Response.Cookies["AuthCookie"].Expires = DateTime.Now.AddDays(1);
                    }
                    lblErrorLogin.Text = "";
                    Response.Redirect("Home.aspx");
                }
                else if(check.Status == "blocked")
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