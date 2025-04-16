using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagerAPI.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; } // 主键  

        [Required]
        [StringLength(50)]
        public string? Name { get; set; } // 用户名  

        // public List<Order> Orders { get; set; } = [];

        public Customer() { }
        public Customer(string name)
        {
            Name = name;
        }
        public override string ToString()
        {
            return $"CustomerId: {CustomerId}, Name: {Name}";
        }
    }
}
