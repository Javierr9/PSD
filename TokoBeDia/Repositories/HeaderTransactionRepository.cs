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
        public object GetDataJoinMember(int UserId) {

            var Join = from ht in db.HeaderTransactions
                       where ht.UserID == UserId
                       join dt in db.DetailTransactions on ht.ID equals dt.TransactionID
                       join p in db.Products on dt.ProductID equals p.ID
                       join pt in db.PaymentTypes on ht.PaymentTypeID equals pt.ID
                       select new
                       {
                           ht.Date,
                           pt.Type,
                           p.Name,
                           dt.Quantity,
                           Subtotal = dt.Quantity * p.Price
                       };

            return Join.ToList();
        }
    }
}