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

            Contract c1 = new Contract("John", "23145", Rate.Absolute, ats);
            Contract c2 = new Contract("Bob", "12423", Rate.Absolute, ats);
            Contract c3 = new Contract("Rick", "235213", Rate.Absolute, ats);
            var t1 = c1.RegisterContract();
            var t2 = c2.RegisterContract();
            var t3 = c3.RegisterContract();
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
