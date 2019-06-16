using System;
using System.Collections.Generic;
using System.Text;

namespace ProdajaSladoleda.Domain
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Quantity { get; set; }
        public decimal? Discount { get; set; }
        public bool Active { get; set; }
        //relations
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
