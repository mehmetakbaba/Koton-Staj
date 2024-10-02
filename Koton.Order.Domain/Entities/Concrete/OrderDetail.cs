using Koton.Order.Domain.Entities.Abstract;

namespace Koton.Order.Domain.Entities.Concrete
{
    public class OrderDetail : IEntity<int>
    {
        public int Id { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; } = default!;
        public decimal ProductPrice { get; set; }
        public int ProductAmount { get; set; }
        public decimal ProductTotalPrice { get; set; }
        public string UserId { get; set; }
        public string Address { get; set; }
        
    }
}
