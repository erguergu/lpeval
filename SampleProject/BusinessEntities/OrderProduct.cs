using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessEntities
{
    public class OrderProduct
    {
        private Guid _orderId;
        private Guid _productId;


        public Guid OrderId
        {
            get => _orderId;
            private set => _orderId = value;
        }

        public Guid ProductId
        {
            get => _productId;
            private set => _productId = value;
        }


        public void SetOrderId(Guid orderId)
        {
            _orderId = orderId;
        }
        public void SetProductId(Guid productId)
        {
            _productId = productId;
        }
    }
}
