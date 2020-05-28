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
    public partial class UpdateProductType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserEmail"] == null && Convert.ToInt32(Session["RoleId"]) != 2)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                int ID = Convert.ToInt32(Request.QueryString["producttypeid"]);
                
                ProductType currentData = new ProductTypeRepository().GetProductTypeByID(ID);
                txtProductType.Text = currentData.Name;
                txtDescription.Text = currentData.Description;
            }
        }

        protected void btnUpdateProductType_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(Request.QueryString["producttypeid"]);
            string name = txtProductType.Text;
            string description = txtDescription.Text;

            List<ProductType> check = new ProductTypeRepository().GetSameNameUpdate(name);
            int flag = 0;
            foreach(var item in check)
            {
                if(item.ID != ID)
                {
                    flag = 1;
                    break;
                }
            }
            if(flag == 1)
            {
                lblErrorProductType.Visible = true;
                return;
            }

            ProductType newProductType = new ProductTypeFactory().CreateProduct(name, description);
            new ProductTypeRepository().UpdateProductType(newProductType, ID);

            lblSuccess.Visible = true;
        }
    }
}