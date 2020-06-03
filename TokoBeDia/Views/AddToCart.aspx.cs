using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Handlers;
using TokoBeDia.Models;

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
                int ProductID = Int32.Parse(Request.QueryString["ProductID"]);
                Product NewProduct = new ProductHandler().GetProductByID(ProductID);
                Name.Text = NewProduct.Name;
                Price.Text = NewProduct.Price.ToString();
                Stock.Text = NewProduct.Stock.ToString();
                ProductType NewProductType = new ProductTypeHandler().GetProductTypeByID(NewProduct.ID);
                ProductTypeLabel.Text = NewProductType.Name;
                
            }
           
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (Int32.Parse(txtQuantity.Text) > Int32.Parse(Stock.Text) || Int32.Parse(txtQuantity.Text) == 0 || txtQuantity == null)
            {
                txtQuantity.Text = "";
                lblErrorSubmit.Text = "Please input a valid quantity";
                lblErrorSubmit.ForeColor = System.Drawing.Color.Red;
                lblErrorSubmit.Visible = true;
                
            }
            else if(txtQuantity != null)
            {
                int UserID = Int32.Parse(Session["UserID"].ToString());
                int ProductID = Int32.Parse(Request.QueryString["ProductID"]);
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