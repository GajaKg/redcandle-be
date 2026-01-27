using API.Dtos.Customer;
using API.Models;

namespace API.Interfaces
{
    public interface ICustomerRepository
    {
        Task<List<CustomerDto>> GetAllAsync();
        Task<CustomerDto?> GetByIdAsync(int id);
        Task<Customer> CreateAsync(Customer customer);
        Task<Customer?> UpdateAsync(int id, CustomerUpdateDto customerUpdateDto);
        Task<Customer?> DeleteAsync(int id);
    }
}