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
    public class UpdateProductTypeController
    {
        public void validateUpdateProductType(TextBox txtProductType, TextBox txtDescription, Label lblErrorProductType, Label lblSuccess)
        {
            int ID = Convert.ToInt32(HttpContext.Current.Request.QueryString["producttypeid"]);
            string name = txtProductType.Text;
            string description = txtDescription.Text;

            List<ProductType> check = new ProductTypeHandler().GetSameNameUpdate(name);
            int flag = 0;
            foreach (var item in check)
            {
                if (item.ID != ID)
                {
                    flag = 1;
                    break;
                }
            }
            if (flag == 1)
            {
                lblErrorProductType.Visible = true;
                return;
            }

            ProductType newProductType = new ProductTypeFactory().CreateProduct(name, description);
            new ProductTypeHandler().UpdateProductType(newProductType, ID);

            lblSuccess.Visible = true;
            lblErrorProductType.Visible = false;
        }

        public void initPage(TextBox txtProductType, TextBox txtDescription)
        {
            int ID = Convert.ToInt32(HttpContext.Current.Request.QueryString["producttypeid"]);

            ProductType currentData = new ProductTypeHandler().GetProductTypeByID(ID);
            txtProductType.Text = currentData.Name;
            txtDescription.Text = currentData.Description;
        }
    }
}