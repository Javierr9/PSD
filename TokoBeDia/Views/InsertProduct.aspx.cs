using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using TokoBeDia.Controllers;

namespace TokoBeDia.Views
{
    public partial class InsertProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserEmail"] == null && Convert.ToInt32(Session["RoleId"]) != 2)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                new InsertProductController().initPage(ddlProductType);
            }
        }

        protected void btnInsertProduct_Click(object sender, EventArgs e)
        {
            new InsertProductController().validateInsertProduct(txtName, txtStock, txtPrice, ddlProductType, lblErrorPrice, lblErrorStock);
            
        }
    }
}