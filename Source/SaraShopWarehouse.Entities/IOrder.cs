using System;

namespace SaraShopWarehouse.Entities
{
    public interface IOrder
    {
        DateTimeOffset CreatedAt { get; set; }
        int OrderId { get; set; }
        OrderEnum OrderType { get; set; }
        DateTimeOffset? ProcessedAt { get; set; }
        int ProductAmount { get; set; }
        string ProductDescription { get; set; }
        int ProductId { get; set; }
        string ProductName { get; set; }
    }
}