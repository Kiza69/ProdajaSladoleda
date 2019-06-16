using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProdajaSladoleda.Application.DataTransfer.CategoryDtos
{
    public class CreateCategoryDto
    {
        
       
        public int CategoryId { get; set; }
        [Required]
        [MinLength(3, ErrorMessage ="Polje mora imati izmedju 3 i 20 karaktera.")]
        [MaxLength(20, ErrorMessage = "Polje mora imati izmedju 3 i 20 karaktera.")]
        public string Name { get; set; }
        [Required]
        [Range(500,2500)]
        public decimal Price { get; set; }
        public bool Active { get; set; }
    }
}
