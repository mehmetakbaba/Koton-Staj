using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koton.Catalog.Entity.Entities.Abstract;

namespace Koton.Order.Domain.Entities
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
