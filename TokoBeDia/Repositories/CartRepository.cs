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
<<<<<<< HEAD

    }
=======
        public List<Cart> GetAllCart()
        {
            List<Cart> allCart = db.Carts.ToList();
            return allCart;

        }
        public static object GetDataJoin(int UserId) {

            var Join = from c in db.Carts
                       where c.UserID == UserId
                       join u in db.Users on c.UserID equals u.ID
                       join p in db.Products on c.ProductID equals p.ID
                       select new
                       {
                           p.ID,
                           p.Name,
                           p.Price,
                           c.Quantity,
                           Subtotal = c.Quantity * p.Price 
                       };
            return Join.ToList();
        }
        public static void UpdateCartById(int UserId, int ProductId, int Quantity)
        {
            Cart existingCart = db.Carts.Where(x => x.UserID == UserId && x.ProductID == ProductId).FirstOrDefault();
            existingCart.Quantity = Quantity;
            db.SaveChanges();
        }
        public Cart GetCardByTwoId(int UserId, int ProductId)
        {
            Cart newCart = db.Carts.Where(x => x.UserID == UserId && x.ProductID == ProductId).FirstOrDefault();
            return newCart;
        }

        public int CountListByProductId(int ProductID)
        {
            List<Cart> targetedCart = db.Carts.Where(c => c.ProductID == ProductID).ToList();
            int ListAmount = targetedCart.Sum(x => x.Quantity);
            return ListAmount;
        }

        public void DeleteCart(int UserID, int ProductId)
        {
            Cart deleteCart = db.Carts.Where(x => x.UserID == UserID && x.ProductID == ProductId).FirstOrDefault();
            if (deleteCart != null)
            {
                db.Carts.Remove(deleteCart);
                db.SaveChanges();
            }
        }

        public List<Cart> GetCartByUserId(int userId)
        {
            List<Cart> cartUserId = db.Carts.Where(x => x.UserID == userId).ToList();
            return cartUserId;
        }
    }
    
>>>>>>> Jav
}