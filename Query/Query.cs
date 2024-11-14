namespace ECommerceApi.GraphQL
{
    public class Query
    {
        public IQueryable<Product> GetProducts([Service] ECommerceDbContext dbContext) =>
            dbContext.Products;

        public IQueryable<Customer> GetCustomers([Service] ECommerceDbContext dbContext) =>
            dbContext.Customers;

        public IQueryable<Order> GetOrders([Service] ECommerceDbContext dbContext) =>
            dbContext.Orders;
    }
}
