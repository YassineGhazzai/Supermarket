using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket
{
	public class Product : IProduct
	{
		public string id { get; set; }
		public decimal price { get; set; }
	}
}
