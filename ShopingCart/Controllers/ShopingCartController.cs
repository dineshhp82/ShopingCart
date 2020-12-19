using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopingCart.Model;
using ShopingCart.Services;

namespace ShopingCart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopingCartController : ControllerBase
    {
        readonly IShopingCartService shopingCartService;
        readonly IShipmentService shipmentService;
        readonly IPaymentService paymentService;

        public ShopingCartController(
            IShopingCartService cart,
            IShipmentService shipment,
            IPaymentService payment)
        {

            shopingCartService = cart;
            shipmentService = shipment;
            paymentService = payment;
        }


        [HttpPost]
        public string CheckOut(Card card, AddressInfo addressInfo)
        {
            var result = paymentService.Payment(shopingCartService.Total, card);
            if (result)
            {
                shipmentService.Ship(addressInfo, shopingCartService.CartItems());
                return "Charged";
            }

            return "Not Charged";
        }
    }
}