using System;
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
        [InlineData("Product1,Product3,Product2", 5.64)]
        [InlineData("Product2,Product1", 2.64)]
        [InlineData("Product3", 3)]
        [InlineData("Product2", 1.99)]
        public void MultipleProduct_Pricing_NoDicount(string product, decimal expected)
        {
            Assert.Equal(expected, productPricing.Pricing(product));
        }
        [Theory]
        [InlineData("Product1,Product1,Product1", 1.5)]
        [InlineData("Product1,Product1,Product1,Product2", 3.49)]
        [InlineData("Product1,Product1,Product1,Product2,Product2", 5.48)]
        [InlineData("Product1,Product1,Product1,Product1,Product1,Product1", 3)]
        [InlineData("Product1,Product1,Product1,Product3,Product3", 6.5)]
        [InlineData("Product3,Product3", 5)]
        public void Pricing_discounted_combinations_Products(string scan, decimal expected)
        {
            Assert.Equal(expected, productPricing.Pricing(scan));
        }
    }
}
