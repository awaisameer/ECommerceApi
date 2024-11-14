using ECommerceApi.GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using HotChocolate;

namespace ECommerceApi.GraphQL.Queries
{
    public class CustomerQueries
    {
        private readonly ECommerceDbContext _dbContext;

        public CustomerQueries(ECommerceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Query to get a list of customers (materialized result)
        public List<Customer> GetCustomers() => _dbContext.Customers.ToList();

        // Query to get a customer by ID (materialized result)
        public Customer GetCustomerById(int id) => _dbContext.Customers.FirstOrDefault(c => c.CustomerId == id);
    }
}
