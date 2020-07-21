using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Models;

namespace TokoBeDia.Factories
{
    public class DetailTransactionFactory
    {
        public DetailTransaction CreateDetailTransaction(int transactionID, int productID, int quantity)
        {
            DetailTransaction newDT = new DetailTransaction
            {
                TransactionID = transactionID,
                ProductID = productID,
                Quantity = quantity
            };
            return newDT;
        }
    }
}