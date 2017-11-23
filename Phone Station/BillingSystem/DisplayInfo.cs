using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Station.BillingSystem
{
    public class DisplayInfo
    {
        public DisplayInfo()
        {

        }
        public void Display(Report report)
        {
            foreach (var record in report.GetRecords())
            {
                Console.WriteLine(record);
            }
        }
    }
}
