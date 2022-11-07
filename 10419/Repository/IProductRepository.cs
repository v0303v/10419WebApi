using _10419.Model;
using System.Collections.Generic;

namespace _10419.Repository
{
    public interface IProductRepository
    {
        void InsertProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int Id);
        Product GetProductById(int Id);
        IEnumerable<Product> GetProducts();
    }
}
