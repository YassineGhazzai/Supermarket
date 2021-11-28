using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket
{
    public interface IProduct
    {
        string id { get; set; }
        decimal price { get; set; }
    }
}
