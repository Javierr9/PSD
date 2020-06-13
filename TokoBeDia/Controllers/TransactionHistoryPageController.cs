using System;
using TokoBeDia.Handlers;
using System.Web.UI.WebControls;

namespace TokoBeDia.Controllers
{
    public class TransactionHistoryPageController
    {
        public void InitPage(object roleID, object userID, GridView gridTransaction ){
            if (Convert.ToInt32(roleID) == 1)//Member
            {
                int UserId = Int32.Parse(userID.ToString());
                HeaderTransasctionHandler.updateGridDataMember(gridTransaction, UserId);
            }
            else if (Convert.ToInt32(roleID) == 2)//Admin
            {
                gridTransaction.Columns[0].Visible = true; ;
                HeaderTransasctionHandler.updateGridDataAdmin(gridTransaction);
            }
        }

    
    }
}