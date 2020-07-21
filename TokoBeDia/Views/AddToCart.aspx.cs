using System;
using TokoBeDia.Controllers;
namespace TokoBeDia.Views
{
    public partial class AddToCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblErrorSubmit.Visible = false;
            if (Session["UserEmail"] == null && Convert.ToInt32(Session["RoleId"]) != 1)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                new AddToCartController().GetProductInformation(Request.QueryString["ProductID"], Name, Price, Stock, ProductTypeLabel);
            }

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            new AddToCartController().AddProductToCart(txtQuantity, Stock, lblErrorSubmit, Session["UserID"].ToString(), Request.QueryString["ProductID"]);
        }

    }
}