using BusinessEntities;
using System;
using System.Collections.Generic;

namespace Core.Services.Orders
{
    public interface IGetOrderService
    {
        Order GetOrder(Guid id);
        IEnumerable<Order> GetOrders(Guid? productId = null, DateTime? orderDate = null, Guid? userId = null);
    }
}