using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phone_Station.States;
using Phone_Station.Interfaces;

namespace Phone_Station.Args
{
    public class AnswerEventArgs : EventArgs
    {
        public string PhoneNumber { get; set; }
        public string TargetPhoneNumber { get; set; }
        public CallState StateCall { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public AnswerEventArgs(string phoneNumber, string targetNumber, CallState state)
        {
            PhoneNumber = phoneNumber;
            TargetPhoneNumber = targetNumber;
            StateCall = state;
        }
    }
}
