

using Koton.Order.Domain.Entities.Abstract;

namespace Koton.Order.Domain.Entities.Concrete
{
    public class Address : IEntity<int>
    {
        public int Id { get; set; }
        public string UserId { get; set; } = default!;
        public string City { get; set; } = default!;
        public string District { get; set; } = default!;
        public string Detail { get; set; } = default!;

    }
}
