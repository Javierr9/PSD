using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Models;

namespace TokoBeDia.Repositories
{
    public class HeaderTransactionRepository
    {
        TokoBeDiaEntities db = new TokoBeDiaEntities();

        public void InsertHTransaction(HeaderTransaction newHT)
        {
            db.HeaderTransactions.Add(newHT);
            db.SaveChanges();
        }

        public int GetLastTransactionID()
        {
            HeaderTransaction getHT = db.HeaderTransactions.OrderByDescending(x => x.ID).FirstOrDefault();

            return getHT.ID;
        }
    }
}