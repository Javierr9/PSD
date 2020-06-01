using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Handlers;

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
                UpdateGridData();
            }
        }

        private void UpdateGridData()
        {
            gridPaymentType.DataSource = new PaymentTypeHandler().GetAllPaymentType();
            gridPaymentType.DataBind();
        }

        protected void btnInsertPaymentType_Click(object sender, EventArgs e)
        {
            Response.Redirect("InsertPaymentType.aspx");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            GridViewRow row = (sender as Button).NamingContainer as GridViewRow;

            Response.Redirect("UpdatePaymentType.aspx?paymenttypeid=" + row.Cells[0].Text);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}