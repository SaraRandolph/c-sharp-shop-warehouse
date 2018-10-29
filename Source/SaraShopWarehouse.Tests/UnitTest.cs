using Microsoft.VisualStudio.TestTools.UnitTesting;
using SaraShopWarehouse.Entities;
using SaraShopWarehouse.Data;
using NSubstitute;
using System;
using SaraShopWarehouse.Business;

namespace SaraShopWarehouse.Tests
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void Only_Process_Order_Once()
        {
            var order = new Order
            {
                Id = 1,
                ProcessedAt = DateTimeOffset.Now
            };

            var mockOrderRepo = Substitute.For<IOrderRepo>();

            mockOrderRepo.GetOrderById(order.Id).Returns(order);
            var orderService = new OrderService(mockOrderRepo);


            //act
            try
            {
                var expectedOrder = orderService.ProcessOrder(order);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Order already processed!", ex.Message);
                return;
            }
            //asserts
            Assert.Fail("Shouldn't have gotten here");

        }

        [TestMethod]
        public void Cant_Update_Order_Thats_Been_Processed()
        {
            var order = new Order
            {
                Id = 1,
                ProcessedAt = DateTimeOffset.Now
            };

            var mockOrderRepo = Substitute.For<IOrderRepo>();

            mockOrderRepo.GetOrderById(order.Id).Returns(order);
            var orderService = new OrderService(mockOrderRepo);


            //act
            try
            {
                var expectedOrder = orderService.UpdateOrder(order);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Can't edit an already processed order!", ex.Message);
                return;
            }
            //asserts
            Assert.Fail("Shouldn't have gotten here");

        }



        [TestMethod]
        public void Can_Process_Order()
        {
            //arrange
            var order = new Order
            {
                Id = 1
            };

            var mockOrderRepo = Substitute.For<IOrderRepo>();
            mockOrderRepo.GetOrderById(order.Id).Returns(new Order
            {
                Id = 1,
                ProcessedAt = null
            });

            var orderService = new OrderService(mockOrderRepo);

            //act
            var expectedOrder = orderService.ProcessOrder(order);

            //assert
            Assert.IsNull(order.ProcessedAt);
            mockOrderRepo.Received(1).GetOrderById(order.Id);
            mockOrderRepo.ReceivedWithAnyArgs(1).UpdateOrder(expectedOrder);
        }
    }
}
