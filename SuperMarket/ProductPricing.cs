using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket
{
     public class ProductPricing
    {
        public decimal Pricing(string product)
        {
            if (String.IsNullOrEmpty(product))
            {
                return 0;
            }
            return product switch
            {
                "Product1" => 0.65M,
                "Product2" => 1.99M,
                "Product3" => 3,
                _ => -1,
            };
        }

    }
}
