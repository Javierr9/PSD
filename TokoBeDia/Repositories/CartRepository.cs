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
            db.Carts.Add(carts);
            db.SaveChanges();
        }

    }
}