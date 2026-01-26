using API.Dtos.Customer;
using API.Models;

namespace API.Mappers
{
    public static class CustomerMapper
    {
        public static CustomerDto ToCustomerDto(this Customer customerModel)
        {
            return new CustomerDto
            {
                Id = customerModel.Id,
                Name = customerModel.Name,
                Address = customerModel.Address,
                Contact = customerModel.Contact,
                Note = customerModel.Note,
                Orders = customerModel.CustomerOrders
                    .Select(o => o.ToCustomerOrderDto())
                    .ToList()
            };
        }

        public static Customer ToCustomerFromPostDto(this CustomerPostDto customerPostDto)
        {
            return new Customer
            {
                Name = customerPostDto.Name,
                Address = customerPostDto.Address,
                Contact = customerPostDto.Contact,
                Note = customerPostDto.Note,
            };
        }

        public static Customer ToCustomerFromUpdateDto(this CustomerUpdateDto customerUpdateDto)
        {
            return new Customer
            {
                Name = customerUpdateDto.Name,
                Address = customerUpdateDto.Address,
                Contact = customerUpdateDto.Contact,
                Note = customerUpdateDto.Note,
            };
        }
    }
}