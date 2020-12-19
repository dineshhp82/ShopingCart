using Moq;
using ShopingCart.Controllers;
using ShopingCart.Model;
using ShopingCart.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace ShopingCart.Tests
{
    public class ShopingCartControllerTest : IClassFixture<ShopingCartControllerFixture>
    {
        ShopingCartController shopingCartController;

        ShopingCartControllerFixture fixture;

        public ShopingCartControllerTest()
        {
            fixture = new ShopingCartControllerFixture();

            shopingCartController = new ShopingCartController(
                fixture.shopingCartServiceMock.Object,
                fixture.shipmentServiceMock.Object,
                fixture.paymentServiceMock.Object);

        }

        [Fact]
        public void Should_Return_Payment()
        {
            //arrange
            fixture.paymentServiceMock.Setup(p => p.Payment(It.IsAny<decimal?>(), It.IsAny<Card>())).Returns(true);

            //act
            var result = shopingCartController.CheckOut(fixture.card.Object, fixture.address.Object);

            fixture.shipmentServiceMock.Verify(s => s.Ship(fixture.address.Object, fixture.items.AsEnumerable()), Times.Once);

            Assert.Equal("Charged", result);
        }

        [Fact]
        public void Should_Return_No_Payment()
        {
            fixture.paymentServiceMock.Setup(p => p.Payment(It.IsAny<decimal?>(), It.IsAny<Card>())).Returns(false);

            var result = shopingCartController.CheckOut(fixture.card.Object, fixture.address.Object);

            fixture.shipmentServiceMock.Verify(s => s.Ship(fixture.address.Object, fixture.items.AsEnumerable()), Times.Never);

            Assert.Equal("Not Charged", result);
        }
    }
}
