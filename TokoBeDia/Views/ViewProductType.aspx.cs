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
    public partial class ViewProductType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserEmail"] == null && Convert.ToInt32(Session["RoleId"]) != 2)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                UpdateGridData();
            }
            
        }
        private void UpdateGridData()
        {
            gridProductType.DataSource = new ProductTypeHandler().GetAllProductType();
            gridProductType.DataBind();
        }
        protected void btnInsertProductType_Click(object sender, EventArgs e)
        {
            Response.Redirect("InsertProductType.aspx");
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            GridViewRow row = (sender as Button).NamingContainer as GridViewRow;

            Response.Redirect("UpdateProductType.aspx?producttypeid=" + row.Cells[0].Text);
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            GridViewRow row = (sender as Button).NamingContainer as GridViewRow;
            int ID = Convert.ToInt32(row.Cells[0].Text);

            bool check = new ProductTypeHandler().GetReferencedProduct(ID);
            if (check == true)
            {
                lblErrorDelete.Visible = true;
                return;
            }

            new ProductTypeHandler().DeleteProductType(ID);
            UpdateGridData();
        }
    }
}