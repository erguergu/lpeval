using BusinessEntities;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repositories
{
    [AutoRegister]
    public class ProductRepository : IProductRepository
    {
        private IMemoryStore _memoryStore;

        public ProductRepository(IMemoryStore memoryStore)
        {
            _memoryStore = memoryStore;
        }

        public void Delete(Product entity)
        {
            // I know that realistically you would usually not remove the product from the order in real life.
            _memoryStore.OrderProducts.RemoveAll(p => p.ProductId == entity.Id);
            _memoryStore.Products.Remove(_memoryStore.Products.Single(p => p.Id == entity.Id));
        }

        public void DeleteAll()
        {
            _memoryStore.OrderProducts.Clear();
            _memoryStore.Products.Clear();
        }

        public Product Get(Guid id)
        {
            var product = _memoryStore
                .Products
                .SingleOrDefault(p => p.Id == id);
            var orderProducts = _memoryStore
                .OrderProducts
                .Where(p => p.ProductId == id);
            var orders = _memoryStore
                .Orders
                .Where(p => orderProducts.Any(q => q.OrderId == p.Id));

            return product;
        }

        public IEnumerable<Product> Get(Guid? orderId = null, string name = null, string description = null)
        {
            return _memoryStore.Products
                .Where(p => !orderId.HasValue ? true : _memoryStore.OrderProducts.Any(q => q.ProductId == p.Id && q.OrderId == orderId))
                .Where(p => string.IsNullOrEmpty(name) ? true : p.Name.ToLowerInvariant().Contains(name.ToLowerInvariant()))
                .Where(p => string.IsNullOrEmpty(description) ? true : p.Description.ToLowerInvariant().Contains(description.ToLowerInvariant()));
        }

        public void Save(Product entity)
        {
            _memoryStore.Products.Add(entity);
        }
    }
}
