﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIProject.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        APIProjectEntities Init();
    }
}
