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
                Product UpdateProduct = new ProductHandler().GetProductByID(ProductID);
                Name.Text = UpdateProduct.Name;
                Price.Text = UpdateProduct.Price.ToString();
                Stock.Text = UpdateProduct.Stock.ToString();


            }

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int ProductID = Int32.Parse(Request.QueryString["ProductID"]);
            int UserID = Int32.Parse(Session["UserID"].ToString());
            Product currentProduct = new ProductHandler().GetProductByID(ProductID);
            Cart currentCart = new CartHandler().GetCartByTwoId(UserID, ProductID);
            int currentListTotal = new CartHandler().CountListByProductId(ProductID);
            if (Int32.Parse(txtQuantity.Text) > currentListTotal || Int32.Parse(txtQuantity.Text) == 0 || Int32.Parse(txtQuantity.Text) == currentCart.Quantity)
            {
                txtQuantity.Text = "";
                lblErrorSubmit.Text = "Please input a valid quantity";
                lblErrorSubmit.ForeColor = System.Drawing.Color.Red;
                lblErrorSubmit.Visible = true;

            }
            else if (txtQuantity != null)
            {
               
                int Quantity = Int32.Parse(txtQuantity.Text);
                if (Int32.Parse(txtQuantity.Text) > currentCart.Quantity)
                {
                    int QuantityInput = Int32.Parse(txtQuantity.Text) - currentCart.Quantity;
                    new ProductHandler().SubstractProductStockById(ProductID, QuantityInput);
                }
                else
                {
                    int QuantityInput = currentCart.Quantity - Int32.Parse(txtQuantity.Text);
                    new ProductHandler().AddProductStockById(ProductID, QuantityInput);
                }

                CartHandler.UpdateCart(UserID, ProductID, Quantity);
                txtQuantity.Text = "";
                lblErrorSubmit.ForeColor = System.Drawing.Color.Black;
                lblErrorSubmit.Text = "Successfully updated cart.";
                lblErrorSubmit.Visible = true;
               
                Product NewProduct = new ProductHandler().GetProductByID(ProductID);
                Stock.Text = NewProduct.Stock.ToString();


            }



        }
    }
}