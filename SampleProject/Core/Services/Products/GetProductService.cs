using BusinessEntities;
using Common;
using Core.Services.Products;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Products
{
    [AutoRegister]
    public class GetProductService : IGetProductService
    {
        private readonly IProductRepository _productRepository;

        public GetProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product GetProduct(Guid id)
        {
            return _productRepository.Get(id: id);
        }

        public IEnumerable<Product> GetProducts(Guid? orderId = null, string name = null, string description = null)
        {
            return _productRepository.Get(orderId, name, description);
        }
    }
}
