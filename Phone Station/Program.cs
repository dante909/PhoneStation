using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Station.Classes
{
    class Program
    {
        static void Display(object sender, CallEventArgs e)
        {
            Console.WriteLine(e.Message);
        }

        static void Disconnect(object sender, CallEventArgs e)
        {
            Console.ReadKey();
            Console.WriteLine(e.Message);
        }

        static void Main(string[] args)
        {
            Port port1 = new Port(PortCondition.Connected, "001");
            Port port2 = new Port(PortCondition.Connected, "002");

            Terminal t1 = new Terminal(port1);
            Terminal t2 = new Terminal(port2);

            List<Call> callCollection = new List<Call>();
            List<Terminal> terminalCollection = new List<Terminal>();
            terminalCollection.Add(t1);
            terminalCollection.Add(t2);

            Station station = new Station(terminalCollection);

            station.Connecting += Display;
            station.Connected += Display;
            station.Disconnected += Disconnect;
            station.PhoneCall(t2);


        }
    }
}
