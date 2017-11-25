using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phone_Station.Interfaces;

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

        public IList<Record> SortByCost(Report report)
        {
            var reports = report.GetRecords();
            return reports = reports
                .OrderBy(x => x.CostOfTalk)
                .ToList();
                
        }

        public IList<Record> SortByDateOfCall(Report report)
        {
            var reports = report.GetRecords();
            return reports = reports
                .OrderBy(x => x.Start)
                .ToList();
        }

        public IList<Record> SortByNumber(Report report)
        {
            var reports = report.GetRecords();
            return reports = reports
                .OrderBy(x => x.PhoneNumber)
                .ToList();
        }
    }
}
