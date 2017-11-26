using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phone_Station.Entities;
using Phone_Station.Interfaces;
using Phone_Station.States;

namespace Phone_Station.Args
{
    public class EndEventArgs : EventArgs
    {
        public DateTime End { get; set; }

        public EndEventArgs(DateTime end)
        {
            End = end;
        }
    }
}
