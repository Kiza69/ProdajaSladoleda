﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ProdajaSladoleda.Application.Searches
{
    public class UserSearch : Pagination
    {
        public string Keyword { get; set; }
        public bool? IsActive { get; set; }
    }
}