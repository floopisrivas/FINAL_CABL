using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public string Email { get; set; }

        // Relación uno a muchos con Order
        public ICollection<Order> Orders { get; set; } = new List<Order>();

    }
}
