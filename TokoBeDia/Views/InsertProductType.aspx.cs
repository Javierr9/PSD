using System;
using TokoBeDia.Controllers;

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
            new InsertProductTypeController().validateInsert(txtProductType, txtDescription, lblErrorProductType);
        }
    }
}