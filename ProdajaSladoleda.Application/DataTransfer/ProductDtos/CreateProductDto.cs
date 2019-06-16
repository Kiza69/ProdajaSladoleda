using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProdajaSladoleda.Application.DataTransfer.ProductDtos
{
    public class CreateProductDto
    {
        public int ProductId { get; set; }
        [Required]
        [MinLength(3, ErrorMessage ="Naziv proizvoda mora imati izmedju 3 i 20 karaktera!")]
        [MaxLength(20, ErrorMessage = "Naziv proizvoda mora imati izmedju 3 i 20 karaktera!")]
        public string Name { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage ="Niste izabrali kategoriju !")]
        public int CategoryId { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Naziv proizvoda mora imati izmedju 3 i 120 karaktera!")]
        [MaxLength(120, ErrorMessage = "Naziv proizvoda mora imati izmedju 3 i 120 karaktera!")]
        public string Description { get; set; }
        [Required]
        public string Filename { get; set; }
        public bool Active { get; set; }
    }
}
