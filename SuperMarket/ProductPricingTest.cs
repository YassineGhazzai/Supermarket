﻿using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SuperMarket
{
    public class ProductPricingTest
    {
        private readonly ProductPricing productPricing;

        public ProductPricingTest()
        {
            productPricing = new ProductPricing();
        }
        [Fact]
        public void NoProduct_Pricing()
        {
            Assert.Equal(0, productPricing.Pricing(""));
        }
    }
}
