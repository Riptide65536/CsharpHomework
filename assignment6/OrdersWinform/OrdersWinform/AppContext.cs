using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersWinform
{
    public static class AppContext
    {
        public static StockList StockList { get; } = new();
    }
}
