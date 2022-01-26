using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Domain.Entities;

namespace TestApp.DataAccess
{
    public class Context : DbContext
    {

        public Context(DbContextOptions options) : base(options)
        {
            //Database.EnsureCreated();
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ///modelBuilder.Entity<Product>().HasData(new Product[] { new Product { Id = 1, Name = "A" }, new Product { Id = 2, Name = "B" } });
            modelBuilder.Entity<Product>().Property(x => x.Name).HasMaxLength(255).IsRequired();

            modelBuilder.Entity<OrderStatus>().HasData(new object[]{ new OrderStatus { Id = 1, Name = "Active" }, new OrderStatus { Id = 2, Name = "InActive" } });
            modelBuilder.Entity<Order>().HasData(new object[] { new Order { Id = 1, OrderDate = DateTime.Now, StatusId = 1 } });
            modelBuilder.Entity<OrderDetail>().HasData(new object[] { new OrderDetail { Id = 1, OrderId = 1, IsDeleted = false, ProductId = 1}, new OrderDetail { Id = 2, OrderId = 1, IsDeleted = false, ProductId = 2 } });


        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

    }
}
