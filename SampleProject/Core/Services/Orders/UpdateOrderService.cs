using BusinessEntities;
using Common;
using Core.Services.Orders;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Orders
{
    [AutoRegister]
    public class UpdateOrderService : IUpdateOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public UpdateOrderService(IOrderRepository orderRepository
            , IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        public void Update(Order order, Guid userId, DateTime orderDate, IEnumerable<Guid> productIds)
        {
            order.SetUserId(userId);
            order.SetDate(orderDate);
            order.SetProductIds(productIds);
            decimal total = 0;
            foreach (var productId in productIds)
            {
                var product = _productRepository.Get(id: productId);
                if (product == null)
                {
                    throw new Exception($"Unable to update order {order.Id}. Product {productId} not found.");
                }
                total += product.Price;
            }
            order.SetTotalPrice(total);
            _orderRepository.Save(order);
        }
    }
}
