﻿using ProjekatASP.Application.UseCases.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Application.UseCases.Queries
{
    public interface IFindCategoryQuery : IQuery<int, CategoryDto>
    {
    }
}
