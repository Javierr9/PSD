using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TokoBeDia.Models;

namespace TokoBeDia.Repositories
{
    public class ProductTypeRepository : IProductTypeRepository
    {
        TokoBeDiaEntities db = new TokoBeDiaEntities();
            
        public void InsertProductType(ProductType productType)
        {
            db.ProductTypes.Add(productType);
            db.SaveChanges();
        }
        public bool GetSameNameInsert(string name)
        {
            bool check = db.ProductTypes.Any(x => x.Name == name);
            return check;
        }
        public List<ProductType> GetSameNameUpdate(string name)
        {
            List<ProductType> check = db.ProductTypes.SqlQuery("SELECT * FROM dbo.ProductTypes WHERE Name = @name", new SqlParameter("@name", name)).ToList();
            return check;
        }
        public List<ProductType> GetAllProductType()
        {
            List<ProductType> allPT =  db.ProductTypes.ToList();
            return allPT;
        }
        public ProductType GetProductTypeByID(int id)
        {
            ProductType data = db.ProductTypes.Where(x => x.ID == id).FirstOrDefault();
            return data;
        }

        public void UpdateProductType(ProductType newPT, int currentID)
        {
            ProductType currentPT = db.ProductTypes.Where(x => x.ID == currentID).FirstOrDefault();
            currentPT.Name = newPT.Name;
            currentPT.Description = newPT.Description;
            db.SaveChanges();
        }
        public bool GetReferencedProduct(int ID)
        {
            bool check = db.Products.Any(x => x.ProductTypeID == ID);
            return check;
        }

        public void DeleteProductType(int ID)
        {
            ProductType deletePT = db.ProductTypes.Where(x => x.ID == ID).FirstOrDefault();
            if(deletePT != null)
            {
                db.ProductTypes.Remove(deletePT);
                db.SaveChanges();
            }
        }
    }
}