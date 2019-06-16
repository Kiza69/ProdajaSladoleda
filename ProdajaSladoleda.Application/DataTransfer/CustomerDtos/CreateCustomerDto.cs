using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProdajaSladoleda.Application.DataTransfer.CustomerDtos
{
    public class CreateCustomerDto
    {
        public int CustomerId { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Polje mora imati izmedju 3 i 20 karaktera.")]
        [MaxLength(20, ErrorMessage = "Polje mora imati izmedju 3 i 20 karaktera.")]
        public string FirstName { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Polje mora imati izmedju 3 i 20 karaktera.")]
        [MaxLength(20, ErrorMessage = "Polje mora imati izmedju 3 i 20 karaktera.")]
        public string LastName { get; set; }
        [Required]
        [MinLength(5, ErrorMessage = "Polje mora imati izmedju 5 i 50 karaktera.")]
        [MaxLength(50, ErrorMessage = "Polje mora imati izmedju 5 i 50 karaktera.")]
        public string Address { get; set; }
        [Required]
        [MinLength(11, ErrorMessage = "Polje mora imati izmedju 11 i 13 karaktera.")]
        [MaxLength(13, ErrorMessage = "Polje mora imati izmedju 11 i 13 karaktera.")]
        public string Phone { get; set; }
        [Required]
        [MaxLength(30, ErrorMessage = "Polje mora imati najvise 30 karaktera.")]
        public string Email { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int UserId { get; set; }
        public bool Active { get; set; }
    }
}
