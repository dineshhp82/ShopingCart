using Moq;
using ShopingCart.Controllers;
using ShopingCart.Model;
using ShopingCart.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShopingCart.Tests
{
    public class ShopingCartControllerFixture : IDisposable
    {
        public Mock<IPaymentService> paymentServiceMock;

        public Mock<IShipmentService> shipmentServiceMock;

        public Mock<IShopingCartService> shopingCartServiceMock;

        public Mock<Card> card;

        public Mock<AddressInfo> address;

        public Mock<CartItem> cartItem;

        public List<CartItem> items;

        public ShopingCartControllerFixture()
        {
            paymentServiceMock = new Mock<IPaymentService>();

            shipmentServiceMock = new Mock<IShipmentService>();

            shopingCartServiceMock = new Mock<IShopingCartService>();

            card = new Mock<Card>();
            address = new Mock<AddressInfo>();
            cartItem = new Mock<CartItem>();

            cartItem.Setup(p => p.Price).Returns(10.0m);

            items = new List<CartItem>() { cartItem.Object };

            shopingCartServiceMock.Setup(p => p.CartItems()).Returns(items.AsEnumerable);


        }


        public void Dispose()
        {
            paymentServiceMock = null;

            shipmentServiceMock = null;

            shopingCartServiceMock = null;

            card = null;

            cartItem = null;

            address = null;
        }
    }
}
