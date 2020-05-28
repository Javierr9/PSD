using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TokoBeDia.Models;

namespace TokoBeDia.Repositories
{
    interface IProductTypeRepository
    {
        void InsertProductType(ProductType productType);
        bool GetSameNameInsert(string name);
        List<ProductType> GetSameNameUpdate(string name);
        List<ProductType> GetAllProductType();
        ProductType GetProductTypeByID(int ID);
        void UpdateProductType(ProductType newPT, int currentID);
        bool GetReferencedProduct(int ID);
        void DeleteProductType(int ID);
    }
}
