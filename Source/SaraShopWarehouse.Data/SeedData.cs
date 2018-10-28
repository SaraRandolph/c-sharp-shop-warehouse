using SaraShopWarehouse.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaraShopWarehouse.Data
{
    public static class SeedData
    {
        public static List<IOrder> Orders = new List<IOrder>()
        {
            new Order()
            {
                Id = 1,
                ProductId =  101,
                ProductAmount = 2,
                OrderType = OrderEnum.Invoice,
                ProductName = "Bat Wings",
                ProductDescription = "Crunchy, black, scary bat wings",
                CreatedAt = DateTimeOffset.Now,
                ProcessedAt = null
            },

            new Order()
            {
                Id = 2,
                ProductId =  102,
                ProductAmount = 2,
                OrderType = OrderEnum.Receipt,
                ProductName = "Pumpkin Goo",
                ProductDescription = "Slimy, cold seedy pumpkin goo",
                CreatedAt = DateTimeOffset.Now,
                ProcessedAt = null
            },

            new Order()
            {
                Id = 3,
                ProductId =  103,
                ProductAmount = 3,
                OrderType = OrderEnum.Receipt,
                ProductName = "Severed Hand",
                ProductDescription = "Smelly, decrepit severed hand",
                CreatedAt = DateTimeOffset.Now,
                ProcessedAt = null
            }

        };
        


    }
}
