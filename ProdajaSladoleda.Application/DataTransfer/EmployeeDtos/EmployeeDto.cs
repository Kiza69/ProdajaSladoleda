using System;
using System.Collections.Generic;
using System.Text;
using ProdajaSladoleda.Application.DataTransfer.OrderDtos;
using ProdajaSladoleda.Application.DataTransfer.UserDtos;
using ProdajaSladoleda.Domain;

namespace ProdajaSladoleda.Application.DataTransfer.EmployeeDtos
{
    public class EmployeeDto
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime HireDate { get; set; }
        public int UserId { get; set; }
        public bool Active { get; set; }
        //relations
        public UserDto User { get; set; }
        public IEnumerable<OrderDto> Orders { get; set; }
    }
}
