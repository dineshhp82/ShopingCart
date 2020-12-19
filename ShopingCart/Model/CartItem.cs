using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopingCart.Model
{
    public class CartItem
    {
        public string ProductId { get; set; }
        public int Quantity { get; set; }
        public virtual decimal Price { get; set; }
    }
}
