using System;
using TokoBeDia.Controllers;
namespace TokoBeDia.Views
{
    public partial class ViewPaymentType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserEmail"] == null && Convert.ToInt32(Session["RoleId"]) != 2)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                new ViewPaymentTypeController().UpdateGridData(gridPaymentType); 
            }
        }

        protected void btnInsertPaymentType_Click(object sender, EventArgs e)
        {
            new ViewPaymentTypeController().InsertPaymentType();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            new ViewPaymentTypeController().UpdatePaymentType(sender);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}