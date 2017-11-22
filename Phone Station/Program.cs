using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phone_Station.States;
using Phone_Station.Args;
using Phone_Station.Entities;
using Phone_Station.BillingSystem;


namespace Phone_Station
{
    class Program
    {

        static void Main(string[] args)
        {
            Station ats = new Station();
            
            Contract c1 = new Contract(new Client("sffa", "asfaf"), "892341", Rate.Absolute, ats);
            Contract c2 = new Contract(new Client("sfaf", "asfaf"), "892431", Rate.Ultra, ats);
            Contract c3 = new Contract(new Client("sfaf", "asfaf"), "8923541", Rate.Absolute, ats);
            var t1 = ats.GetNewTerminal(c1.PhoneNumber);
            var t2 = ats.GetNewTerminal(c2.PhoneNumber);
            var t3 = ats.GetNewTerminal(c3.PhoneNumber);
            t1.ConnectToPort();
            t2.ConnectToPort();
            t3.ConnectToPort();
            t1.Call(t2.PhoneNumber);
            t2.AnswerToCall(t1.PhoneNumber, CallState.Rejected);
            t2.Call(t3.PhoneNumber);
            t3.AnswerToCall(t2.PhoneNumber, CallState.Answered);
            t2.Call(t2.PhoneNumber);
            t2.Call("54532");
            Console.ReadKey();

        }
    }
}
