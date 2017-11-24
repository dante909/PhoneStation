﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phone_Station.Interfaces;
using Phone_Station.Entities;

namespace Phone_Station.BillingSystem
{
    public class Billing
    {
        public IStation<CallInfo> _storage;

        public Billing(IStation<CallInfo> storage)
        {
            _storage = storage;
        }
        //доделать по номеру
        public Report GetReport(string phoneNumber)
        {
            var calls = _storage.GetInfoList().
                Where(x => x.PhoneNumber == phoneNumber).ToList();
            var report = new Report();

            foreach (var call in calls)
            {
                var record = new CallInfo(call.Start, call.Duration, call.PhoneNumber); 
                report.AddRecord(record);
            }
            return report;
        }
    }
}
