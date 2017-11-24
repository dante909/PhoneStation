using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phone_Station.States;

namespace Phone_Station.BillingSystem
{
    public class ReportRecord
    {
        public DateTime Start { get; set; }
        public TimeSpan Duration { get; set; }
        public string PhoneNumber { get; set; }
        public CallType CallType { get; set; }

        public ReportRecord(DateTime start, TimeSpan duration, string phoneNumber, CallType callType)
        {
            Start = start;
            Duration = duration;
            PhoneNumber = phoneNumber;
            CallType = callType;
        }


    }
}
