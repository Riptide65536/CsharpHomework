using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 用于存放可用于订购的订单
// 在之后的内容中，管理员可以对于货物数据进行更新（例如价格和存货）

namespace OrdersWinform
{
    public class StockList
    {
        public Dictionary<Goods, int> Inventory { get; set; }

        public StockList()
        {
            Inventory = [];
        }

        public StockList(Dictionary<Goods, int> inventory)
        {
            Inventory = inventory;
        }

        public void AddStock(Goods goods, int quantity)
        {
            if (!Inventory.TryGetValue(goods, out _))
            {
                Inventory.Add(goods, quantity);
                return;
            }
            Inventory[goods] += quantity;
        }

        public void ReduceStock(Goods goods, int quantity)
        {
            if (!Inventory.TryGetValue(goods, out int stock))
            {
                throw new InvalidOperationException("货物不存在！");
            }
            if (stock < quantity)
            {
                throw new InvalidOperationException("货物存量不足！");
            }
            Inventory[goods] -= quantity;
        }

        public void ClearStock(Goods goods)
        {
            if (!Inventory.TryGetValue(goods, out int stock))
            {
                throw new InvalidOperationException("货物不存在！");
            }
            Inventory.Remove(goods);
        }

        public int CheckStock(Goods goods)
        {
            if (!Inventory.TryGetValue(goods, out int stock))
            {
                throw new InvalidOperationException("货物不存在！");
            }
            return stock;
        }

        public override string ToString()
        {
            StringBuilder builder = new();
            builder.Append($"Current stock:\n");
            foreach (var (g, i) in Inventory)
            {
                builder.Append(g.ToString());
                builder.Append(" Remains: ");
                builder.Append(i);
                builder.Append('\n');
            }
            return builder.ToString();
        }

        internal void UpdateGoodsInfo(Goods goods, Goods newGoods, int quantity)
        {
            if (Inventory.Remove(goods))
            {
                Inventory[newGoods] = quantity;
            }
        }
    }
}
