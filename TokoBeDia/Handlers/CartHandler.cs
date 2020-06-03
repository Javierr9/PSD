using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Repositories;
using TokoBeDia.Factories;
using TokoBeDia.Models;
<<<<<<< HEAD
=======
using System.Web.UI.WebControls;
>>>>>>> Jav

namespace TokoBeDia.Handlers
{
    public class CartHandler
    {
        public static void AddToCart(int UserId, int ProductId, int Quantity)
        {
<<<<<<< HEAD
           Cart newCart = CartFactory.CreateCartData(UserId, ProductId, Quantity);
           CartRepository.AddToCart(newCart);
        }
=======
           Cart newCart = new CartFactory().CreateCartData(UserId, ProductId, Quantity);
           CartRepository.AddToCart(newCart);
        }
        public static void updateDataJoin(GridView CartGrid, int UserId)
        {
            CartGrid.DataSource = CartRepository.GetDataJoin(UserId);
            CartGrid.DataBind();
        }

>>>>>>> Jav
    }
}