﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phone_Station.Interfaces;
using Phone_Station.Entities;
using Phone_Station.States;

namespace Phone_Station.BillingSystem
{
    public class Billing
    {
        public IStation<CallInfo> _storage;

        public Billing(IStation<CallInfo> storage)
        {
            _storage = storage;
        }

        public Report GetReport(string phoneNumber)
        {
            var calls = _storage.GetInfoList().
                Where(x => x.MyPhoneNumber == phoneNumber || x.TargetPhoneNumber == phoneNumber).ToList();
            var report = new Report();
            foreach (var call in calls)
            {
                CallType callType;
                string number;
                if (call.MyPhoneNumber == phoneNumber)
                {
                    callType = CallType.Outcoming;
                    number = call.TargetPhoneNumber;
                }
                else
                {
                    callType = CallType.Incoming;
                    number = call.MyPhoneNumber;                
                }               

                var record = new Record(call.Start, call.Duration, number, callType, call.CostOfTalk); 
                report.AddRecord(record);
            }
            return report;
        }
    }
}
