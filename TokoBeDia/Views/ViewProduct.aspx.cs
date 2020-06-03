using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Models;
using TokoBeDia.Factories;
using TokoBeDia.Handlers;

namespace TokoBeDia.Views
{
    public partial class ViewProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UpdateGridData();
            }
            if(Convert.ToInt32(Session["RoleId"]) == 2)
            {
                gridProduct.Columns[5].Visible = true;
                btnInsertProduct.Visible = true;
            }else if(Convert.ToInt32(Session["RoleId"]) == 1)
            {
                gridProduct.Columns[6].Visible = true;
            }
        }

        private void UpdateGridData()
        {
            gridProduct.DataSource = new ProductHandler().GetAllProduct();
            gridProduct.DataBind();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            GridViewRow row = (sender as Button).NamingContainer as GridViewRow;

            Response.Redirect("UpdateProduct.aspx?productid=" + row.Cells[0].Text);
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            GridViewRow row = (sender as Button).NamingContainer as GridViewRow;
            int ID = Convert.ToInt32(row.Cells[0].Text);

            bool check = new ProductHandler().GetReferencedDetailTransaction(ID);
            if(check == true)
            {
                lblErrorDelete.Visible = true;
                return;
            }

            new ProductHandler().DeleteProduct(ID);
        }
        protected void btnInsertProduct_Click(object sender, EventArgs e)
        {
            Response.Redirect("InsertProduct.aspx");
        }


        protected void btnAddToCart_click(object sender, EventArgs e)
        {
            GridViewRow row = (sender as Button).NamingContainer as GridViewRow;
            int ID = Convert.ToInt32(row.Cells[0].Text);
            Response.Redirect("AddToCart.aspx?ProductID=" +ID);


        }
    }
}