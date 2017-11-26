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
    public class CallEventArgs : EventArgs
    {
        public string PhoneNumber { get; set; }
        public string TargetPhoneNumber { get; set; }
        public CallState StateCall { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public CallEventArgs(string phoneNumber, string targetNumber)
        {
            PhoneNumber = phoneNumber;
            TargetPhoneNumber = targetNumber;
        }
    }
}
