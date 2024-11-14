using HotChocolate;

namespace ECommerceApi.GraphQL.Mutations
{
    public class CustomerMutations
    {
        private readonly ECommerceDbContext _dbContext;

        public CustomerMutations(ECommerceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Mutation to add a new customer
        public async Task<Customer> AddCustomerAsync(
            string name,
            string email,
            string phoneNumber,
            string address)
        {
            var customer = new Customer
            {
                Name = name,
                Email = email,
                PhoneNumber = phoneNumber,
                Address = address
            };

            _dbContext.Customers.Add(customer);
            await _dbContext.SaveChangesAsync();

            return customer;  // Return the added customer
        }

        // Mutation to update an existing customer
        public async Task<Customer> UpdateCustomerAsync(
            int customerId,
            string name,
            string email,
            string phoneNumber,
            string address)
        {
            var customer = await _dbContext.Customers.FindAsync(customerId);

            if (customer != null)
            {
                customer.Name = name;
                customer.Email = email;
                customer.PhoneNumber = phoneNumber;
                customer.Address = address;

                await _dbContext.SaveChangesAsync();

                return customer;  // Return the updated customer
            }

            return null;  // Return null if customer not found
        }
    }
}
