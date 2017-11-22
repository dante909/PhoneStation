using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phone_Station.Entities;

namespace Phone_Station.Args
{
    public class CallEventArgs : EventArgs
    {
        public string PhoneNumber { get; set; }
        public string TargetPhoneNumber { get; set; }

        public CallEventArgs(string phoneNumber, string targetNumber)
        {
            PhoneNumber = phoneNumber;
            TargetPhoneNumber = targetNumber;
        }
    }
}
