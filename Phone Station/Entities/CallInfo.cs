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
        public string PhoneNumber { get; set; }

        public CallInfo(DateTime start, TimeSpan duration, string phoneNumber)
        {
            Start = start;
            Duration = duration;
            PhoneNumber = phoneNumber;
        }

            public CallInfo()
        {

        }

        public override string ToString()
        {
            return string.Format("Phone Number: {0}, Begin of talk: {1}, Duration: {2}", PhoneNumber, Start.ToString(), Duration.ToString());
        }
    }
}
