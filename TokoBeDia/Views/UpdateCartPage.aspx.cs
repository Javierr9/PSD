using System;
using TokoBeDia.Models;
using TokoBeDia.Handlers;
using TokoBeDia.Controllers;
namespace TokoBeDia.Views
{
    public partial class UpdateCartPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserEmail"] == null && Convert.ToInt32(Session["RoleId"]) != 1)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                new UpdateCartPageController().InitPage(Request.QueryString["ProductID"], Session["UserID"],Name, Price, Stock);

            }

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            new UpdateCartPageController().UpdateCart(Request.QueryString["ProductID"], Session["UserID"],txtQuantity, lblErrorSubmit, Stock);


        }
    }
}