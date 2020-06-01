using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Models;
using TokoBeDia.Repositories;

namespace TokoBeDia.Handlers
{
    public class PaymentTypeHandler
    {
        public void InsertPaymentType(PaymentType paymentType)
        {
            new PaymentTypeRepository().InsertPaymentType(paymentType);
        }
        public bool GetSameNameInsert(string name)
        {
            return new PaymentTypeRepository().GetSameNameInsert(name);
        }
        public List<PaymentType> GetSameNameUpdate(string name)
        {
            return new PaymentTypeRepository().GetSameNameUpdate(name);
        }
        public List<PaymentType> GetAllPaymentType()
        {
            return new PaymentTypeRepository().GetAllPaymentType();
        }
        public PaymentType GetPaymentTypeByID(int id)
        {
            return new PaymentTypeRepository().GetPaymentTypeByID(id);
        }

        public void UpdatePaymentType(PaymentType newPT, int currentID)
        {
            new PaymentTypeRepository().UpdatePaymentType(newPT, currentID);
        }
        public bool GetReferencedHeader(int ID)
        {
            return new PaymentTypeRepository().GetReferencedHeader(ID);
        }

        public void DeletePaymentType(int ID)
        {
            new PaymentTypeRepository().DeletePaymentType(ID);
        }
    }
}