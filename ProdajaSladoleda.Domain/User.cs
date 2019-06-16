﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ProdajaSladoleda.Domain
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public bool Active { get; set; }
        //relations
        public ICollection<Customer> Customer { get; set; }
        public ICollection<Employee> Employee { get; set; }
        public Role Role { get; set; }
    }
}