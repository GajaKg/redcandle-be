using API.Dtos.Order;
using API.Models;

namespace API.Interfaces
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllAsync();
        Task<Order?> GetByIdAsync(int id);
        Task<Order?> CreateAsync(Order customerOrder);
        Task<Order?> UpdateAsync(int id, Order customerOrder);
        Task<Order> DeleteAsync(int id);
    }
}