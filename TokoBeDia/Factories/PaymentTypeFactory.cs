using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Models;

namespace TokoBeDia.Factories
{
    public class PaymentTypeFactory
    {
        public PaymentType CreatePaymentType(string type)
        {
            PaymentType newPaymentType = new PaymentType
            {
                Type = type
            };
            return newPaymentType;
        }
    }
}