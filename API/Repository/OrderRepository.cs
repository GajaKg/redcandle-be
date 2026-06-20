
using API.Data;
using API.Dtos.Order;
using API.Interfaces;
using API.Mappers;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repository
{
    public class OrderRepository : IOrderRepository
    {

        private readonly ApplicationDBContext _context;

        public OrderRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Order?> CreateAsync(Order customerOrder)
        {
            await _context.Orders.AddAsync(customerOrder);
            await _context.SaveChangesAsync();
            return customerOrder;
        }

        public Task<Order> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<OrderDto>> GetAllAsync()
        {
            var orders = await _context.Orders
                .AsNoTracking()
                .Include(o => o.OrderProducts)
                    .ThenInclude(op => op.Product)
                .Select(o => o.ToOrderDto())
                .ToListAsync();

            return orders;
        }

        public async Task<OrderDto?> GetByIdAsync(int id)
        {
            // var customerOrder = await _context.Orders.FindAsync(id);
            var customerOrder = await _context.Orders
                .Include(p => p.OrderProducts)
                    .ThenInclude(op => op.Product)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (customerOrder == null)
            {
                return null;
            }

            return customerOrder.ToOrderDto();
        }

        public async Task<List<OrderDto>> GetOrdersByClientIdAsync(int id)
        {
            var orders = await _context.Orders
                .AsNoTracking()
                .Where(o => o.CustomerId == id)
                .OrderBy(o => o.Date)
                .Include(o => o.OrderProducts)
                    .ThenInclude(op => op.Product)
                .Select(o => o.ToOrderDto())
                .ToListAsync();

            return orders;
        }

        public Task<Order?> UpdateAsync(int id, Order customerOrder)
        {
            throw new NotImplementedException();
        }
    }
}