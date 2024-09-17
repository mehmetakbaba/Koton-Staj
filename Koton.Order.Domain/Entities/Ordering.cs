


namespace Koton.Order.Domain.Entities
{
    public class Ordering : IEntity<int>
    {
        public int Id { get; set; }
        public string UserId { get; set; } = default!;
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
