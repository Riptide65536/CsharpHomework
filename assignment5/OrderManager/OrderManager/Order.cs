using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager
{
    public class Order
    {
        public int Id { get; set; }
        public string customer { get; }
        private List<OrderDetails> _details = [];
        public IReadOnlyList<OrderDetails> Details => _details.AsReadOnly();
        public Order(int id, string customer) : this(id)
        {
            this.customer = customer;
            _details = [];
        }

        public Order(int id)
        {
            Id = id;
            customer = "";
            _details = [];
        }

        public void AddDetail(Goods g, int amount)
        {
            OrderDetails detail = new(g, amount);
            AddDetail(detail);
        }

        public void AddDetail(OrderDetails detail)
        {
            if (_details.Contains(detail))
                throw new InvalidOperationException("订单明细已存在");
            _details.Add(detail);
        }

        public void RemoveDetail(OrderDetails detail)
        {
            if (!_details.Contains(detail))
                throw new InvalidOperationException("订单明细不存在");
            _details.Remove(detail);
        }

        public decimal CalculateTotal()
            => _details.Sum(d => d.Item.Price * d.Quantity);


        public override int GetHashCode()
            => HashCode.Combine(Id,
                customer,
                _details.Sum(d => d.GetHashCode())
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
            if (order.customer != customer) return false;

            return AreDetailsEqual(order._details, _details);
        }

        public override string ToString()
        {
            StringBuilder builder = new();
            builder.Append($"Id: {Id} Name: {customer}\n");
            foreach(var v in _details)
            {
                builder.Append('\t');
                builder.Append(v.ToString());
                builder.Append('\n');
            }
            return builder.ToString();
        }
    }
}
