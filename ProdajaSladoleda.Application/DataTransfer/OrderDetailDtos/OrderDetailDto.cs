using ProdajaSladoleda.Application.DataTransfer.OrderDtos;
using ProdajaSladoleda.Application.DataTransfer.ProductDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdajaSladoleda.Application.DataTransfer.OrderDetailDtos
{
    public class OrderDetailDto
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Quantity { get; set; }
        public decimal? Discount { get; set; }
        public bool Active { get; set; }
        //relations
        public OrderDto Order { get; set; }
        public ProductDto Product { get; set; }
    }
}
