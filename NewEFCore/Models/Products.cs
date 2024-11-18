using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewEFCore.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = null!;
        public decimal ProductPrice { get; set; }
        public ICollection<Baskets> Baskets { get; set; }
    }
}
