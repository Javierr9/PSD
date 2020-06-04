using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Repositories;
using TokoBeDia.Factories;
using TokoBeDia.Models;
using System.Web.UI.WebControls;

namespace TokoBeDia.Handlers
{
    public class CartHandler
    {
        public static void AddToCart(int UserId, int ProductId, int Quantity)
        {
           Cart newCart = new CartFactory().CreateCartData(UserId, ProductId, Quantity);
           CartRepository.AddToCart(newCart);
        }
        public static void updateDataJoin(GridView CartGrid, int UserId)
        {
            CartGrid.DataSource = CartRepository.GetDataJoin(UserId);
            CartGrid.DataBind();
        }
        public static void UpdateCart(int UserId, int ProductId, int Quantity)
        {
            CartRepository.UpdateCartById(UserId, ProductId, Quantity);
        }
        public Cart GetCartByTwoId(int UserId, int ProductId)
        {
            Cart newCart = new CartRepository().GetCardByTwoId(UserId, ProductId);
            return newCart;
        }
        public int CountListByProductId(int ProductID)
        {
            int listAmount = new CartRepository().CountListByProductId(ProductID);
            return listAmount;
        }
        public void DeleteCart(int UserID, int ProductID)
        {
           new CartRepository().DeleteCart(UserID, ProductID);
        }
        public bool checkCartIsEmpty(int userID)
        {
            List<Cart> check = new CartRepository().GetCartByUserId(userID);
            if (check.Count > 0)
            {
                return false;
            }
            else return true;
        }

        public void DeleteAllCartByUserID(int userID)
        {
            List<Cart> cartByUserID = new CartRepository().GetCartByUserId(userID);

            foreach (var item in cartByUserID)
            {
                new CartRepository().DeleteCart(userID, item.ProductID);
            }
        }

        public void InsertDTransaction(int transactionID, int userID)
        {
            List<Cart> cartByUserID = new CartRepository().GetCartByUserId(userID);

            foreach (var item in cartByUserID)
            {
                DetailTransaction newDT = new DetailTransactionFactory().CreateDetailTransaction(transactionID, item.ProductID, item.Quantity);
                new DetailTransactionRepository().InsertDTransaction(newDT);
            }

        }
    }
}