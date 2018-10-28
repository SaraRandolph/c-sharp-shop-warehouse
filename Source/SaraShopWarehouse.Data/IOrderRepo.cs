using SaraShopWarehouse.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SaraShopWarehouse.Data
{

    public interface IOrderRepo
    {
        IOrder GetOrderById(int id);
        IOrder UpdateOrder(IOrder o);
        List<IOrder> GetAllOrders();
        IOrder CreateOrder(Order order);
        List<IOrder> GetUnProcessedOrders();
    }

 }
