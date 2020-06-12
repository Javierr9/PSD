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
    public class InsertProductController
    {
        public void validateInsertProduct(TextBox txtName, TextBox txtStock, TextBox txtPrice, DropDownList ddlProductType, Label lblErrorPrice, Label lblErrorStock)
        {
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
            new ProductHandler().InsertProduct(product);


            txtName.Text = "";
            txtPrice.Text = "";
            txtStock.Text = "";

        }

        public void initPage(DropDownList ddlProductType)
        {
            List<ProductType> dataPT = new ProductTypeHandler().GetAllProductType();
            ddlProductType.DataSource = dataPT;
            ddlProductType.DataTextField = "Name";
            ddlProductType.DataValueField = "ID";
            ddlProductType.DataBind();
        }
    }
}