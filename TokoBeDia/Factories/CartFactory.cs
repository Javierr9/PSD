using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Models;
<<<<<<< HEAD

=======
>>>>>>> Jav
namespace TokoBeDia.Factories
{
    public class CartFactory
    {
<<<<<<< HEAD
        public static Cart CreateCartData(int UserId, int ProductId, int Quantity)
        {

=======
        public static Cart CreateCartData(int UserId, int ProductId, int Quantity)
        {
>>>>>>> Jav
            Cart newCart = new Cart();
            newCart.UserID = UserId;
            newCart.ProductID = ProductId;
            newCart.Quantity = Quantity;
            return newCart;
        }
    }
}