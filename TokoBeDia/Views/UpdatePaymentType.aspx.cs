using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Models;
using TokoBeDia.Factories;
using TokoBeDia.Handlers;

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
                int ID = Convert.ToInt32(Request.QueryString["paymenttypeid"]);

                PaymentType currentData = new PaymentTypeHandler().GetPaymentTypeByID(ID);
                txtPaymentType.Text = currentData.Type;
            }
        }

        protected void btnUpdatePaymentType_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(Request.QueryString["paymenttypeid"]);
            string name = txtPaymentType.Text;

            List<PaymentType> check = new PaymentTypeHandler().GetSameNameUpdate(name);
            int flag = 0;
            foreach (var item in check)
            {
                if (item.ID != ID)
                {
                    flag = 1;
                    break;
                }
            }
            if (flag == 1)
            {
                lblErrorPaymentType.Visible = true;
                return;
            }

            PaymentType newPaymentType = new PaymentTypeFactory().CreatePaymentType(name);
            new PaymentTypeHandler().UpdatePaymentType(newPaymentType, ID);

            lblSuccess.Visible = true;
            lblErrorPaymentType.Visible = false;
        }
    }
}