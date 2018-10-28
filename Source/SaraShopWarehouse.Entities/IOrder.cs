using System;

namespace SaraShopWarehouse.Entities
{
    public interface IOrder
    {
        int Id { get; set; }
        int ProductId { get; set; }
        OrderEnum OrderType { get; set; }
        int ProductAmount { get; set; }
        string ProductName { get; set; }
        string ProductDescription { get; set; }
        DateTimeOffset CreatedAt { get; set; }
        DateTimeOffset? ProcessedAt { get; set; }
    }
}