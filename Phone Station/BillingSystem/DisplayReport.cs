using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phone_Station.Interfaces;
using Phone_Station.States;

namespace Phone_Station.BillingSystem
{
    public class DisplayReport : ISort<Record, Report>
    {
        public DisplayReport()
        {

        }
        public void Display(Report report)
        {
            Console.WriteLine("\n{0,-15} {1,10} {2,25} {3,20} {4,8}",
                "Number",
                "Start",
                "Duration",
                "Type of Call",
                "Cost");
            foreach (var record in report.GetRecords())
            {
                Console.WriteLine("{0}|\t{1}|\t{2}|\t{3,10}|\t{4,1} |",
                    record.PhoneNumber, record.Start.ToString(), record.Duration.ToString(), 
                    record.CallType.ToString(), record.CostOfTalk.ToString());
            }
        }

        public void DisplaySortedCall(IList<Record> rec)
        {
            Console.WriteLine("\n{0,-15} {1,10} {2,25} {3,20} {4,8}",
                "Number",
                "Start",
                "Duration",
                "Type of Call",
                "Cost");
            foreach (var record in rec)
            {
                Console.WriteLine("{0}|\t{1}|\t{2}|\t{3,10}|\t{4,1} |",
                    record.PhoneNumber, record.Start.ToString(), record.Duration.ToString(),
                    record.CallType.ToString(), record.CostOfTalk.ToString());
            }
        }

        public IList<Record>Sort(Report report, TypeOfSorting type)
        {
            var records = report.GetRecords();
            if (type == TypeOfSorting.ByCostOfTalk)
                return records = records
                .OrderBy(x => x.CostOfTalk)
                .ToList();
            else if (type == TypeOfSorting.ByDate)
                return records = records
                    .OrderBy(x => x.Start)
                    .ToList();
            else if (type == TypeOfSorting.ByPhoneNumber)
                return records = records
                    .OrderBy(x => x.PhoneNumber)
                    .ToList();
            else
                return records;

        }
    }
}
