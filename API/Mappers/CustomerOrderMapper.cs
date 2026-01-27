using API.Dtos.Order;
using API.Models;

namespace API.Mappers
{
    public static class CustomerOrderMapper
    {
        public static CustomerOrderDto ToCustomerOrderDto(this CustomerOrder order)
        {
            return new CustomerOrderDto
            {
                Id = order.Id,
                Date = order.Date,
                Paid = order.Paid,
                Delivered = order.Delivered,
                Note = order.Note,
                Products = order.OrderProducts
                    .Select(op => new OrderProductDto
                    {
                        ProductId = op.ProductId,
                        ProductName = op.Product.Name,
                        Quantity = op.Quantity
                    })
                    .ToList()
            };
        }
    }
}
