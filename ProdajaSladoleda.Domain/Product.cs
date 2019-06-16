using System;
using System.Collections.Generic;
using System.Text;

namespace ProdajaSladoleda.Domain
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public string Filename { get; set; }
        public bool Active { get; set; }
        //relations
        public Category Category { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
