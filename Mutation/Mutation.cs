using HotChocolate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace ECommerceApi.GraphQL
{
    public class Mutation
    {
        private readonly ECommerceDbContext _dbContext;

        public Mutation(ECommerceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Product mutations
        // Create Product
        public async Task<Product> AddProductAsync(string name, string description, decimal price, int stockQuantity)
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
            return product;
        }

        // Update Product
        public async Task<Product> UpdateProductAsync(int productId, string name, string description, decimal price, int stockQuantity)
        {
            var product = await _dbContext.Products.FindAsync(productId);

            if (product != null)
            {
                product.Name = name;
                product.Description = description;
                product.Price = price;
                product.StockQuantity = stockQuantity;

                await _dbContext.SaveChangesAsync();
                return product;
            }
            return null;
        }

        // Delete Product
        public async Task<bool> DeleteProductAsync(int productId)
        {
            var product = await _dbContext.Products.FindAsync(productId);

            if (product != null)
            {
                _dbContext.Products.Remove(product);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        // Customer mutations
        // Create Customer
        public async Task<Customer> AddCustomerAsync(string name, string email, string phoneNumber, string address)
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
            return customer;
        }

        // Update Customer
        public async Task<Customer> UpdateCustomerAsync(int customerId, string name, string email, string phoneNumber, string address)
        {
            var customer = await _dbContext.Customers.FindAsync(customerId);

            if (customer != null)
            {
                customer.Name = name;
                customer.Email = email;
                customer.PhoneNumber = phoneNumber;
                customer.Address = address;

                await _dbContext.SaveChangesAsync();
                return customer;
            }
            return null;
        }

        // Delete Customer
        public async Task<bool> DeleteCustomerAsync(int customerId)
        {
            var customer = await _dbContext.Customers.FindAsync(customerId);

            if (customer != null)
            {
                _dbContext.Customers.Remove(customer);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        // Order mutations
        // Create Order
        public async Task<Order> AddOrderAsync(int customerId, DateTime orderDate, decimal totalAmount)
        {
            var order = new Order
            {
                CustomerId = customerId,
                OrderDate = orderDate,
                TotalAmount = totalAmount
            };

            _dbContext.Orders.Add(order);
            await _dbContext.SaveChangesAsync();
            return order;
        }

        // Update Order
        public async Task<Order> UpdateOrderAsync(int orderId, int customerId, DateTime orderDate, decimal totalAmount)
        {
            var order = await _dbContext.Orders.FindAsync(orderId);

            if (order != null)
            {
                order.CustomerId = customerId;
                order.OrderDate = orderDate;
                order.TotalAmount = totalAmount;

                await _dbContext.SaveChangesAsync();
                return order;
            }
            return null;
        }

        // Delete Order
        public async Task<bool> DeleteOrderAsync(int orderId)
        {
            var order = await _dbContext.Orders.FindAsync(orderId);

            if (order != null)
            {
                _dbContext.Orders.Remove(order);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
