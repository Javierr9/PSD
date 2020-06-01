using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TokoBeDia.Models;

namespace TokoBeDia.Repositories
{
    public class PaymentTypeRepository : IPaymentTypeRepository
    {
        TokoBeDiaEntities db = new TokoBeDiaEntities();

        public void InsertPaymentType(PaymentType paymentType)
        {
            db.PaymentTypes.Add(paymentType);
            db.SaveChanges();
        }
        public bool GetSameNameInsert(string name)
        {
            bool check = db.PaymentTypes.Any(x => x.Type == name);
            return check;
        }
        public List<PaymentType> GetSameNameUpdate(string name)
        {
            List<PaymentType> check = db.PaymentTypes.SqlQuery("SELECT * FROM dbo.PaymentTypes WHERE Type = @name", new SqlParameter("@name", name)).ToList();
            return check;
        }
        public List<PaymentType> GetAllPaymentType()
        {
            List<PaymentType> allPT = db.PaymentTypes.ToList();
            return allPT;
        }
        public PaymentType GetPaymentTypeByID(int id)
        {
            PaymentType data = db.PaymentTypes.Where(x => x.ID == id).FirstOrDefault();
            return data;
        }

        public void UpdatePaymentType(PaymentType newPT, int currentID)
        {
            PaymentType currentPT = db.PaymentTypes.Where(x => x.ID == currentID).FirstOrDefault();
            currentPT.Type = newPT.Type;
            db.SaveChanges();
        }
        public bool GetReferencedHeader(int ID)
        {
            bool check = db.HeaderTransactions.Any(x => x.PaymentTypeID == ID);
            return check;
        }

        public void DeletePaymentType(int ID)
        {
            PaymentType deletePT = db.PaymentTypes.Where(x => x.ID == ID).FirstOrDefault();
            if (deletePT != null)
            {
                db.PaymentTypes.Remove(deletePT);
                db.SaveChanges();
            }
        }
    }
}