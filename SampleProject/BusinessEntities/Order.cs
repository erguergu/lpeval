using Common.Extensions;
using System;
using System.Collections.Generic;

namespace BusinessEntities
{
    public class Order : IdObject
    {
        private Guid _userId;
        private DateTime _orderDate;
        private decimal _totalPrice;
        private readonly List<Guid> _productIds = new List<Guid>();

        public Guid UserId
        {
            get => _userId;
            private set => _userId = value;
        }

        public DateTime OrderDate
        {
            get => _orderDate;
            private set => _orderDate = value;
        }

        public decimal TotalPrice
        {
            get => _totalPrice;
            private set => _totalPrice = value;
        }

        public List<Guid> ProductIds
        {
            get => _productIds;
            private set => _productIds.Initialize(value);
        }

        public void SetUserId(Guid userId)
        {
            _userId = userId;
        }

        public void SetDate(DateTime orderDate)
        {
            _orderDate = orderDate;
        }

        public void SetTotalPrice(decimal totalPrice)
        {
            _totalPrice = totalPrice;
        }

        public void SetProductIds(IEnumerable<Guid> productIds)
        {
            _productIds.Initialize(productIds);
        }
    }
}
