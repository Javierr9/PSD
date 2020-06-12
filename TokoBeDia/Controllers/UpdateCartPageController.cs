using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using TokoBeDia.Handlers;
using TokoBeDia.Models;

namespace TokoBeDia.Controllers
{
    public class UpdateCartPageController
    {
        public void InitPage(string productID, object userID, Label Name, Label Price, Label Stock)
        {
            int ProductID = Int32.Parse(productID);
            int UserID = Int32.Parse(userID.ToString());
            Product UpdateProduct = new ProductHandler().GetProductByID(ProductID);
            Name.Text = UpdateProduct.Name;
            Price.Text = UpdateProduct.Price.ToString();
            Stock.Text = UpdateProduct.Stock.ToString();
        }
        public void UpdateCart(string productID, object userID, TextBox txtQuantity, Label lblErrorSubmit, Label Stock)
        {
            int ProductID = Int32.Parse(productID);
            int UserID = Int32.Parse(userID.ToString());
            Product currentProduct = new ProductHandler().GetProductByID(ProductID);
            Cart currentCart = new CartHandler().GetCartByTwoId(UserID, ProductID);
            int currentListTotal = new CartHandler().CountListByProductId(ProductID) + currentProduct.Stock;

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

                HttpContext.Current.Response.Redirect("ViewCart.aspx");
            }
        }
    }
}