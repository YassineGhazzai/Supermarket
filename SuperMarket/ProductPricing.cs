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
                { "Product3", 3 },
                { "Product4", 10 }

            };
        }
        public decimal Pricing(string product)
        {
            decimal total = 0;
            if (String.IsNullOrEmpty(product))
            {
                return total;
            }
            /*split the input products into array of string to calculate the price 
            expecting the string product input to be separate the multiple products with a ","
            */
            var items = product.Split(",");
            foreach ( string item in items)
            {
                total = total + PriceFor(item);
            }
            return total;
        }
        private decimal PriceFor(string item)
        {
            decimal price = 0;
            catalog.TryGetValue(item, out price);
            return price;
        }

    }
}
