using System;
using TokoBeDia.Controllers;
namespace TokoBeDia.Views
{
    public partial class ViewProductType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserEmail"] == null && Convert.ToInt32(Session["RoleId"]) != 2)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                new ViewProductTypeController().UpdateGridData(gridProductType);
            }
            
        }

        protected void btnInsertProductType_Click(object sender, EventArgs e)
        {
            new ViewProductTypeController().InsertProductType();

        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            new ViewProductTypeController().UpdateProductType(sender);
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            new ViewProductTypeController().DeleteProductType(sender, lblErrorDelete, gridProductType);

        }
    }
}