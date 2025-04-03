using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersWinform
{
    public class Order: IComparable<Order>
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public DateTime CreateTime { get; set; }

        private readonly BindingList<OrderDetails> details = [];
        public BindingList<OrderDetails> Details => details;

        public decimal TotalPrice { get => details.Sum(d => d.TotalPrice); }

        public Order(int id, Customer customer, DateTime time) : this(id)
        {
            Customer = customer;
            CreateTime = time;
            details = [];
        }

        public Order(int id, Customer customer) : this(id)
        {
            Customer = customer;
            CreateTime = DateTime.Now;
            details = [];
        }

        public Order(int id)
        {
            Id = id;
            Customer = new Customer();
            CreateTime = DateTime.Now;
            details = [];
        }

        public void AddDetail(Goods g, int amount)
        {
            OrderDetails detail = new(g, amount);
            AddDetail(detail);
        }

        public void AddDetail(OrderDetails detail)
        {
            if (details.Contains(detail))
                throw new InvalidOperationException("订单明细已存在");
            details.Add(detail);
        }

        public void RemoveDetail(OrderDetails detail)
        {
            if (!details.Contains(detail))
                throw new InvalidOperationException("订单明细不存在");
            details.Remove(detail);
        }

        public override int GetHashCode()
            => HashCode.Combine(Id,
                Customer
                );
        private static bool AreDetailsEqual(IEnumerable<OrderDetails> a, IEnumerable<OrderDetails> b)
        {
            var cnt = new Dictionary<OrderDetails, int>();
            foreach (var d in a) 
                cnt[d] = (cnt.TryGetValue(d, out var v) ? v : 0) + 1;
            foreach (var d in b)
            {
                if (!cnt.ContainsKey(d)) return false;
                cnt[d]--;
            }
            return cnt.Values.All(c => c == 0);
        }
        public override bool Equals(object? obj)
        {
            if (obj is not Order order) return false;
            if (order.Id != Id) return false;
            if (!order.Customer.Equals(Customer)) return false;

            return AreDetailsEqual(order.details, details);
        }

        public override string ToString()
        {
            StringBuilder builder = new();
            builder.Append($"Order Id: {Id}\n");
            builder.Append(Customer.ToString());
            builder.Append('\n');
            foreach(var v in details)
            {
                builder.Append('\t');
                builder.Append(v.ToString());
                builder.Append('\n');
            }
            return builder.ToString();
        }

        public int CompareTo(Order? other)
        {
            return (other == null) ? 1 : Id - other.Id;
        }
    }
}
