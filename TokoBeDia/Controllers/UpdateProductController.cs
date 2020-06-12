using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using TokoBeDia.Models;
using TokoBeDia.Factories;
using TokoBeDia.Handlers;

namespace TokoBeDia.Controllers
{
    public class UpdateProductController
    {
        public void validateUpdateProduct(TextBox txtName, TextBox txtPrice, TextBox txtStock, DropDownList ddlProductType, Label lblErrorStock, Label lblErrorPrice, Label lblSuccess)
        {
            int ID = Convert.ToInt32(HttpContext.Current.Request.QueryString["productid"]);
            string name = txtName.Text;
            int stock = Convert.ToInt32(txtStock.Text);
            int price = Convert.ToInt32(txtPrice.Text);

            if (stock <= 0)
            {
                lblErrorStock.Visible = true;
                return;
            }
            lblErrorStock.Visible = false;

            if (price <= 1000 || (price % 1000 != 0))
            {
                lblErrorPrice.Visible = true;
                return;
            }
            lblErrorPrice.Visible = false;

            Product product = new ProductFactory().CreateProduct(Convert.ToInt32(ddlProductType.SelectedValue), name, price, stock);
            new ProductHandler().UpdateProduct(product, ID);

            lblSuccess.Visible = true;
        }

        public void initPage(TextBox txtName, TextBox txtPrice, TextBox txtStock, DropDownList ddlProductType)
        {
            List<ProductType> dataPT = new ProductTypeHandler().GetAllProductType();
            ddlProductType.DataSource = dataPT;
            ddlProductType.DataTextField = "Name";
            ddlProductType.DataValueField = "ID";
            ddlProductType.DataBind();

            int ID = Convert.ToInt32(HttpContext.Current.Request.QueryString["productid"]);

            Product currentProduct = new ProductHandler().GetProductByID(ID);
            txtName.Text = currentProduct.Name;
            txtPrice.Text = Convert.ToString(currentProduct.Price);
            txtStock.Text = Convert.ToString(currentProduct.Stock);
            ddlProductType.SelectedValue = Convert.ToString(currentProduct.ProductTypeID);
        }
    }
}