using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TokoBeDia.Models;

namespace TokoBeDia.Repositories
{
    interface IPaymentTypeRepository
    {
        void InsertPaymentType(PaymentType paymentType);
        bool GetSameNameInsert(string name);
        List<PaymentType> GetSameNameUpdate(string name);
        List<PaymentType> GetAllPaymentType();
        PaymentType GetPaymentTypeByID(int ID);
        void UpdatePaymentType(PaymentType newPT, int currentID);
        bool GetReferencedHeader(int ID);
        void DeletePaymentType(int ID);
    }
}
