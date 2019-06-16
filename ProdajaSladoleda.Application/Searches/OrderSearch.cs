using System;
using System.Collections.Generic;
using System.Text;

namespace ProdajaSladoleda.Application.Searches
{
    public class OrderSearch : Pagination
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? StartTotal { get; set; }
        public decimal? EndTotal { get; set; }
        public int? CustomerId { get; set; }
        public bool? IsShipped { get; set; }
        public int? ShipperId { get; set; }
        public string ProductName { get; set; }
        public bool? IsActive { get; set; }
    }
}
