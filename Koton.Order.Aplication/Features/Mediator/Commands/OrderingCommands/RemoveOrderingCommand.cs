﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Koton.Order.Aplication.Features.Mediator.Commands.OrderingCommands
{
    public class RemoveOrderingCommand(int id) : IRequest
    {
        public int Id { get; set; } = id;
    }
}
