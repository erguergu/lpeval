using BusinessEntities;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Data.Repositories
{
    [AutoRegister]
    public class OrderRepository : IOrderRepository
    {
        private IMemoryStore _memoryStore;

        public OrderRepository(IMemoryStore memoryStore)
        {
            _memoryStore = memoryStore;
        }

        public void Delete(Order order)
        {
            // I know that realistically you would usually not remove the product from the order in real life.
            _memoryStore.OrderProducts.RemoveAll(p => p.OrderId == order.Id);
            _memoryStore.Orders.Remove(_memoryStore.Orders.Single(p => p.Id == order.Id));
        }

        public void DeleteAll()
        {
            _memoryStore.OrderProducts.Clear();
            _memoryStore.Orders.Clear();
        }

        public Order Get(Guid id)
        {
            var order = _memoryStore.Orders.SingleOrDefault(p => p.Id == id);
            var productIds = _memoryStore.OrderProducts.Where(p => p.OrderId == id).Select(p => p.ProductId);
            
            order?.SetProductIds(productIds);

            return order;
        }

        public IEnumerable<Order> Get(Guid? productId = null, DateTime? orderDate = null, Guid? userId = null)
        {
            return _memoryStore.Orders
                .Where(p => !productId.HasValue ? true : _memoryStore.OrderProducts.Any(q => q.OrderId == p.Id && q.ProductId == productId))
                .Where(p => !orderDate.HasValue ? true : p.OrderDate == orderDate)
                .Where(p => !userId.HasValue ? true : p.UserId == userId);
        }

        public void Save(Order entity)
        {
            _memoryStore.OrderProducts.RemoveAll(p => p.OrderId == entity.Id);
            foreach (var productId in entity.ProductIds)
            {
                var orderProduct = new OrderProduct();
                orderProduct.SetOrderId(entity.Id);
                orderProduct.SetProductId(productId);
                _memoryStore.OrderProducts.Add(orderProduct); 
            }
            var existingOrder = _memoryStore.Orders.FirstOrDefault(p => p.Id == entity.Id);
            if (existingOrder != null)
            {
                _memoryStore.Orders.Remove(existingOrder);
            }
            _memoryStore.Orders.Add(entity);
        }
    }
}
