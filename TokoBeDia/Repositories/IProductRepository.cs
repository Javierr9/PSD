using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TokoBeDia.Models;


namespace TokoBeDia.Repositories
{
    interface IProductRepository
    {
        void InsertProduct(Product product);
        List<Product> GetAllProduct();
        void UpdateProduct(Product newProduct, int ID);
        Product GetProductByID(int ID);
        bool GetReferencedDetailTransaction(int ID);
        void DeleteProduct(int ID);
    }
}
