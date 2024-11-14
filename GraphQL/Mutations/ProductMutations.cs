using ECommerceApi.GraphQL.Types;
using HotChocolate;

namespace ECommerceApi.GraphQL.Mutations
{
    public class ProductMutations
    {
        private readonly ECommerceDbContext _dbContext;

        public ProductMutations(ECommerceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Mutation to add a new product (Create)
        public async Task<Product> AddProductAsync(
            string name,
            string description,
            decimal price,
            int stockQuantity)
        {
            var product = new Product
            {
                Name = name,
                Description = description,
                Price = price,
                StockQuantity = stockQuantity
            };

            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();

            return product;  // Return the added product
        }

        // Mutation to update an existing product (Update)
        public async Task<Product> UpdateProductAsync(
            int productId,
            string name,
            string description,
            decimal price,
            int stockQuantity)
        {
            var product = await _dbContext.Products.FindAsync(productId);

            if (product != null)
            {
                product.Name = name;
                product.Description = description;
                product.Price = price;
                product.StockQuantity = stockQuantity;

                await _dbContext.SaveChangesAsync();

                return product;  // Return the updated product
            }

            return null;  // Return null if product not found
        }

        // Mutation to delete a product by ID (Delete)
        public async Task<bool> DeleteProductAsync(int productId)
        {
            var product = await _dbContext.Products.FindAsync(productId);

            if (product != null)
            {
                _dbContext.Products.Remove(product);
                await _dbContext.SaveChangesAsync();
                return true;  // Return true if deletion is successful
            }

            return false;  // Return false if product not found
        }

       
    }
}
