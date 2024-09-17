using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koton.Order.Aplication.Features.CQRS.Results.AddressResults
{
    public class GetAddressQueryResult
    {
        public int Id { get; set; }
        public string UserId { get; set; } = default!;
        public string City { get; set; } = default!;
        public string District { get; set; } = default!;
        public string Detail { get; set; } = default!;
    }
}
