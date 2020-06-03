using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
<<<<<<< HEAD
=======
using TokoBeDia.Handlers;
>>>>>>> Jav

namespace TokoBeDia.Views
{
    public partial class ViewCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserEmail"] == null || Convert.ToInt32(Session["RoleId"]) != 1)
            {
                Response.Redirect("Login.aspx");
            }
<<<<<<< HEAD
            else
            {

            }
        }
    }
}
=======
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
            int ID = Convert.ToInt32(row.Cells[0].Text);

            //bool check = new ProductHandler().GetReferencedDetailTransaction(ID);
            //if (check == true)
            //{
            //    lblErrorDelete.Visible = true;
            //    return;
            //}

            //new ProductHandler().DeleteProduct(ID);

        }
    }
} 
>>>>>>> Jav
