﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Application.UseCases
{
    public interface IUseCase
    {
        public int Id { get; }
        string Name { get; }
        string Description { get; }
    }
}
