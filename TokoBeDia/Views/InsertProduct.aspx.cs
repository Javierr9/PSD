using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Models;
using TokoBeDia.Factories;
using TokoBeDia.Repositories;

namespace TokoBeDia.Views
{
    public partial class InsertProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserEmail"] == null && Convert.ToInt32(Session["RoleId"]) != 2)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                List<ProductType> dataPT = new ProductTypeRepository().GetAllProductType();
                ddlProductType.DataSource = dataPT;
                ddlProductType.DataTextField = "Name";
                ddlProductType.DataValueField = "ID";
                ddlProductType.DataBind();

                lblErrorPrice.Visible = false;
                lblErrorStock.Visible = false;
            }
        }

        protected void btnInsertProduct_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            int stock = Convert.ToInt32(txtStock.Text);
            int price = Convert.ToInt32(txtPrice.Text);

            if(stock <= 0)
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

            Product product = new ProductFactory().CreateProduct(Convert.ToInt32(ddlProductType.SelectedValue), name, price, stock); //default value, coz di soal gaada, why tho
            new ProductRepository().InsertProduct(product);
            
            
            txtName.Text = "";
            txtPrice.Text = "";
            txtStock.Text = "";

        }
    }
}