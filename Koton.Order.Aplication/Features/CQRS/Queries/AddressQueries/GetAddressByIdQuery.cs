﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koton.Order.Aplication.Features.CQRS.Queries.AddressQueries
{
    public class GetAddressByIdQuery(int id)
    {
      
        public int Id { get; set; } = id;
    }
}
