using System.Web;
using System.Web.UI.WebControls;
using TokoBeDia.Handlers;

namespace TokoBeDia.Controllers
{
    public class ViewPaymentTypeController
    {
        public void UpdateGridData(GridView gridPaymentType)
        {
            gridPaymentType.DataSource = new PaymentTypeHandler().GetAllPaymentType();
            gridPaymentType.DataBind();
        }

        public void InsertPaymentType()
        {
            HttpContext.Current.Response.Redirect("InsertPaymentType.aspx");
        }

        public void UpdatePaymentType(object sender)
        {
            GridViewRow row = (sender as Button).NamingContainer as GridViewRow;

            HttpContext.Current.Response.Redirect("UpdatePaymentType.aspx?paymenttypeid=" + row.Cells[0].Text);
        }
    }
}