using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        IEnumerable<Order> Get(Guid? productId = null, DateTime? orderDate = null, Guid? userId = null);
        void DeleteAll();
    }
}
