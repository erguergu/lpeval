using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> Get(Guid? orderId = null, string name = null, string description = null);
        void DeleteAll();
    }
}
