using SaraShopWarehouse.Data;
using SaraShopWarehouse.Entities;
using System;
using System.Collections.Generic;

namespace SaraShopWarehouse.Business
{
    public class OrderService
    {
        private readonly IOrderRepo _orderRepo;

        public OrderService(IOrderRepo orderRepo)
        {
            _orderRepo = orderRepo;
        }

        public List<Order> GetAllOrders()
        {
            return _orderRepo.GetAllOrders();
        }

        public Order GetOrderById(int orderId)
        {
            return _orderRepo.GetOrderById(orderId);
        }

        public Order ProcessOrder(Order order)
        {
            var currentOrder = GetOrderById(order.OrderId);
            if(currentOrder == null) { throw new Exception("Order not found"); }

            if (currentOrder.ProcessedAt != null)
            {
                throw new Exception("Order already processed ");
            }

            currentOrder.ProcessedAt = order.ProcessedAt ?? DateTimeOffset.Now;
            _orderRepo.UpdateOrder(currentOrder);

            return currentOrder;
        }
    }
}
