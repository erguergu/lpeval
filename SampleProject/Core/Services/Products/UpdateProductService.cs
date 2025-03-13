using BusinessEntities;
using Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Products
{
    [AutoRegister(AutoRegisterTypes.Singleton)]
    public class UpdateProductService : IUpdateProductService
    {
        public void Update(Product product, string name, string description, decimal? price)
        {
            product.SetName(name);
            product.SetDescription(description);
            product.SetPrice(price);
        }
    }
}
