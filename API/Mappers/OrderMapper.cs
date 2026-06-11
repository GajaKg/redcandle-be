using System.Linq.Expressions;
using API.Dtos.Order;
using API.Models;

namespace API.Mappers
{
    public static class OrderMapper
    {
        public static OrderDto ToOrderDto(this Order order)
        {
            return new OrderDto
            {
                Id = order.Id,
                Date = order.Date,
                Paid = order.Paid,
                Delivered = order.Delivered,
                Note = order.Note,
                Products = order.OrderProducts
                    .Select(op => new OrderProductDto
                    {
                        Id = op.ProductId,
                        Name = op.Product.Name,
                        Quantity = op.Quantity
                    })
                    .ToList()
            };
        }
        
        public static Expression<Func<Order, OrderDto>> ToOrderDtoV2 =
        order => new OrderDto
        {
            Id = order.Id,
            Date = order.Date,
            Paid = order.Paid,
            Delivered = order.Delivered,
            Note = order.Note,
            Products = order.OrderProducts
                            .Select(op => new OrderProductDto
                            {
                                Id = op.ProductId,
                                Name = op.Product.Name,
                                Quantity = op.Quantity
                            })
                            .ToList()
        };

        public static Order ToCustomerOrderFromCreateCustomerDto(this OrderPostDto customerOrderPostDto, int customerId)
        {
            return new Order
            {
                CustomerId = customerId,
                Paid = customerOrderPostDto.Paid,
                Date = customerOrderPostDto.Date,
                Delivered = customerOrderPostDto.Delivered,
                Note = customerOrderPostDto.Note,

            };
        }
    }
}
