using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProdajaSladoleda.Application.DataTransfer.OrderDtos
{
    public class CreateOrderDto
    {
        public int OrderId { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int CustomerId { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Range(0,100000)]
        public decimal Total { get; set; }
        public DateTime? ShipDate { get; set; }
        [Range(1, int.MaxValue)]
        public int? EmployeeId { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Polje mora imati izmedju 3 i 20 karaktera.")]
        [MaxLength(20, ErrorMessage = "Polje mora imati izmedju 3 i 20 karaktera.")]
        public string ShipName { get; set; }
        [Required]
        [MinLength(5, ErrorMessage = "Polje mora imati izmedju 5 i 50 karaktera.")]
        [MaxLength(50, ErrorMessage = "Polje mora imati izmedju 5 i 50 karaktera.")]
        public string ShipAddress { get; set; }
        public bool Active { get; set; }
    }
}
