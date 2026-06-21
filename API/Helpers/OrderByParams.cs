using API.Interfaces;

namespace API.Helpers
{
    public class OrdersOrderByParams : PaginationParams
    {
        public OrderByDate OrderByDate { get; set; } = OrderByDate.Desc;
    }
}