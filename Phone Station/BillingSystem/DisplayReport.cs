using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Station.BillingSystem
{
    public class DisplayReport
    {
        public DisplayReport()
        {

        }
        public void Display(Report report)
        {
            foreach (var record in report.GetRecords())
            {
                Console.WriteLine("Phone number: {0},  Begining of talk: {1}, Duration talk: {2}, Call type: {3}",
                    record.PhoneNumber, record.Start.ToString(), record.Duration.ToString(), record.CallType.ToString());
            }
        }
    }
}
