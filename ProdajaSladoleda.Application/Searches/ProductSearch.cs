using ProdajaSladoleda.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdajaSladoleda.Application.Searches
{
    public class ProductSearch
    {
        public string Keyword { get; set; }
        public int CategoryId { get; set; }
        public bool? IsActive { get; set; }
    }
}
