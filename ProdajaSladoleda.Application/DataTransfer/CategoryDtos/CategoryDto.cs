using ProdajaSladoleda.Application.DataTransfer.ProductDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdajaSladoleda.Application.DataTransfer.CategoryDtos
{
    public class CategoryDto
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool Active { get; set; }
        public IEnumerable<ProductDto> Products { get; set; }
    }
}
