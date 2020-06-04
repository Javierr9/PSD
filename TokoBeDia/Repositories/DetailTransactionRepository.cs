using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Models;

namespace TokoBeDia.Repositories
{
    public class DetailTransactionRepository
    {
        TokoBeDiaEntities db = new TokoBeDiaEntities();
        public void InsertDTransaction(DetailTransaction newDT)
        {
            db.DetailTransactions.Add(newDT);
            db.SaveChanges();
        }
    }
}