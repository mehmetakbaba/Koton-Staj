using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koton.Discount.Entity.Entities.Abstract
{
    public interface IEntity<TKey>
    { 
        TKey Id { get; }
    }
}
