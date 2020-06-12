using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using System.Web;
using TokoBeDia.Models;
using TokoBeDia.Handlers;


namespace TokoBeDia.Controllers
{
    public class ViewCartController
    {
        public void InitPage(object RoleId, object UserID, GridView gridCart, Label grandTotalLabel, DropDownList ddlPaymentType)
        {
            if (Convert.ToInt32(RoleId) == 1 && UserID != null)
            {
                int UserId = Int32.Parse(UserID.ToString());
                CartHandler.updateDataJoin(gridCart, UserId);
                int GrandTotal = 0;
                gridCart.Columns[5].Visible = true;
                for (int i = 0; i < gridCart.Rows.Count; ++i)
                {
                    GrandTotal += Convert.ToInt32(gridCart.Rows[i].Cells[4].Text.ToString());
                }
                grandTotalLabel.Text = "Grand Total = " + GrandTotal.ToString();

                List<PaymentType> dataPT = new PaymentTypeHandler().GetAllPaymentType();
                ddlPaymentType.DataSource = dataPT;
                ddlPaymentType.DataTextField = "Type";
                ddlPaymentType.DataValueField = "ID";
                ddlPaymentType.DataBind();
            }
        }
        
        public void UpdateCart(object sender)
        {
            GridViewRow row = (sender as Button).NamingContainer as GridViewRow;
            int ID = Convert.ToInt32(row.Cells[0].Text);
            HttpContext.Current.Response.Redirect("UpdateCartPage.aspx?ProductID=" + ID);
        }

        public void DeleteCart(object sender, object UserID, GridView gridCart, Label grandTotalLabel)
        {
            GridViewRow row = (sender as Button).NamingContainer as GridViewRow;
            int ProductID = Convert.ToInt32(row.Cells[0].Text);
            int UserId = Int32.Parse(UserID.ToString());
            int QuantityInCart = Convert.ToInt32(row.Cells[3].Text);

            new CartHandler().DeleteCart(UserId, ProductID);
            new ProductHandler().AddProductStockById(ProductID, QuantityInCart);
            CartHandler.updateDataJoin(gridCart, UserId);
            int GrandTotal = 0;
            gridCart.Columns[5].Visible = true;
            for (int i = 0; i < gridCart.Rows.Count; ++i)
            {
                GrandTotal += Convert.ToInt32(gridCart.Rows[i].Cells[4].Text.ToString());
            }
            grandTotalLabel.Text = "Grand Total = " + GrandTotal.ToString();
        }

        public void CheckoutCart(object UserID, DropDownList ddlPaymentType, Label lblErrorCheckout)
        {
            int userId = Int32.Parse(UserID.ToString());
            int paymentId = Convert.ToInt32(ddlPaymentType.SelectedValue);
            DateTime now = DateTime.Now;

            bool check = new CartHandler().checkCartIsEmpty(userId);
            if (check == true)
            {
                lblErrorCheckout.Visible = true;
                return;
            }
            else
            {
                lblErrorCheckout.Visible = false;

                new HeaderTransasctionHandler().InsertHTransaction(userId, paymentId, now);
                int transactionID = new HeaderTransasctionHandler().GetLastTransactionID();
                new DetailTransactionHandler().InsertDTransaction(transactionID, userId);
                new CartHandler().DeleteAllCartByUserID(userId);
            }
        }
    }
}