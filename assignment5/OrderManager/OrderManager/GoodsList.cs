using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 用于存放可用于订购的订单
// 在之后的内容中，管理员可以对于货物数据进行更新（例如价格和存货）

namespace OrderManager
{
    public class GoodsList
    {
        readonly Dictionary<Goods, int> _inventory;

        public GoodsList()
        {
            _inventory = [];
        }

        public void AddStock(Goods goods, int quantity)
        {
            if (!_inventory.TryGetValue(goods, out _))
            {
                _inventory.Add(goods, quantity);
                return;
            }
            _inventory[goods] += quantity;
        }

        public void ReduceStock(Goods goods, int quantity)
        {
            if (!_inventory.TryGetValue(goods, out int stock))
            {
                throw new InvalidOperationException("货物不存在！");
            }
            if (stock < quantity)
            {
                throw new InvalidOperationException("货物存量不足！");
            }
            _inventory[goods] -= quantity;
        }

        public int CheckStock(Goods goods)
        {
            if (!_inventory.TryGetValue(goods, out int stock))
            {
                throw new InvalidOperationException("货物不存在！");
            }
            return stock;
        }

        public override string ToString()
        {
            StringBuilder builder = new();
            builder.Append($"Current stock:\n");
            foreach (var (g, i) in _inventory)
            {
                builder.Append(g.ToString());
                builder.Append(" Remains: ");
                builder.Append(i);
                builder.Append('\n');
            }
            return builder.ToString();
        }
    }
}
