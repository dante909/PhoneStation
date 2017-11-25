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
            List<Port> port = new List<Port>();
            port.Add(new Port(ats, "0001"));
            port.Add(new Port(ats, "0002"));
            port.Add(new Port(ats, "0003"));

            DisplayReport report = new DisplayReport();
            Billing bs = new Billing(ats);
            Contract c1 = new Contract(new Client("Stieve", "Stieve"), port[0].PortNumber, Rate.Absolute);
            Contract c2 = new Contract(new Client("Bob", "Bob"), port[1].PortNumber, Rate.Ultra);
            Contract c3 = new Contract(new Client("Rick", "Rick"), port[2].PortNumber, Rate.Absolute);
            var t1 = ats.GetNewTerminal(c1);
            var t2 = ats.GetNewTerminal(c2);
            var t3 = ats.GetNewTerminal(c3);
            t1.ConnectToPort();
            t2.ConnectToPort();
            t3.ConnectToPort();
            t1.Call(t2.PhoneNumber);
            t2.Call(t3.PhoneNumber);
            t2.Call(t2.PhoneNumber);
            t2.Call("54532");
            Console.Write($"\nList of records of the abonent: {t2.PhoneNumber}");
            Console.WriteLine();
            report.Display(bs.GetReport(t2.PhoneNumber));
            report.SortByCost(bs.GetReport(t2.PhoneNumber));
            report.DisplaySortedCall(report.SortByCost(bs.GetReport(t2.PhoneNumber)));

        }
    }
}
