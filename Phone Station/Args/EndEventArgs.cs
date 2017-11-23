using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phone_Station.Entities;

namespace Phone_Station.Args
{
    public class EndEventArgs : EventArgs
    {
        public CallInfo CallInfo { get; set; }

        public EndEventArgs(CallInfo callInfo)
        {
            CallInfo = callInfo;
        }
    }
}
