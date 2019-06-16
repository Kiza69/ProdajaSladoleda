using ProdajaSladoleda.Application.DataTransfer.UserDtos;
using ProdajaSladoleda.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProdajaSladoleda.Application.DataTransfer.RoleDtos
{
    public class RoleDto
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        //relations
        public IEnumerable<UserDto> Users { get; set; }
    }
}
