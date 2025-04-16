using Microsoft.EntityFrameworkCore;
using OrderManagerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagerAPI.Models
{
    public class OrdersContext : DbContext
    {
        public DbSet<Order> Orders { get; set; } = null!; // 订单集合  
        public DbSet<OrderDetail> OrderDetails { get; set; } = null!; // 订单明细集合  
        public DbSet<Customer> Customers { get; set; } = null!; // 客户集合  
        public DbSet<Goods> Goods { get; set; } = null!; // 商品集合
        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseMySql("server=localhost;port=3307;database=OrderDB;user=root;password=password;",
                new MySqlServerVersion(new Version(8, 0, 41)));
        }*/

        public OrdersContext(DbContextOptions<OrdersContext> options) : base(options)
        {
            //Database.EnsureDeleted(); // 删除数据库
            Database.EnsureCreated(); // 创建数据库
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*
            // Order ↔ Customer 配置
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId)
                .OnDelete(DeleteBehavior.Restrict); // 禁止级联删除

            // Order ↔ OrderDetails 配置
            modelBuilder.Entity<OrderDetail>()
                .HasOne(d => d.Order)
                .WithMany(o => o.Details)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.Cascade); // 级联删除明细

            // OrderDetail ↔ Goods 配置
            modelBuilder.Entity<OrderDetail>()
                .HasOne(d => d.Goods)
                .WithMany()                         // 不需要反向导航
                .HasForeignKey(d => d.GoodsId)
                .OnDelete(DeleteBehavior.Restrict); // 禁止删除有订单的商品*/

            modelBuilder.Entity<Goods>().HasData(
            new Goods { GoodsId = 1, Name = "苹果",   Price = 1.99m, StockQuantity = 100 },
            new Goods { GoodsId = 2, Name = "香蕉",   Price = 0.75m, StockQuantity = 200 },
            new Goods { GoodsId = 3, Name = "梨",     Price = 0.50m, StockQuantity = 150 },
            new Goods { GoodsId = 4, Name = "樱桃",   Price = 1.20m, StockQuantity = 140 },
            new Goods { GoodsId = 5, Name = "西瓜",   Price = 5.55m, StockQuantity = 50 },
            new Goods { GoodsId = 6, Name = "橘子",   Price = 2.23m, StockQuantity = 250 }
            );

            modelBuilder.Entity<Customer>().HasData(
                new Customer { CustomerId = 1, Name = "张三"},
                new Customer { CustomerId = 2, Name = "李四"},
                new Customer { CustomerId = 3, Name = "王五"});

            modelBuilder.Entity<Order>().HasData(
            new Order
            {
                OrderId = 1,
                CreateTime = new DateTime(2024, 1, 1),
                CustomerId = 1,
            },
            new Order
            {
                OrderId = 2,
                CreateTime = new DateTime(2024, 2, 5),
                CustomerId = 2,
            }
            );


        }
    }
}
