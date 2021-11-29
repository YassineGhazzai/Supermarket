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
            IEnumerable<Product> products = new[]
               {
                new Product{id = "Product1", price =  0.65M},
                new Product{id = "Product2", price = 1.99M },
                new Product{id = "Product3", price = 3}
                };
            /* Our offers 3 of product1 cost 1.5 instead of 1.95 = discount of 0.45 
                  2 of product3 cost 5 instead of 6 = discount of 1*/
            IEnumerable<Discount> discounts = new[]
            {
                    new Discount{id ="Product1", quantity = 3, value = 0.45M},
                    new Discount{id = "Product3", quantity = 2, value = 1}
            };

        productPricing = new ProductPricing(products, discounts);
        }
        [Fact]
        public void NoProduct_Pricing()
        {
            Assert.Equal(0, productPricing.Pricing("").Total());
        }
        [Theory]
        [InlineData("Product1,Product3,Product2", 5.64)]
        [InlineData("Product2,Product1", 2.64)]
        [InlineData("Product3", 3)]
        [InlineData("Product2", 1.99)]
        public void MultipleProduct_Pricing_NoDicount(string product, decimal expected)
        {
            Assert.Equal(expected, productPricing.Pricing(product).Total());
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
            Assert.Equal(expected, productPricing.Pricing(scan).Total());
        }
    }
}
