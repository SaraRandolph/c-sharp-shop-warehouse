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

        public List<IOrder> GetAllOrders()
        {
            return _orderRepo.GetAllOrders();
        }

        public IOrder GetOrderById(int id)
        {
            return _orderRepo.GetOrderById(id);
        }

        public IOrder ProcessOrder(IOrder order)
        {
            var currentOrder = GetOrderById(order.Id);
            if(currentOrder == null) { throw new Exception("Order not found"); }

            if (currentOrder.ProcessedAt != null)
            {
                throw new Exception("Order already processed ");
            }

            currentOrder.ProcessedAt = order.ProcessedAt ?? DateTimeOffset.Now;
            _orderRepo.UpdateOrder(currentOrder);

            return currentOrder;
        }

        public IOrder UpdateOrder(Order order)
        {
            return _orderRepo.UpdateOrder(order);
        }

        public IOrder CreateOrder(Order order)
        {
            return _orderRepo.CreateOrder(order);
        }
    }
}
