using OrderManagerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagerAPI.Models
{
    public class Order
    {
        public int OrderId { get; set; }          // 主键  
        public DateTime CreateTime { get; set; } // 创建时间  

        // 关系配置  
        public int CustomerId { get; set; }        // 外键  
        public Customer? Customer { get; set; } // 客户对象（导航属性）

        public string? CustomerName => Customer?.Name; // 客户姓名  

        public List<OrderDetail> Details { get; set; } = []; // 订单明细集合

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
