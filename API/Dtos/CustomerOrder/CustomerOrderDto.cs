namespace API.Dtos.Order
{
    public sealed record CustomerOrderDto(
        int Id,
        DateTime Date,
        bool Paid,
        bool Delivered,
        string? Note
    );
}