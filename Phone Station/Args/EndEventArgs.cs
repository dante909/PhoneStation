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
        public string Message { get; set; }
        public EndEventArgs(string message)
        {
            Message = message;
        }
    }
}
