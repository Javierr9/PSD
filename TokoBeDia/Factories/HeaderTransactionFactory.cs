using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Models;

namespace TokoBeDia.Factories
{
    public class HeaderTransactionFactory
    {
        public HeaderTransaction CreateHeaderTransaction(int userID, int paymentTypeID, DateTime date)
        {
            HeaderTransaction newHT = new HeaderTransaction
            {
                UserID = userID,
                PaymentTypeID = paymentTypeID,
                Date = date
            };
            return newHT;
        }
    }
}