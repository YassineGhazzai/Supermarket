using SuperMarket;
using System;
using Xunit;

namespace ProductPricingTests
{
    public class ProductPricingTest
    {
        private readonly ProductPricing productPricing;

        public ProductPricingTest()
        {
            productPricing = new ProductPricing();
        }

        [Fact]
        public void NoProduct_returnZero()
        {
            Assert.Equal(-1, productPricing.Pricing(""));
        }
    }
}
