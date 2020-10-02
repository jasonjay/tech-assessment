using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Orders.Domain;

namespace Data
{
    public class OrderContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(
                "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = OrdersData");
        }
    }
}
