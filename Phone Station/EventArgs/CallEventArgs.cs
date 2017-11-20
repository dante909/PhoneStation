using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Station.Classes
{
    public delegate void CallStateHandler(object sender, CallEventArgs e);
    public class CallEventArgs
    {
        public string Message { get; private set; }
        public Call CallInfo { get; private set; }

        public CallEventArgs(string message, Call callInfo)
        {
            Message = message;
            CallInfo = callInfo;
        }

        public CallEventArgs(string message)
        {
            Message = message;
        }
    }
}
