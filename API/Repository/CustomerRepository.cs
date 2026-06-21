using API.Data;
using API.Dtos.Customer;
using API.Dtos.Order;
using API.Helpers;
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

        public async Task<PagedList<CustomerDto>> GetAllAsync(OrderByParams orderByParams)
        {
            var query = _context.Customers.AsNoTracking().AsQueryable();
            query = orderByParams.OrderByDate == OrderByDate.Asc
                    ? query.OrderBy(c => c.Date)
                    : query.OrderByDescending(c => c.Date);

            var source = query.Select(c => c.ToCustomerDto());

            return await PagedList<CustomerDto>.CreateAsync(source, orderByParams.CurrentPage, orderByParams.PageSize);
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
                    Date = c.Date,
                })
                .FirstOrDefaultAsync();
        }

        public async Task<CustomerWithOrdersDto?> GetOrdersByCustomerIdAsync(int id, OrderByParams orderByParams)
        {

            var ordersQuery = _context.Orders
                                        .Include(o => o.OrderProducts)
                                            .ThenInclude(op => op.Product)
                                        .Where(o => o.CustomerId == id);

            ordersQuery =
                orderByParams.OrderByDate == OrderByDate.Asc
                    ? ordersQuery.OrderBy(o => o.Date)
                    : ordersQuery.OrderByDescending(o => o.Date);

            var pagedOrders = await PagedList<OrderDto>.CreateAsync(
                ordersQuery.Select(o => new OrderDto
                {
                    Id = o.Id,
                    Date = o.Date,
                    Paid = o.Paid,
                    Delivered = o.Delivered,
                    Note = o.Note,
                    OrderProducts = o.OrderProducts
                        .Select(op => new OrderProductDto
                        {
                            Id = op.ProductId,
                            Name = op.Product.Name,
                            Quantity = op.Quantity
                        })
                        .ToList()
                }),
                orderByParams.CurrentPage,
                orderByParams.PageSize
            );

            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == id);
            if (customer == null) return null;

            return customer.ToCustomerWithOrdersDto(pagedOrders);
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

        public async Task<bool> CustomerExist(int id)
        {
            return await _context.Customers.AnyAsync(c => c.Id == id);
        }
    }
}