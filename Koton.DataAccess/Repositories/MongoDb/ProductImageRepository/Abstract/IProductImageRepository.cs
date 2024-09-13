using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koton.DataAccess.Repositories.MongoDb.GenericRepository.Abstract;
using Koton.Entity.Entities.Concrete;

namespace Koton.DataAccess.Repositories.MongoDb.ProductImageRepository.Abstract
{
    public interface IProductImageRepository : IGenericRepository<ProductImage>
    {
    }
}
