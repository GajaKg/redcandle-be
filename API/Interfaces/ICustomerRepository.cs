using API.Dtos.Customer;
using API.Helpers;
using API.Models;

namespace API.Interfaces
{
    public interface ICustomerRepository
    {
        Task<PagedList<CustomerDto>> GetAllAsync(PaginationParams paginationParams);
        Task<CustomerDto?> GetByIdAsync(int id);
        Task<CustomerWithOrdersDto?> GetOrdersByCustomerIdAsync(int id);
        Task<Customer> CreateAsync(Customer customer);
        Task<Customer?> UpdateAsync(int id, CustomerUpdateDto customerUpdateDto);
        Task<Customer?> DeleteAsync(int id);
        Task<bool> CustomerExist(int id);
    }
}