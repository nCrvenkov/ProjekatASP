﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Application.Emails
{
    public class MessageDto
    {
        public string To { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}
