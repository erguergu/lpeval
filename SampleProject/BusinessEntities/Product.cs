using Common.Extensions;
using System;
using System.Collections.Generic;

namespace BusinessEntities
{
    public class Product : IdObject
    {
        private string _name;
        private string _description;
        private decimal _price;

        public string Name
        {
            get => _name;
            private set => _name = value;
        }

        public string Description
        {
            get => _description;
            private set => _description = value;
        }

        public decimal Price
        {
            get => _price;
            private set => _price = value;
        }

        public void SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Name was not provided.");
            }
            _name = name;
        }

        public void SetDescription(string description)
        {
            if (string.IsNullOrEmpty(description))
            {
                throw new ArgumentNullException("Description was not provided.");
            }
            _description = description;
        }

        public void SetPrice(decimal? price)
        {
            if (!price.HasValue)
            {
                throw new ArgumentNullException("Price was not provided.");
            }
            _price = price.Value;
        }
    }
}
