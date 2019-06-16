using ProdajaSladoleda.Application.DataTransfer.CustomerDtos;
using ProdajaSladoleda.Application.DataTransfer.EmployeeDtos;
using ProdajaSladoleda.Application.DataTransfer.RoleDtos;
using System.Collections.Generic;

namespace ProdajaSladoleda.Application.DataTransfer.UserDtos
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public bool Active { get; set; }
        //relations
        public IEnumerable<CustomerDto> Customer { get; set; }
        public IEnumerable<EmployeeDto> Employee { get; set; }
        public RoleDto Role { get; set; }
    }
}
