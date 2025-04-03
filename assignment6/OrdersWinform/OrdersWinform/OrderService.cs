using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OrdersWinform
{
    public class OrderService
    {
        private List<Order> _orders;
        public IReadOnlyList<Order> Orders => _orders.AsReadOnly();
        public OrderService()
        {
            _orders = [];
        }
        public OrderService(List<Order> orders)
        {
            _orders = orders;
        }
        public void AddOrder(Order order)
        {
            if (_orders.Contains(order))
                throw new InvalidOperationException("订单已存在");
            _orders.Add(order);
        }
        public void RemoveOrder(int id)
        {
            _orders.RemoveAll(o => o.Id == id);
        }
        public void UpdateOrder(int id, Order newOrder)
        {
            var existing = _orders.FirstOrDefault(o => o.Id == id);
            if (existing == null) throw new InvalidOperationException("订单不存在");

            // 仅允许修改非关键字段
            existing = newOrder;
        }

        public IEnumerable<Order> SearchOrders(Expression<Func<Order, bool>> predicate)
        {
            // 转换为 IQueryable 以支持表达式树编译
            return _orders.AsQueryable().Where(predicate.Compile());
        }

        public void SortOrders(Expression<Func<Order, object>>? keySelector = null, bool isDescending = false)
        {
            var query = _orders.AsQueryable();
            if (keySelector != null)
            {
                query = isDescending ? query.OrderByDescending(keySelector)
                                     : query.OrderBy(keySelector);
            }
            else
            {
                // 默认按总金额降序
                query = query.OrderBy(o => o.Id);
            }
            _orders = query.ToList();
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _orders; 
        }
    }
}
