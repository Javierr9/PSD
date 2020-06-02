using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Handlers;

namespace TokoBeDia.Views
{
    public partial class ViewCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserEmail"] == null && Convert.ToInt32(Session["RoleId"]) != 1)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                int UserId = Int32.Parse(Session["UserID"].ToString());
                CartHandler.updateDataJoin(gridCart, UserId);
                int GrandTotal = 0;
                gridCart.Columns[5].Visible = true;
                for (int i = 0; i < gridCart.Rows.Count; ++i)
                {
                    GrandTotal += Convert.ToInt32(gridCart.Rows[i].Cells[4].Text.ToString());
                }
                grandTotalLabel.Text = "Grand Total = " + GrandTotal.ToString();
            }
        }
        protected void btnUpdate_click(object sender, EventArgs e)
        {

        }

    }
} 