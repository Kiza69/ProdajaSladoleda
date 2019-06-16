using System;
using System.Collections.Generic;
using System.Text;

namespace ProdajaSladoleda.Domain
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Total { get; set; }
        public DateTime? ShipDate { get; set; }
        public int? EmployeeId { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public bool Active { get; set; }
        //relations
        public Customer Customer { get; set; }
        public Employee Employee { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
