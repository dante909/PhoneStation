﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Station.Interfaces
{
    public interface IStation<T>
    {
        IList<T> GetInfoList();
    }
}
