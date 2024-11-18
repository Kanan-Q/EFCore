using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewEFCore.Models
{
    public class Baskets
    {
        public int Id { get; set; }
        public int BasketUserId { get; set; }
        public int BasketProductId { get; set; }
        public Users User { get; set; }
        public Products Product { get; set; }
    }
}
