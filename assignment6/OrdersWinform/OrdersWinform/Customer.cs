using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersWinform
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Customer()
        {
            Id = -1;
            Name = "";
        }

        public Customer(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override int GetHashCode()
        => HashCode.Combine(Id, Name);

        public override bool Equals(object? obj)
        {
            return obj is Customer cu
                && cu.Id == this.Id;
        }

        public override string ToString()
        {
            return $"Customer: {Name}, CustomerId: {Id}";
        }
    }
}
