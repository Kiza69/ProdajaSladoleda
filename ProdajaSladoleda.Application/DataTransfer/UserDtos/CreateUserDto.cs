using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProdajaSladoleda.Application.DataTransfer.UserDtos
{
    public class CreateUserDto
    {
        public int UserId { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Polje mora imati izmedju 3 i 20 karaktera.")]
        [MaxLength(20, ErrorMessage = "Polje mora imati izmedju 2 i 20 karaktera.")]
        public string Username { get; set; }
        [Required]
        [MinLength(7, ErrorMessage = "Polje mora imati minimum 7 karaktera.")]
        public string Password { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int RoleId { get; set; }
        public bool Active { get; set; }
    }
}
