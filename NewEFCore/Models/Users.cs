using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewEFCore.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public string UserSurname { get; set; } = null!;
        public string Usersname { get; set; } = null!;
        public string UserPassword { get; set; } = null!;
        public ICollection<Baskets> Baskets { get; set; }

    }
}
