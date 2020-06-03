using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Models;
using TokoBeDia.Repositories;

namespace TokoBeDia.Handlers
{
    public class ProductHandler
    {
        public void InsertProduct(Product product)
        {
            new ProductRepository().InsertProduct(product);
        }
        public List<Product> GetAllProduct()
        {
            return new ProductRepository().GetAllProduct();
        }

        public void UpdateProduct(Product newProduct, int ID)
        {
            new ProductRepository().UpdateProduct(newProduct, ID);
        }

        public Product GetProductByID(int ID)
        {
            return new ProductRepository().GetProductByID(ID);
        }

        public bool GetReferencedDetailTransaction(int ID)
        {
            return new ProductRepository().GetReferencedDetailTransaction(ID);
        }

        public void DeleteProduct(int ID)
        {
            new ProductRepository().DeleteProduct(ID);
        }

        public void SubstractProductStockById(int ProductID, int Quantity)
        {
            Product Substract = new ProductRepository().GetProductByID(ProductID);
            Substract.Stock -= Quantity;
            new ProductRepository().UpdateProduct(Substract, ProductID);
        }
        public void AddProductStockById(int ProductID, int Quantity)
        {
            Product Substract = new ProductRepository().GetProductByID(ProductID);
            Substract.Stock += Quantity;
            new ProductRepository().UpdateProduct(Substract, ProductID);
        }

    }
}