using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Models;

namespace TokoBeDia.Factories
{
    public class CartFactory
    {
        public static Cart CreateCartData(int UserId, int ProductId, int Quantity)
        {

            Cart newCart = new Cart();
            newCart.UserID = UserId;
            newCart.ProductID = ProductId;
            newCart.Quantity = Quantity;
            return newCart;
        }
    }
}