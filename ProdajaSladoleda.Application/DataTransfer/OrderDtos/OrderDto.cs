using ProdajaSladoleda.Application.DataTransfer.CustomerDtos;
using ProdajaSladoleda.Application.DataTransfer.EmployeeDtos;
using ProdajaSladoleda.Application.DataTransfer.OrderDetailDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdajaSladoleda.Application.DataTransfer.OrderDtos
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Total { get; set; }
        public DateTime? ShipDate { get; set; }
        public bool IsShipped
        {
            get
            {
                return ShipDate != null;

            }
        }
        public int? EmployeeId { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public bool Active { get; set; }
        //relations
        public CustomerDto Customer { get; set; }
        public EmployeeDto Employee { get; set; }
        public IEnumerable<OrderDetailDto> OrderDetails { get; set; }
    }
}
