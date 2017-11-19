using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Station.Classes
{
    public class Port
    {
        public PortCondition Condition { get; private set; }
        public string PortNumber { get; private set; }

        public Port(PortCondition condition, string portNumber)
        {
            Condition = condition;
            PortNumber = portNumber;
        }

    }
}
