﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteQuery.Model
{
    public interface IConnectionStringBuilder
    {
        string BuildConnectionString(IConnectionData connectionData);
    }
}
