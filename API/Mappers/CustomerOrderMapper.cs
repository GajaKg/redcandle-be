
using API.Dtos.Order;
using API.Models;

namespace API.Mappers
{
    public static class CustomerOrderMapper
    {
        public static CustomerOrderDto ToCustomerOrderDto(this CustomerOrder order)
            => new(
                order.Id,
                order.Date,
                order.Paid,
                order.Delivered,
                order.Note
            );
    }
}