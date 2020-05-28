using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Models;

namespace TokoBeDia.Factories
{
    public class ProductTypeFactory
    {
        public ProductType CreateProduct(string name, string description)
        {
            ProductType newProduct = new ProductType
            {
                Name = name,
                Description = description
            };
            return newProduct;
        }
    }
}