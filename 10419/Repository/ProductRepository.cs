using _10419.DbContexts;
using _10419.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace _10419.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _dbContext;
        public ProductRepository(ProductContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteProduct(int Id)
        {
            var product = _dbContext.Products.Find(Id);
            _dbContext.Products.Remove(product);
            Save();
        }
        public Product GetProductById(int Id)
        {
            var prod = _dbContext.Products.Find(Id);
            _dbContext.Entry(prod).Reference(s => s.ProductCategory).Load();
            return prod;
        }
        public IEnumerable<Product> GetProducts()
        {
            return _dbContext.Products.Include(s => s.ProductCategory).ToList();
        }
        public void InsertProduct(Product product)
        {
            _dbContext.Add(product);
            Save();
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
        public void UpdateProduct(Product product)
        {
            _dbContext.Entry(product).State =
            Microsoft.EntityFrameworkCore.EntityState.Modified;
            Save();
        }

    }
}
