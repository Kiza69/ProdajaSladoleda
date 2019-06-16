using System;
using System.Collections.Generic;
using System.Text;

namespace ProdajaSladoleda.Application.Searches
{
    public class OrderDetailSearch : Pagination
    {
        public int? OrderId { get; set; }
        public string ProductName { get; set; }
        public bool? IsActive { get; set; }
    }
}
