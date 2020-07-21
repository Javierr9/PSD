using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using TokoBeDia.Models;
using TokoBeDia.Factories;
using TokoBeDia.Handlers;

namespace TokoBeDia.Controllers
{
    public class UpdatePaymentTypeController
    {
        public void validateUpdatePaymentType(TextBox txtPaymentType, Label lblErrorPaymentType, Label lblSuccess)
        {
            int ID = Convert.ToInt32(HttpContext.Current.Request.QueryString["paymenttypeid"]);
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

        public void initPage(TextBox txtPaymentType)
        {
            int ID = Convert.ToInt32(HttpContext.Current.Request.QueryString["paymenttypeid"]);

            PaymentType currentData = new PaymentTypeHandler().GetPaymentTypeByID(ID);
            txtPaymentType.Text = currentData.Type;
        }
    }
}