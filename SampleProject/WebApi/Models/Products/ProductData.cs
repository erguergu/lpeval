using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Models.Products
{
    public class ProductData : IdObjectData
    {
        public ProductData(Product product) : base(product)
        {
            Name = product.Name;
            Price = product.Price;
            Description = product.Description;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
    }
}
