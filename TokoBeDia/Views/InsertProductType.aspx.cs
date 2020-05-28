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
    public partial class InsertProductType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserEmail"] == null && Convert.ToInt32(Session["RoleId"]) != 2)
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnInsertProductType_Click(object sender, EventArgs e)
        {
            string name = txtProductType.Text;
            string description = txtDescription.Text;

            bool check = new ProductTypeRepository().GetSameNameInsert(name);
            if(check == true)
            {
                lblErrorProductType.Text = "Must be unique";
                return;
            }
            ProductType newProductType = new ProductTypeFactory().CreateProduct(name, description);
            new ProductTypeRepository().InsertProductType(newProductType);
            lblErrorProductType.Text = "";
            txtProductType.Text = "";
            txtDescription.Text = "";
        }
    }
}