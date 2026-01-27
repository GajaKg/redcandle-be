using API.Data;
using API.Dtos.Customer;
using API.Dtos.Order;
using API.Interfaces;
using API.Mappers;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDBContext _context;
        public CustomerRepository(ApplicationDBContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<List<CustomerDto>> GetAllAsync()
        {
            return await _context.Customers
                .AsNoTracking()
                .Select(c => new CustomerDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Address = c.Address,
                    Contact = c.Contact,
                    Note = c.Note,
                    Orders = c.CustomerOrders.Select(o => new CustomerOrderDto
                    {
                        Id = o.Id,
                        Date = o.Date,
                        Paid = o.Paid,
                        Delivered = o.Delivered,
                        Note = o.Note,
                        Products = o.OrderProducts.Select(op => new OrderProductDto
                        {
                            ProductId = op.ProductId,
                            ProductName = op.Product.Name,
                            Quantity = op.Quantity
                        }).ToList()
                    }).ToList()
                })
                .ToListAsync();
        }



        public async Task<Customer> CreateAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer?> DeleteAsync(int id)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == id);

            if (customer == null)
            {
                return null;
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<CustomerDto?> GetByIdAsync(int id)
        {
            return await _context.Customers
                .Where(c => c.Id == id)
                .Select(c => new CustomerDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Address = c.Address,
                    Contact = c.Contact,
                    Note = c.Note,
                    Orders = c.CustomerOrders.Select(o => o.ToCustomerOrderDto()).ToList()
                })
                .FirstOrDefaultAsync();
        }

        public async Task<Customer?> UpdateAsync(int id, CustomerUpdateDto customerUpdateDto)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == id);

            if (customer == null)
            {
                return null;
            }

            customer.Name = customerUpdateDto.Name;
            customer.Address = customerUpdateDto.Address;
            customer.Contact = customerUpdateDto.Contact;
            customer.Note = customerUpdateDto.Note;

            await _context.SaveChangesAsync();

            return customer;
        }
    }
}