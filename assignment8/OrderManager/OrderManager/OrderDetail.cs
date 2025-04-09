using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }    // 主键  
        public int Quantity { get; set; }         // 购买数量  

        // 商品关系  
        public int GoodsId { get; set; }          // 外键  
        private Goods? _goods;
        public Goods? Goods
        {
            get
            {
                if (_goods == null && GoodsId != 0)
                {
                    using var context = new OrdersContext();
                    _goods = context.Goods.Find(GoodsId);
                }
                return _goods;
            }
            set => _goods = value;
        }

        // 订单关系  
        public int OrderId { get; set; }          // 外键   
        private Order? _order;
        public Order? Order
        {
            get
            {
                if (_order == null && OrderId != 0)
                {
                    using var context = new OrdersContext();
                    _order = context.Orders.Find(OrderId);
                }
                return _order;
            }
        }

        public string? GoodsName => Goods?.Name;  // 商品名称
        public decimal GoodsPrice => Goods?.Price ?? 0; // 商品单价
        public decimal TotalPrice => (Goods?.Price ?? 0) * Quantity; // 小计  

        public override string ToString()
        {
            return Goods?.ToString() + $", Amount: {Quantity}\tSubtotal: {TotalPrice}";
        }
    }
}
