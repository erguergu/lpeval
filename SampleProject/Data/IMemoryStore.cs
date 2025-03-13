using BusinessEntities;
using System.Collections.Generic;

namespace Data
{
    public interface IMemoryStore
    {
        List<OrderProduct> OrderProducts { get; }
        List<Order> Orders { get; }
        List<Product> Products { get; }
    }
}