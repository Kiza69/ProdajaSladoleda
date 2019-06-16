using ProdajaSladoleda.Application.DataTransfer.CategoryDtos;
using ProdajaSladoleda.Application.DataTransfer.OrderDetailDtos;
using ProdajaSladoleda.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdajaSladoleda.Application.DataTransfer.ProductDtos
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public string Filename { get; set; }
        public bool Active { get; set; }
        public CategoryDto Category { get; set; }
        public IEnumerable<OrderDetailDto> OrderDetails { get; set; }
    }
}
