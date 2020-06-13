using System;
using System.Web;
using TokoBeDia.Handlers;
using System.Web.UI.WebControls;

namespace TokoBeDia.Controllers
{
    public class ViewProductTypeController
    {
        public void UpdateGridData(GridView gridProductType)
        {
            gridProductType.DataSource = new ProductTypeHandler().GetAllProductType();
            gridProductType.DataBind();
        }

        public void InsertProductType()
        {
            HttpContext.Current.Response.Redirect("InsertProductType.aspx");
        }
        public void UpdateProductType(object sender)
        {
            GridViewRow row = (sender as Button).NamingContainer as GridViewRow;

            HttpContext.Current.Response.Redirect("UpdateProductType.aspx?producttypeid=" + row.Cells[0].Text);
        }

        public void DeleteProductType(object sender, Label lblErrorDelete, GridView gridProductType)
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
            UpdateGridData(gridProductType);
        }
    }
}