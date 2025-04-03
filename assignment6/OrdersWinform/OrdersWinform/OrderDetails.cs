using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OrdersWinform
{
    public class OrderDetails : INotifyPropertyChanged
    {
        private Goods _item;
        public Goods Item
        {
            get { return _item; }
            set
            {
                _item = value;
                OnPropertyChanged("Item");
            }
        }
        private int _quantity;
        public int Quantity {
            get { return _quantity; }
            set
            {
                _quantity = value;
                OnPropertyChanged("Quantity");
            }
        }

        public decimal TotalPrice
        {
            get => Item.Price * Quantity; 
        }

        public OrderDetails(string name, decimal unitPrice, int amount)
        {
            _item = new Goods(name, unitPrice);
            _quantity = amount;
        }

        public OrderDetails(Goods goods, int amount)
        {
            _item = goods;
            _quantity = amount;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(name));
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
            return Item.ToString() + $", Amount: {Quantity}\tSubtotal: {TotalPrice}";
        }
    }
}
