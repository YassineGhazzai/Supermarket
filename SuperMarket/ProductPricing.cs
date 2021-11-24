using System;
using System.Collections.Generic;

namespace SuperMarket
{
    public class ProductPricing
    {
        private Dictionary<string, decimal> catalog;

        public ProductPricing()
        {
            catalog = new Dictionary<string, decimal>() {
                { "Product1", 0.65M },
                { "Product2", 1.99M },
                { "Product3", 3 }
            };
        }
        public decimal Pricing(string product)
        {
            decimal price = -1;
            if (String.IsNullOrEmpty(product))
            {
                return 0;
            }
            catalog.TryGetValue(product, out price);
            return price;
        }

    }
}
