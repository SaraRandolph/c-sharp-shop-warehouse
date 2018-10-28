using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SaraShopWarehouse.Entities;


namespace SaraShopWarehouse.RazorWeb.Models
{
    public class SaraShopWarehouseWebContext : DbContext
    {
        public SaraShopWarehouseWebContext(DbContextOptions<SaraShopWarehouseWebContext> options)
            : base(options)
        {
        }

        public DbSet<SaraShopWarehouse.Entities.Order> Order { get; set; }

    }
}
