using System;
using System.Collections.Generic;
using System.Linq;

namespace SuperMarket
{
    public class ProductPricing
    {
        private readonly IEnumerable<IProduct> catalog;
        private readonly IEnumerable<IDiscount> discounts;
        public string[] scannedProducts { get; private set; }

        public ProductPricing(IEnumerable<IProduct> products,IEnumerable<IDiscount> discounts)
        {
            catalog =products;
            this.catalog = products;
            this.discounts = discounts;
            this.scannedProducts = new string[] { };
        }
        public ProductPricing Pricing(string product)
        {
            if (!String.IsNullOrEmpty(product))
            {
                this.scannedProducts = product.Split(",");                
            }
            return this;
          
            
        }
        public decimal Total()
        {
            decimal total = 0;
            decimal totalDiscount = 0;
            total = this.scannedProducts.Sum(x => PriceFor(x));
            totalDiscount = discounts.Sum(discount => CalculateDiscount(discount, this.scannedProducts));
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
