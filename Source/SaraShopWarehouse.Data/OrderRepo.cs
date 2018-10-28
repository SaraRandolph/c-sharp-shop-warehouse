using SaraShopWarehouse.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SaraShopWarehouse.Data
{

    public class OrderRepo : IOrderRepo
    {
        private readonly IDbConnection _db;

        public OrderRepo(IDbConnection db)
        {
            _db = db;
        }

        public IOrder GetOrderById(int id)
        {
            return SeedData.Orders.Find(b => b.Id == id);
        }

        public IOrder UpdateOrder(IOrder orderToUpdate)
        {
            var order = GetOrderById(orderToUpdate.Id);
            if (order == null) { throw new Exception("Order not found, Id not located"); }

            order.ProductName = orderToUpdate.ProductName;
            order.ProductDescription = orderToUpdate.ProductDescription;
            order.ProductAmount = orderToUpdate.ProductAmount;

            return order;
        }

        public IOrder CreateOrder(Order newOrder)
        {
            //TODO figure how to handle next index
            int newIndex = SeedData.Orders.Max(x => x.Id);
            newOrder.Id = newIndex + 1;
            SeedData.Orders.Add(newOrder);
            return newOrder;
        }

        public List<IOrder> GetAllOrders()
        {
            return SeedData.Orders;
        }

        public List<IOrder> GetUnProcessedOrders()
        {
            List<IOrder> unProcessedOrders = new List<IOrder>();

            foreach (var order in SeedData.Orders)
            {
                if(order.ProcessedAt == null)
                {
                    unProcessedOrders.Add(order);
                }
            }
            return unProcessedOrders;
        }

    }

}
