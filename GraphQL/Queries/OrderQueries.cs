using HotChocolate;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApi.GraphQL.Queries
{
    public class OrderQueries
    {
        private readonly ECommerceDbContext _dbContext;

        public OrderQueries(ECommerceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Query to get all orders
        public List<Order> GetAllOrders()
        {
            return _dbContext.Orders.ToList();
        }

        // Query to get an order by ID
        public Order GetOrderById(int orderId)
        {
            return _dbContext.Orders.FirstOrDefault(o => o.OrderId == orderId);
        }

        // Query to get orders by customer ID
        public List<Order> GetOrdersByCustomerId(int customerId)
        {
            return _dbContext.Orders.Where(o => o.CustomerId == customerId).ToList();
        }
    }
}
