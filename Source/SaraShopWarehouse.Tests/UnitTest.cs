using Microsoft.VisualStudio.TestTools.UnitTesting;
using SaraShopWarehouse.Entities;
using SaraShopWarehouse.Data;
using NSubstitute;
using System;

namespace SaraShopWarehouse.Tests
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void Only_Process_Order_Once()
        {
            //var order = new IOrder;
            //{
            //    OrderId = 1,
            //    ProcessedAt = DateTimeOffset.Now()
            //};

            //var mockOrderRepo = Substitute.For<IOrderRepo>();

            //mockOrderRepo.GetOrderById(order.OrderId).Returns(order);
            //var OrderService = new OrderService(mockOrderRepo);



            Assert.IsTrue(true);
        }

        public void Cant_Process_Order_Already_Processes()
        {
            Assert.IsTrue(true);
        }
    }
}
