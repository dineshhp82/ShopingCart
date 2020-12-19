using ShopingCart.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopingCart.Services
{
    public interface IShipmentService
    {
        void Ship(AddressInfo info, IEnumerable<CartItem> items);
    }
}
