using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TokoBeDia.MasterPage
{
    public partial class General : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserEmail"] != null && Session["RoleId"] != null)
            {
                int RoleId = Convert.ToInt32(Session["RoleId"]);

                //this will be visible for Member & Admin
                btnProfile.Visible = true;
                btnChangePassword.Visible = true;
                btnLogout.Visible = true;
                btnViewCart.Visible = true;
                btnViewTransactionHistory.Visible = true;
                //this will be visible for only Admin
                if (RoleId == 2)
                {
                    btnViewUser.Visible = true;
                    btnViewProductType.Visible = true;
                    btnViewPaymentType.Visible = true;
                }
            }
            else
            {
                btnRegister.Visible = true;
                btnLogin.Visible = true;
            }
        }
        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");

        }
        protected void btnProduct_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewProduct.aspx");
        }
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void btnProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewProfile.aspx");
        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChangePassword.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            if (Session["UserEmail"] != null && Session["RoleId"] != null)
            {
                Session.Remove("UserEmail");
                Session.Remove("Username");
                Session.Remove("RoleId");
            }
            if(Request.Cookies["AuthCookie"] != null)
            {
                Response.Cookies["AuthCookie"].Expires = DateTime.Now.AddDays(-1);
            }
            Response.Redirect("Home.aspx");
        }

        protected void btnViewUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewUser.aspx");
        }

        protected void btnViewProductType_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewProductType.aspx");
        }

        protected void btnViewPaymentType_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewPaymentType.aspx");
        }

        protected void btnViewCart_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewCart.aspx");
        }

        protected void btnViewTransactionHistory_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewTransactionHistory.aspx");
        }
    }
}