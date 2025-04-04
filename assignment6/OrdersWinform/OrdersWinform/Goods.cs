﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersWinform
{
    public class Goods(string name, decimal price)
    {
        public string Name { get; } = name;
        public decimal Price { get; } = price;
        public override int GetHashCode()
        => HashCode.Combine(Name?.GetHashCode() ?? 0, Price);
        public override bool Equals(object? obj)
        {
            return obj is Goods g
                && g.Name == Name && g.Price == Price;
        }
        public override string ToString()
        {
            return $"Name: {Name}, Price: {Price}";
        }

    }
}
