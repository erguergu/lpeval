using BusinessEntities;
using Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    [AutoRegister(AutoRegisterTypes.Singleton)]
    public class MemoryStore : IMemoryStore
    {
        public List<Product> Products { get; } = new List<Product>();
        public List<Order> Orders { get; } = new List<Order>();
        public List<OrderProduct> OrderProducts { get; } = new List<OrderProduct>();
    }
}
