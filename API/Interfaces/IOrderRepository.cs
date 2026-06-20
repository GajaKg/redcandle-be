using API.Dtos.Order;
using API.Models;

namespace API.Interfaces
{
    public interface IOrderRepository
    {
        Task<List<OrderDto>> GetAllAsync();
        Task<OrderDto?> GetByIdAsync(int id);
        Task<List<OrderDto>> GetOrdersByClientIdAsync(int id);
        Task<Order?> CreateAsync(Order customerOrder);
        Task<Order?> UpdateAsync(int id, Order customerOrder);
        Task<Order> DeleteAsync(int id);
    }
}