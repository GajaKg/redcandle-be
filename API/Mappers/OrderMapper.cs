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
                OrderProducts = order.OrderProducts
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
            OrderProducts = order.OrderProducts
                            .Select(op => new OrderProductDto
                            {
                                Id = op.ProductId,
                                Name = op.Product.Name,
                                Quantity = op.Quantity
                            })
                            .ToList()
        };

        // public static Order ToOrderFromPostOrderDto(this OrderPostDto orderPostDto, int customerId)
        public static Order ToOrderFromPostOrderDto(this OrderPostDto orderPostDto)
        {
            return new Order
            {
                CustomerId = orderPostDto.CustomerId,
                Paid = orderPostDto.Paid,
                Date = orderPostDto.Date,
                Delivered = orderPostDto.Delivered,
                Note = orderPostDto.Note,
                // OrderProducts = orderPostDto.Products.Select(p => p.FromProductPostDtoToProduct()).ToList()
                OrderProducts = orderPostDto.OrderProducts.Select(p => new OrderProduct
                {
                    Quantity = p.Quantity,
                    ProductId = p.ProductId,
                }).ToList()
            };
        }
    }
}
