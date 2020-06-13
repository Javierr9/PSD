using System;
using System.Web;
using System.Web.UI.WebControls;
using TokoBeDia.Handlers;

namespace TokoBeDia.Controllers
{
    public class ViewProductController
    {
        public void UpdateGridData(GridView gridProduct)
        {
         gridProduct.DataSource = new ProductHandler().GetAllProduct();
         gridProduct.DataBind();
        }

        public void UpdateProduct(object sender)
        {
            GridViewRow row = (sender as Button).NamingContainer as GridViewRow;

            HttpContext.Current.Response.Redirect("UpdateProduct.aspx?productid=" + row.Cells[0].Text);
        }

        public void DeleteProduct(object sender, Label lblErrorDelete)
        {
 
            GridViewRow row = (sender as Button).NamingContainer as GridViewRow;
            int ID = Convert.ToInt32(row.Cells[0].Text);

            bool check = new ProductHandler().GetReferencedDetailTransaction(ID);
            if (check == true)
            {
                lblErrorDelete.Visible = true;
                return;
            }

            new ProductHandler().DeleteProduct(ID);
        }

        public void AddToCart(object sender)
        {
            GridViewRow row = (sender as Button).NamingContainer as GridViewRow;
            int ID = Convert.ToInt32(row.Cells[0].Text);
            HttpContext.Current.Response.Redirect("AddToCart.aspx?ProductID=" + ID);
        }

        public void InsertProduct()
        {
            HttpContext.Current.Response.Redirect("InsertProduct.aspx");
        }
        
        public void InitRoleID2(GridView gridProduct, Button btnInsertProduct)
        {
            gridProduct.Columns[5].Visible = true;
            btnInsertProduct.Visible = true;
        }
        public void InitRoleID1(GridView gridProduct)
        {
            gridProduct.Columns[6].Visible = true;
        }

    }
}