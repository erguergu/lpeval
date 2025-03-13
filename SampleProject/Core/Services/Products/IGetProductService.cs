using BusinessEntities;
using System;
using System.Collections.Generic;

namespace Core.Services.Products
{
    public interface IGetProductService
    {
        Product GetProduct(Guid id);
        IEnumerable<Product> GetProducts(Guid? orderId = null, string name = null, string description = null);
    }
}