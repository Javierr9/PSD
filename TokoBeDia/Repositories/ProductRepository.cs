using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Models;

namespace TokoBeDia.Repositories
{
    public class ProductRepository : IProductRepository
    {
        TokoBeDiaEntities db = new TokoBeDiaEntities();
        public void InsertProduct(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
        }
        public List<Product> GetAllProduct()
        {
            List<Product> allProduct = db.Products.ToList();
            return allProduct;
        }

        public void UpdateProduct(Product newProduct, int ID)
        {
            Product currentProduct = db.Products.Where(x => x.ID == ID).FirstOrDefault();
            currentProduct.Name = newProduct.Name;
            currentProduct.Stock = newProduct.Stock;
            currentProduct.Price = newProduct.Price;
            currentProduct.ProductTypeID = newProduct.ProductTypeID;
            db.SaveChanges(); 
        }

        public Product GetProductByID(int ID)
        {
            Product product = db.Products.Where(x => x.ID == ID).FirstOrDefault();
            return product;
        }

        public bool GetReferencedDetailTransaction(int ID)
        {
            bool check = db.DetailTransactions.Any(x => x.ProductID == ID);
            return check;
        }

        public void DeleteProduct(int ID)
        {
            Product deleteProduct = db.Products.Where(x => x.ID == ID).FirstOrDefault();
            if(deleteProduct != null)
            {
                db.Products.Remove(deleteProduct);
                db.SaveChanges();
            }
        }
    }
}