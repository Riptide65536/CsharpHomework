using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagerAPI.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }    // 主键  
        public int Quantity { get; set; }         // 购买数量  

        // 商品关系  
        public int GoodsId { get; set; }          // 外键  
        public Goods? Goods { get; set; }          // 商品对象

        // 订单关系  
        public int OrderId { get; set; }          // 外键   
        public Order? Order { get; set; }          // 订单对象

        public string? GoodsName => Goods?.Name;  // 商品名称
        public decimal GoodsPrice => Goods?.Price ?? 0; // 商品单价
        public decimal TotalPrice => (Goods?.Price ?? 0) * Quantity; // 小计  

        public override string ToString()
        {
            return Goods?.ToString() + $", Amount: {Quantity}\tSubtotal: {TotalPrice}";
        }
    }
}
