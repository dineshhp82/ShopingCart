using ShopingCart.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopingCart.Services
{
    public interface IShopingCartService
    {
        decimal? Total { get; set; }

        IEnumerable<CartItem> CartItems();
    }
}
