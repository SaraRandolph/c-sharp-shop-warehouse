using SaraShopWarehouse.Entities;
using System;
using System.Collections.Generic;
using System.Data;

namespace SaraShopWarehouse.Data
{

    public interface IOrderRepo
    {
        Order GetOrderById(int id);
        void UpdateOrder(Order o);
        List<Order> GetAllOrders();
        Order CreateOrder(Order data);
        IEnumerable<Order> GetUnProcessedOrders();
    }

    public class OrderRepo : IOrderRepo
    {
        private readonly IDbConnection _db;

        public OrderRepo(IDbConnection db)
        {
            _db = db;
        }

        public Order GetOrderById(int orderId)
        {
            return new Order
            {
                OrderId = orderId,
                ProductId = 1,
                ProductAmount = 5,
                OrderType = OrderEnum.Receipt,
                ProductName = "Bat Wings",
                ProductDescription = "Scary, black, crunchy bat wings. Perfect for soups or potions.",
                CreatedAt = DateTimeOffset.Now.AddDays(-1),
            };
        }

        public void UpdateOrder(Order orderToUpdate)
        {
            Console.WriteLine("dis dat shit you wanted");
        }

        public Order CreateOrder(Order data)
        {
            return new Order
            {
                OrderId = data.OrderId,
                ProductId = data.ProductId,
                ProductAmount = data.ProductAmount,
                ProductDescription = data.ProductDescription,
                ProductName = data.ProductName,
                OrderType = data.OrderType,
                CreatedAt = DateTimeOffset.Now,
                ProcessedAt = null
            };
        }

        public List<Order> GetAllOrders()
        {
            return new List<Order>
            {
                GetOrderById(1),
                GetOrderById(2),
                GetOrderById(3),
            };
        }

        public IEnumerable<Order> GetUnProcessedOrders()
        {
            return new List<Order>
            {
                GetOrderById(1),
                GetOrderById(2),
                GetOrderById(3),
            };
        }



    }

}
