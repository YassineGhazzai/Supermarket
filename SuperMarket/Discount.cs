using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket
{
    public class Discount : IDiscount
    {
        public string id { get; set; }
        public int quantity { get; set; }
        public decimal value { get; set; }
    }
}
