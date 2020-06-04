using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Models;
using TokoBeDia.Repositories;
using TokoBeDia.Factories;

namespace TokoBeDia.Handlers
{
    public class HeaderTransasctionHandler
    {
        public void InsertHTransaction(int userID, int paymentTypeID, DateTime date)
        {
            HeaderTransaction newHT = new HeaderTransactionFactory().CreateHeaderTransaction(userID, paymentTypeID, date);
            new HeaderTransactionRepository().InsertHTransaction(newHT);
        }

        public int GetLastTransactionID()
        {
            return new HeaderTransactionRepository().GetLastTransactionID();
        }
    }
}