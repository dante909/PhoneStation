using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phone_Station.Entities;

namespace Phone_Station.BillingSystem
{
    public class Report
    {
        private IList<Record> _listRecords;

        public Report()
        {
            _listRecords = new List<Record>();
        }

        public void AddRecord(Record record)
        {
            _listRecords.Add(record);
        }

        public IList<Record> GetRecords()
        {
            return _listRecords;
        }
    }
}
