using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket
{
    public interface IProductPricing
    {
        IProductPricing Pricing(string Products);
        decimal Total();
    } 
}
