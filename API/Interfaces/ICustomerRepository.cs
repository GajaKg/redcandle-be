using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Dtos.Customer;
using API.Models;

namespace API.Interfaces
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAllAsync();
        Task<Customer?> GetByIdAsync(int id);
        Task<Customer> CreateAsync(Customer customer);
        Task<Customer?> UpdateAsync(int id, CustomerUpdateDto customerUpdateDto);
        Task<Customer> DeleteAsync(int id);
    }
}