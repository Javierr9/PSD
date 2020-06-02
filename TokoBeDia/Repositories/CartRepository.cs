using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Models;

namespace TokoBeDia.Repositories
{
    
    public class CartRepository
    {
        private static TokoBeDiaEntities db = new TokoBeDiaEntities();
        public static void AddToCart(Cart carts)
        {
            bool check = db.Carts.Any(x => x.UserID == carts.UserID && x.ProductID == carts.ProductID);
            if(check == true)
            {
                Cart existingCart = db.Carts.Where(x => x.UserID == carts.UserID && x.ProductID == carts.ProductID).FirstOrDefault();
                existingCart.Quantity += carts.Quantity;
                db.SaveChanges(); 
            }
            else
            {
                db.Carts.Add(carts);
                db.SaveChanges();
            }
            
        }

    }
}