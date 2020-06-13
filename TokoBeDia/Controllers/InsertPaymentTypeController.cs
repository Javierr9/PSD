using System.Web.UI.WebControls;
using TokoBeDia.Handlers;
using TokoBeDia.Factories;
using TokoBeDia.Models;

namespace TokoBeDia.Controllers
{
    public class InsertPaymentTypeController
    {
        public void validateInsertPaymentType(TextBox txtPaymentType, Label lblErrorPaymentType)
        {
            string name = txtPaymentType.Text;

            bool check = new ProductTypeHandler().GetSameNameInsert(name);
            if (check == true)
            {
                lblErrorPaymentType.Text = "Must be unique";
                return;
            }
            PaymentType newPaymentType = new PaymentTypeFactory().CreatePaymentType(name);
            new PaymentTypeHandler().InsertPaymentType(newPaymentType);
            lblErrorPaymentType.Text = "";
            txtPaymentType.Text = "";
        }
    }
}