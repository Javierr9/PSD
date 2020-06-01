using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Handlers;
using TokoBeDia.Factories;
using TokoBeDia.Models;

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