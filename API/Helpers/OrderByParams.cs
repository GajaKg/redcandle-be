using API.Interfaces;

namespace API.Helpers
{
    public class OrderByParams : PaginationParams
    {
        public OrderByDate OrderByDate { get; set; } = OrderByDate.Desc;
    }
}