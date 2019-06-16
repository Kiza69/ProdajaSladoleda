using System;
using System.Collections.Generic;
using System.Text;
using ProdajaSladoleda.Application.DataTransfer.OrderDtos;
using ProdajaSladoleda.Application.DataTransfer.UserDtos;
using ProdajaSladoleda.Domain;

namespace ProdajaSladoleda.Application.DataTransfer.CustomerDtos
{
    public class CustomerDto
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
        public IEnumerable<OrderDto> Orders { get; set; }
        public UserDto User { get; set; }
    }
}
