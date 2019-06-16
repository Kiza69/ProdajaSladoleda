using System;
using System.Collections.Generic;
using System.Text;

namespace ProdajaSladoleda.Domain
{
    public class Role
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        //relations
        public ICollection<User> Users { get; set; }
    }
}
