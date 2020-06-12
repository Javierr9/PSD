using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using TokoBeDia.Controllers;

namespace TokoBeDia.Views
{
    public partial class UpdatePaymentType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserEmail"] == null && Convert.ToInt32(Session["RoleId"]) != 2)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                new UpdatePaymentTypeController().initPage(txtPaymentType);
            }
        }

        protected void btnUpdatePaymentType_Click(object sender, EventArgs e)
        {
            new UpdatePaymentTypeController().validateUpdatePaymentType(txtPaymentType, lblErrorPaymentType, lblSuccess);
            
        }
    }
}