﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Application.UseCases.DTO.Searches
{
    public class BaseSearch
    {
        public string Keyword { get; set; }
    }

    public class PagedSearch
    {
        public int? PerPage { get; set; } = 5;
        public int? Page { get; set; } = 1;
    }

    public class BasePagedSearch : PagedSearch
    {
        public string Keyword { get; set; }
    }
}
