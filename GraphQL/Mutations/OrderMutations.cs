using HotChocolate;

namespace ECommerceApi.GraphQL.Mutations
{
    public class OrderMutations
    {
        private readonly ECommerceDbContext _dbContext;

        public OrderMutations(ECommerceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Mutation to add a new order
        public async Task<Order> AddOrderAsync(
            int customerId,
            DateTime orderDate,
            decimal totalAmount)
        {
            var order = new Order
            {
                CustomerId = customerId,
                OrderDate = orderDate,
                TotalAmount = totalAmount
            };

            _dbContext.Orders.Add(order);
            await _dbContext.SaveChangesAsync();

            return order;  // Return the added order
        }

        // Mutation to update an existing order
        public async Task<Order> UpdateOrderAsync(
            int orderId,
            int customerId,
            DateTime orderDate,
            decimal totalAmount)
        {
            var order = await _dbContext.Orders.FindAsync(orderId);

            if (order != null)
            {
                order.CustomerId = customerId;
                order.OrderDate = orderDate;
                order.TotalAmount = totalAmount;

                await _dbContext.SaveChangesAsync();

                return order;  // Return the updated order
            }

            return null;  // Return null if order not found
        }
    }
}
