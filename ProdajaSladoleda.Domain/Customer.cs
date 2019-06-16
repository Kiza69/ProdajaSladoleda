using System;
using System.Collections.Generic;
using System.Text;

namespace ProdajaSladoleda.Domain
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int UserId { get; set; }
        public bool Active { get; set; }
        //relations
        public ICollection<Order> Orders { get; set; }
        public User User { get; set; }
    }
}
