using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager
{
    public class Goods
    {
        [Key]
        public int GoodsId { get; set; }          // 主键
        [Required]
        public string? Name { get; set; }          // 货物名称
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }        // 单价
        public int StockQuantity { get; set; }     // 库存数量（新增字段）

        public Goods() { }
        public Goods(string name, decimal price)
        {
            Name = name;
            Price = price;
            StockQuantity = 0; // 默认库存数量为0
        }
        public Goods(string name, decimal price, int stockQuantity)
        {
            Name = name;
            Price = price;
            StockQuantity = stockQuantity;
        }
        public override int GetHashCode()
            => HashCode.Combine(GoodsId, Name?.GetHashCode() ?? 0, Price);
        public override bool Equals(object? obj)
        {
            if (obj is Goods goods)
            {
                return GoodsId == goods.GoodsId &&
                       Name == goods.Name &&
                       Price == goods.Price &&
                       StockQuantity == goods.StockQuantity;
            }
            return false;
        }
        public override string ToString()
        {
            return $"GoodsId: {GoodsId}, Name: {Name}, Price: {Price}, StockQuantity: {StockQuantity}";
        }
    }
}
