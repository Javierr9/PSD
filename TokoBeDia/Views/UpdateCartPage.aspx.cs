using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Models;
using TokoBeDia.Handlers;
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
                int ProductID = Int32.Parse(Request.QueryString["ProductID"]);
                int UserID = Int32.Parse(Session["UserID"].ToString());

            }

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Int32.Parse(txtQuantity.Text) > Int32.Parse(Stock.Text) || Int32.Parse(txtQuantity.Text) == 0)
            {
                txtQuantity.Text = "";
                lblErrorSubmit.Text = "Please input a valid quantity";
                lblErrorSubmit.ForeColor = System.Drawing.Color.Red;
                lblErrorSubmit.Visible = true;

            }
            else if (txtQuantity != null)
            {
                int UserID = Int32.Parse(Session["UserID"].ToString());
                int ProductID = Int32.Parse(Request.QueryString["ProductID"]);
                int Quantity = Int32.Parse(txtQuantity.Text);
                CartHandler.AddToCart(UserID, ProductID, Quantity);
                txtQuantity.Text = "";
                lblErrorSubmit.ForeColor = System.Drawing.Color.Black;
                lblErrorSubmit.Text = "Successfully updated cart.";
                lblErrorSubmit.Visible = true;
                new ProductHandler().SubstractProductStockById(ProductID, Quantity);
                Product NewProduct = new ProductHandler().GetProductByID(ProductID);
                Stock.Text = NewProduct.Stock.ToString();


            }
        }
    }
}