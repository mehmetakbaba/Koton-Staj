﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koton.Order.Aplication.Features.CQRS.Commands.AddressCommands
{
    public class RemoveAddressCommand(int id)
    {
        public int Id { get; set; } = id;
    }
}
