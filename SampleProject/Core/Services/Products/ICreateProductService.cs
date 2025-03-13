using BusinessEntities;
using System;

namespace Core.Services.Products
{
    public interface ICreateProductService
    {
        Product Create(Guid id, string name, string description, decimal? price);
    }
}