using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProdajaSladoleda.Application.DataTransfer.OrderDetailDtos
{
    public class CreateOrderDetailDto
    {
        public int OrderDetailId { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int OrderId { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int ProductId { get; set; }
        [Required]
        [Range(1, 2500)]
        public decimal UnitPrice { get; set; }
        [Required]
        [Range(1, 500)]
        public decimal Quantity { get; set; }
        [Range(0.5, 1)]
        public decimal? Discount { get; set; }
        public bool Active { get; set; }
    }
}
