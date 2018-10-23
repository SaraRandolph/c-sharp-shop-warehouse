using System;

namespace SaraShopWarehouse.Entities
{
    public class Order : IOrder
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int ProductAmount { get; set; }
        public OrderEnum OrderType { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? ProcessedAt { get; set; }
    }

}
