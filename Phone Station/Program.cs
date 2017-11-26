using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phone_Station.States;
using Phone_Station.Args;
using Phone_Station.Entities;
using Phone_Station.BillingSystem;
using System.ComponentModel;

namespace Phone_Station
{
    class Program
    {

        static void OnBalacneChanged(object sender, PropertyChangedEventArgs e)
        {
            Client sample = (Client)sender;
            Console.WriteLine("Value of property {0} was changed! New value is {1}", e.PropertyName, sample.Balance);
        }

        static void Main(string[] args)
        { 
            Station ats = new Station();
            List<Port> port = new List<Port>();
            port.Add(new Port(ats, "0001"));
            port.Add(new Port(ats, "0002"));
            port.Add(new Port(ats, "0003"));

            Client client1 = new Client("Stieve", "Stieve", 100);
            Client client2 = new Client("Bob", "Bob", 50);
            Client client3 = new Client("Rick", "Rick", 30);
            client1.PropertyChanged += OnBalacneChanged;
            client2.PropertyChanged += OnBalacneChanged;
            client3.PropertyChanged += OnBalacneChanged;

            DisplayReport report = new DisplayReport();
            Billing bs = new Billing(ats);
            Contract c1 = new Contract(client1, port[0].PortNumber, Rate.Absolute);
            Contract c2 = new Contract(client2, port[1].PortNumber, Rate.Ultra);
            Contract c3 = new Contract(client3, port[2].PortNumber, Rate.Absolute);
            //c1.Client.AddMoney(20);
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
            report.Sort(bs.GetReport(t2.PhoneNumber), TypeOfSorting.ByCostOfTalk);
            report.DisplaySortedCall(report.Sort(bs.GetReport(t2.PhoneNumber), TypeOfSorting.ByCostOfTalk));
            //c1.Client.ShowBalance();

        }
    }
}
