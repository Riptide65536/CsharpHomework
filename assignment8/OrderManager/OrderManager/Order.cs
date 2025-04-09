using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager
{
    public class Order
    {
        public int OrderId { get; set; }          // 主键  
        public DateTime CreateTime { get; set; } // 创建时间  

        // 关系配置  
        public int CustomerId { get; set; }        // 外键  

        // 修复导航属性的实现  
        private Customer? _customer;
        public Customer? Customer
        {
            get
            {
                if (_customer == null && CustomerId != 0)
                {
                    using var context = new OrdersContext();
                    _customer = context.Customers.Find(CustomerId);
                }
                return _customer;
            }
            set => _customer = value;
        }

        public string? CustomerName => Customer?.Name; // 客户姓名  

        public List<OrderDetail> Details { get; set; } = new(); // 订单明细集合

        // 总价  
        public decimal TotalPrice => Details.Sum(d => d.TotalPrice);

        // 构造函数
        public Order() { }
        public Order(int customerId)
        {
            CustomerId = customerId;
        }
        public Order(int customerId, DateTime createTime)
        {
            CustomerId = customerId;
            CreateTime = createTime;
        }

        /*
        public override string ToString()
        {
            StringBuilder builder = new();
            builder.Append($"Order Id: {OrderId}\n");
            builder.Append(Customer?.ToString());
            builder.Append('\n');
            foreach (var v in Details)
            {
                builder.Append('\t');
                builder.Append(v.ToString());
                builder.Append('\n');
            }
            return builder.ToString();
        }*/
    }
}
