using System;
using TokoBeDia.Handlers;
using System.Web.UI.WebControls;
using TokoBeDia.Models;

namespace TokoBeDia.Controllers
{
    public class AddToCartController
    {
        public void GetProductInformation(string productID, Label Name, Label Price, Label Stock, Label ProductTypeLabel)
        {
            int ProductID = Int32.Parse(productID);
            Product NewProduct = new ProductHandler().GetProductByID(ProductID);
            Name.Text = NewProduct.Name;
            Price.Text = NewProduct.Price.ToString();
            Stock.Text = NewProduct.Stock.ToString();
            ProductType NewProductType = new ProductTypeHandler().GetProductTypeByID(NewProduct.ID);
            ProductTypeLabel.Text = NewProductType.Name;
        }

        public void AddProductToCart(TextBox txtQuantity, Label Stock, Label lblErrorSubmit, string userID, string productID)
        {
            if (Int32.Parse(txtQuantity.Text) > Int32.Parse(Stock.Text) || Int32.Parse(txtQuantity.Text) == 0 || txtQuantity == null)
            {
                txtQuantity.Text = "";
                lblErrorSubmit.Text = "Please input a valid quantity";
                lblErrorSubmit.ForeColor = System.Drawing.Color.Red;
                lblErrorSubmit.Visible = true;

            }
            else if (txtQuantity != null)
            {
                int UserID = Int32.Parse(userID);
                int ProductID = Int32.Parse(productID);
                int Quantity = Int32.Parse(txtQuantity.Text);
                CartHandler.AddToCart(UserID, ProductID, Quantity);
                txtQuantity.Text = "";
                lblErrorSubmit.ForeColor = System.Drawing.Color.Black;
                lblErrorSubmit.Text = "Successfully added to cart.";
                lblErrorSubmit.Visible = true;
                new ProductHandler().SubstractProductStockById(ProductID, Quantity);
                Product NewProduct = new ProductHandler().GetProductByID(ProductID);
                Stock.Text = NewProduct.Stock.ToString();


            }
        }

    }
}