using ECommerceApi.GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using HotChocolate;

namespace ECommerceApi.GraphQL.Queries
{
    public class ProductQueries
    {
        private readonly ECommerceDbContext _dbContext;

        public ProductQueries(ECommerceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Query to get a list of products (materialized result)
        public List<Product> GetProducts() => _dbContext.Products.ToList();

        // Query to get a product by ID (materialized result)
        public Product GetProductById(int id) => _dbContext.Products.FirstOrDefault(p => p.ProductId == id);
    }
}
