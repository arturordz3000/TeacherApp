﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Implementations
{
    public interface ICacheStorage
    {
        object Get(string query);
        void Save(string key, object value);
        int Delete(string query);
    }
}
