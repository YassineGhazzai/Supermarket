using System;
using System.Collections.Generic;
using System.Linq;

namespace SuperMarket
{
    public class ProductPricing
    {
        private readonly IEnumerable<IProduct> catalog;
        private readonly IEnumerable<IDiscount> discounts;
        public ProductPricing(IEnumerable<IProduct> products,IEnumerable<IDiscount> discounts)
        {
            catalog =products;
            this.catalog = products;
            this.discounts = discounts;
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
            totalDiscount = discounts.Sum(discount => CalculateDiscount(discount, products));
            return total - totalDiscount;
        }
        private decimal PriceFor(string item)
        {
            return catalog.Single(p => p.id == item).price;
        }
        private decimal CalculateDiscount(IDiscount discount, string[] products)
        {
            int itemCount = products.Count(item => item == discount.id);
            return itemCount == discount.quantity || itemCount % discount.quantity == 0 ? (itemCount / discount.quantity) * discount.value : 0;        
        }
    }
}
