using System;
using TokoBeDia.Controllers;

namespace TokoBeDia.Views
{
    public partial class ViewProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                new ViewProductController().UpdateGridData(gridProduct);
            }

            if(Convert.ToInt32(Session["RoleId"]) == 2)
            {
                new ViewProductController().InitRoleID2(gridProduct, btnInsertProduct);

            }else if(Convert.ToInt32(Session["RoleId"]) == 1)
            {
                new ViewProductController().InitRoleID1(gridProduct);

            }
        }



        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            new ViewProductController().UpdateProduct(sender);
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            new ViewProductController().DeleteProduct(sender, lblErrorDelete);
        }
        protected void btnInsertProduct_Click(object sender, EventArgs e)
        {
            new ViewProductController().InsertProduct();
        }


        protected void btnAddToCart_click(object sender, EventArgs e)
        {
            new ViewProductController().AddToCart(sender);

        }
    }
}