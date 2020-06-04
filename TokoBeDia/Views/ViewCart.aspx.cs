using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Handlers;
using TokoBeDia.Models;

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

                if (Convert.ToInt32(Session["RoleId"]) == 1 && Session["UserID"] != null){
                    int UserId = Int32.Parse(Session["UserID"].ToString());
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
        }
        protected void btnUpdate_click(object sender, EventArgs e)
        {
            GridViewRow row = (sender as Button).NamingContainer as GridViewRow;
            int ID = Convert.ToInt32(row.Cells[0].Text);
            Response.Redirect("UpdateCartPage.aspx?ProductID=" + ID);

        }
        protected void btnDelete_click(object sender, EventArgs e)
        {
            GridViewRow row = (sender as Button).NamingContainer as GridViewRow;
            int ProductID = Convert.ToInt32(row.Cells[0].Text);
            int UserId = Int32.Parse(Session["UserID"].ToString());
            int QuantityInCart = Convert.ToInt32(row.Cells[3].Text);

            //bool check = new CartHandler().GetReferenced(ID);
            //if (check == true)
            //{
            //    lblErrorDelete.Visible = true;
            //    return;
            //}

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

        protected void btnCheckout_Click(object sender, EventArgs e)
        {
            int userId = Int32.Parse(Session["UserID"].ToString());
            int paymentId = Convert.ToInt32(ddlPaymentType.SelectedValue);
            DateTime now = DateTime.Now;

            bool check = new CartHandler().checkCartIsEmpty(userId);
            if(check == true)
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