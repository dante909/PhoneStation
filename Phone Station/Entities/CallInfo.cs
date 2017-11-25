using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Station.Entities
{
    public class CallInfo
    {
        public DateTime Start { get; set; }
        public TimeSpan Duration { get; set; }
        public string MyPhoneNumber { get; set; }
        public string TargetPhoneNumber { get; set; }
        public int CostOfTalk { get; set; }

        public CallInfo(DateTime start, TimeSpan duration, string myPhoneNumber, string targetPhoneNumber, int costOfTalk)
        {
            Start = start;
            Duration = duration;
            MyPhoneNumber = myPhoneNumber;
            TargetPhoneNumber = targetPhoneNumber;
            CostOfTalk = costOfTalk;
        }

            public CallInfo()
        {

        }
    }
}
