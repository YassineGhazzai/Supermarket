using System;
using System.Collections.Generic;
using System.Linq;

namespace SuperMarket
{
    public class ProductPricing
    {
        private Dictionary<string, decimal> catalog;
        private Dictionary<string, decimal[]> discounts;
        public ProductPricing()
        {
            catalog = new Dictionary<string, decimal>() {
                { "Product1", 0.65M },
                { "Product2", 1.99M },
                { "Product3", 3 }
            };
            /* Our offers 3 of product1 cost 1.5 instead of 1.95 = discount of 0.45 
                  2 of product3 cost 5 instead of 6 = discount of 1*/
            discounts = new Dictionary<string, decimal[]>() {
                { "Product1", new decimal[] { 3, 0.45M } },
                { "Product3", new decimal[] { 2, 1 } }
            };
        }
        public decimal Pricing(string product)
        {
            decimal total = 0;
            decimal totalDiscount = 0;
            if (String.IsNullOrEmpty(product))
            {
                return total;
            }
            /*split the input products into array of string to calculate the price 
            expecting the string product input to be separate the multiple products with a ","
            */
            var products = product.Split(",");
            //code optimisation through using Linq instead of a foreach
            total = products.Sum(x => PriceFor(x));
            totalDiscount = discounts.Sum(discount => CalculateDiscount(discount.Key, discount.Value, products));
            return total- totalDiscount;
        }
        private decimal PriceFor(string item)
        {
            decimal price = 0;
            catalog.TryGetValue(item, out price);
            return price;
        }
        private decimal CalculateDiscount(string product, decimal[] discount, string[] products)
        {
            int itemCount = products.Count(item => item == product);
            return itemCount == discount[0] || itemCount % discount[0]== 0 ? (itemCount / discount[0]) * discount[1] : 0;        
        }
    }
}
