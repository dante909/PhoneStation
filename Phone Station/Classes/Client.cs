﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Station.Classes
{
    public class Client
    {
        public string Name { get; private set; }
        public Terminal Terminal { get; private set; }
        public Rate Rate { get; private set; }

        public Client(Rate rate, Terminal terminal)
        {
            Terminal = terminal;
            Rate = rate;
        }

        public Client(Rate rate, Terminal terminal, string name)
        {
            Terminal = terminal;
            Rate = rate;
            Name = name;
        }
    }
}
