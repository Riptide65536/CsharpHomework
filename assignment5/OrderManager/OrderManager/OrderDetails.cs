using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OrderManager
{
    public class OrderDetails
    {
        public Goods Item { get; }
        public int Quantity { get; }

        public OrderDetails(string name, decimal unitPrice, int amount)
        {
            this.Item = new Goods(name, unitPrice);
            this.Quantity = amount;
        }

        public OrderDetails(Goods goods, int amount)
        {
            this.Item = goods;
            this.Quantity = amount;
        }

        public override int GetHashCode()
        => HashCode.Combine(Item?.GetHashCode() ?? 0, Quantity);

        public override bool Equals(object? obj)
        {
            return obj is OrderDetails od 
                && od.Item.Equals(Item) && od.Quantity == Quantity;
        }

        public override string ToString()
        {
            return Item.ToString() + $", Amount: {Quantity}";
        }
    }
}
