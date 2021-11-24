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
        [Theory]
        [InlineData("Product1", 0.65)]
        [InlineData("Product2", 1.99)]
        [InlineData("Product3", 3)]
        public void OneProduct_Pricing(string product, decimal expected)
        {
            Assert.Equal(expected, productPricing.Pricing(product));
        }
    }
}