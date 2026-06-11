using API.Dtos.Customer;
using API.Models;

namespace API.Mappers
{
    public static class CustomerMapper
    {
        // Use Expression Mappers (Advanced)
        // Because EF Core can inspect the expression tree and translate it to SQL.
        // For a production .NET application,
        // this is usually the cleanest approach if you want reusable mappings without repeating projections everywhere.
        // public static Expression<Func<Customer, CustomerDto>> ToCustomerDtoV2 =
        //     customerModel => new CustomerDto
        //     {
        //         Id = customerModel.Id,
        //         Name = customerModel.Name,
        //         Address = customerModel.Address,
        //         Contact = customerModel.Contact,
        //         Note = customerModel.Note,
        //         Orders = customerModel.Orders.AsQueryable()
        //                     .Select(o => OrderMapper.ToOrderDtoV2.Invoke(o))
        //                     .ToList()
        //     };

        public static CustomerDto ToCustomerDto(this Customer customerModel)
        {
            return new CustomerDto
            {
                Id = customerModel.Id,
                Name = customerModel.Name,
                Address = customerModel.Address,
                Contact = customerModel.Contact,
                Note = customerModel.Note,
                Orders = customerModel.Orders
                    .Select(o => o.ToOrderDto())
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