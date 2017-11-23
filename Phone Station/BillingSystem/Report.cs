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
        private IList<CallInfo> _listRecords;

        public Report()
        {
            _listRecords = new List<CallInfo>();
        }

        public void AddRecord(CallInfo record)
        {
            _listRecords.Add(record);
        }

        public IList<CallInfo> GetRecords()
        {
            return _listRecords;
        }
    }
}
