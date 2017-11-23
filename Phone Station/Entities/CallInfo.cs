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

        public CallInfo(DateTime start, TimeSpan duration)
        {
            Start = start;
            Duration = duration;
        }

            public CallInfo()
        {

        }

        public override string ToString()
        {
            return string.Format("Begin of talk: {0}, Duration: {1}", Start.ToString(), Duration.ToString());
        }
    }
}
