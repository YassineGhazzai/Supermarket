using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket
{
    public interface IDiscount  
    {
        string id { get; set; }
        int quantity { get; set; }
        decimal value { get; set; }
    }
}
