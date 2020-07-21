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
    public class InsertProductTypeController
    {
        public void validateInsert(TextBox txtProductType, TextBox txtDescription, Label lblErrorProductType)
        {
            string name = txtProductType.Text;
            string description = txtDescription.Text;

            bool check = new ProductTypeHandler().GetSameNameInsert(name);
            if (check == true)
            {
                lblErrorProductType.Text = "Must be unique";
                return;
            }
            ProductType newProductType = new ProductTypeFactory().CreateProduct(name, description);
            new ProductTypeHandler().InsertProductType(newProductType);
            lblErrorProductType.Text = "";
            txtProductType.Text = "";
            txtDescription.Text = "";
        }

    }
}