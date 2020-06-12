using System;
using TokoBeDia.Controllers;

namespace TokoBeDia.Views
{
    public partial class InsertPaymentType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserEmail"] == null && Convert.ToInt32(Session["RoleId"]) != 2)
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnInsertPaymentType_Click(object sender, EventArgs e)
        {
            new InsertPaymentTypeController().validateInsertPaymentType(txtPaymentType, lblErrorPaymentType);

        }
    }
}