using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Models;
using TokoBeDia.Factories;
using TokoBeDia.Repositories;

namespace TokoBeDia.Handlers
{
    public class DetailTransactionHandler
    {
        public void InsertDTransaction(int transactionID, int userID)
        {
            List<Cart> cartByUserID = new CartRepository().GetCartByUserId(userID);

            foreach(var item in cartByUserID)
            {
                DetailTransaction newDT = new DetailTransactionFactory().CreateDetailTransaction(transactionID, item.ProductID, item.Quantity);
                new DetailTransactionRepository().InsertDTransaction(newDT);
            }
            
        }
    }
}