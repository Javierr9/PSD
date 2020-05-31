using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Models;
using TokoBeDia.Repositories;

namespace TokoBeDia.Handlers
{
    public class ProductTypeHandler
    {
        public void InsertProductType(ProductType productType)
        {
            new ProductTypeRepository().InsertProductType(productType);
        }
        public bool GetSameNameInsert(string name)
        {
            return new ProductTypeRepository().GetSameNameInsert(name);
        }
        public List<ProductType> GetSameNameUpdate(string name)
        {
            return new ProductTypeRepository().GetSameNameUpdate(name);
        }
        public List<ProductType> GetAllProductType()
        {
            return new ProductTypeRepository().GetAllProductType();
        }
        public ProductType GetProductTypeByID(int id)
        {
            return new ProductTypeRepository().GetProductTypeByID(id);
        }

        public void UpdateProductType(ProductType newPT, int currentID)
        {
            new ProductTypeRepository().UpdateProductType(newPT, currentID);
        }
        public bool GetReferencedProduct(int ID)
        {
            return new ProductTypeRepository().GetReferencedProduct(ID);
        }

        public void DeleteProductType(int ID)
        {
            new ProductTypeRepository().DeleteProductType(ID);
        }
    }
}