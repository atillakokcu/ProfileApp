﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileApp.Common
{
    public interface IResponse
    {
        string Message { get; set; }

        ResponseType ResponseType { get; set; }
    }
}
