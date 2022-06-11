﻿using ProjekatASP.Application.UseCases.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Application.UseCases.Commands
{
    public interface IAddCommentCommand : ICommand<AddCommentsDto>
    {
    }
}
