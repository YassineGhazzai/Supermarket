using System;
using System.Collections.Generic;
using System.Linq;

namespace SuperMarket
{
    public class ProductPricing : IProductPricing
    {
        private readonly IEnumerable<IProduct> catalog;
        private readonly IEnumerable<IDiscount> discounts;
        private string[] scannedProducts;

        public ProductPricing(IEnumerable<IProduct> products,IEnumerable<IDiscount> discounts)
        {
            catalog =products;
            this.catalog = products;
            this.discounts = discounts;
            scannedProducts = new string[] { };
        }
        public IProductPricing Pricing(string product)
        {
            if (!String.IsNullOrEmpty(product))
            {
                scannedProducts = product.Split(",");                
            }
            return this;       
        }
        public decimal Total()
        {
            decimal total = 0;
            decimal totalDiscount = 0;
            total = scannedProducts.Sum(x => PriceFor(x));
            totalDiscount = discounts.Sum(discount => CalculateDiscount(discount, scannedProducts));
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
