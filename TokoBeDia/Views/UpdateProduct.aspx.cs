using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using TokoBeDia.Controllers;

namespace TokoBeDia.Views
{
    public partial class UpdateProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserEmail"] == null && Convert.ToInt32(Session["RoleId"]) != 2)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                new UpdateProductController().initPage(txtName, txtPrice, txtStock, ddlProductType);
            }
        }

        protected void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            new UpdateProductController().validateUpdateProduct(txtName, txtPrice, txtStock, ddlProductType, lblErrorStock, lblErrorPrice, lblSuccess);
        }
    }
}