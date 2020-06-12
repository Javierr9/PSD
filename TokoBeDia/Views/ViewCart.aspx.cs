using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Handlers;
using TokoBeDia.Models;
using TokoBeDia.Controllers;

namespace TokoBeDia.Views
{
    public partial class ViewCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserEmail"] == null || Convert.ToInt32(Session["RoleId"]) != 1)
            {
                Response.Redirect("Login.aspx");
            }else
            {
                int User = Int32.Parse(Session["UserID"].ToString());
                CartHandler.updateDataJoin(gridCart, User);
            }

            if (!IsPostBack)
            {
                new ViewCartController().InitPage(Session["RoleId"], Session["UserID"], gridCart, grandTotalLabel, ddlPaymentType);

            }
        }
        protected void btnUpdate_click(object sender, EventArgs e)
        {
            new ViewCartController().UpdateCart(sender);

        }
        protected void btnDelete_click(object sender, EventArgs e)
        {
            new ViewCartController().DeleteCart(sender, Session["UserID"],gridCart, grandTotalLabel);
        }

        protected void btnCheckout_Click(object sender, EventArgs e)
        {
            new ViewCartController().CheckoutCart(Session["UserID"], ddlPaymentType, lblErrorCheckout);

        }
    }
} 