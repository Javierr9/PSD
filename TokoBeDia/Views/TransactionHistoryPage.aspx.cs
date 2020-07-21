using System;
using TokoBeDia.Controllers;

namespace TokoBeDia.Views
{
    public partial class TransactionHistoryPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["UserEmail"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            new TransactionHistoryPageController().InitPage(Session["RoleId"], Session["UserID"], gridTransaction);
        }
    }
}