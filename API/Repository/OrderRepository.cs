
using API.Data;
using API.Interfaces;
using API.Models;

namespace API.Repository
{
    public class OrderRepository : IOrderRepository
    {

        private readonly ApplicationDBContext _context;
        // private readonly CustomerRepository _customerRepository;

        public OrderRepository(ApplicationDBContext context)
        // public CustomerOrderRepository(ApplicationDBContext context, CustomerRepository customerRepository)
        {
            _context = context;
            // _customerRepository = customerRepository;
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

        public Task<List<Order>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Order?> GetByIdAsync(int id)
        {
            var customerOrder = await _context.Orders.FindAsync(id);
            if (customerOrder == null)
            {
                return null;
            }

            return customerOrder;
        }

        public Task<Order?> UpdateAsync(int id, Order customerOrder)
        {
            throw new NotImplementedException();
        }
    }
}