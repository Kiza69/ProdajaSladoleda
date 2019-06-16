using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProdajaSladoleda.Application.DataTransfer.RoleDtos
{
    public class CreateRoleDto
    {
        public int RoleId { get; set; }
        [Required]
        [MinLength(5, ErrorMessage = "Polje mora imati izmedju 5 i 15 karaktera.")]
        [MaxLength(15, ErrorMessage = "Polje mora imati izmedju 5 i 15 karaktera.")]
        public string Name { get; set; }
        public bool Active { get; set; }
    }
}
