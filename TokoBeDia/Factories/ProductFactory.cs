using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Models;

namespace TokoBeDia.Factories
{
    public class ProductFactory
    {
        public Product CreateProduct(int productTypeID, string name, int price, int stock)
        {
            Product newProduct = new Product
            {
                ProductTypeID = productTypeID,
                Name = name,
                Price = price,
                Stock = stock
            };
            return newProduct;
        }
    }
}