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
    public class GetOrderService : IGetOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Order GetOrder(Guid id)
        {
            return _orderRepository.Get(id: id);
        }

        public IEnumerable<Order> GetOrders(Guid? productId = null, DateTime? orderDate = null, Guid? userId = null)
        {
            return _orderRepository.Get(productId, orderDate, userId);
        }
    }
}
