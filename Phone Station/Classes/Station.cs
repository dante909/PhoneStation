using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace Phone_Station.Classes
{
    public class Station
    {
        private ICollection<Terminal> _teminalCollection;
      //  private ICollection<Port> _portCollection;
        private ICollection<Call> _callCollectiom;

        public event CallStateHandler Connecting;
        public event CallStateHandler Connected;
        public event CallStateHandler Disconnected;


        public Station(ICollection<Terminal> terminalCollection)
        {
            _teminalCollection = terminalCollection;
            _callCollectiom = new List<Call>();
        }


        public void PhoneCall(Terminal tr)
        {
            foreach (Terminal terminal in _teminalCollection)
            {
                Call call = new Call();
                if (terminal.Equals(tr) && tr.Port.Condition == PortCondition.Connected)
                {
                    if (Connecting != null)
                    {
                        Connecting(this, new CallEventArgs("Connecting..."));
                        Thread.Sleep(3000);
                        tr.Port.Condition = PortCondition.Buzy;
                        if (Connected != null)
                        {
                            Connected(this, new CallEventArgs("Connected"));
                            System.Timers.Timer t = new System.Timers.Timer();
                            t.Start();
                            call.Start = DateTime.Now;

                            if (Disconnected != null)
                            {
                                Disconnected(this, new CallEventArgs("Disconnected"));
                            }

                            t.Stop();
                            call.Duration = DateTime.Now - call.Start;
                            _callCollectiom.Add(call);
                            Console.WriteLine("{0}, {1}",call.Start.ToString(), call.Duration.ToString());
                           
                        }
                    }
                }
            }            
            //foreach(var callIndo in _callCollectiom)
            //    Console.WriteLine("{0}, {1}", callIndo.Start.ToString(), callIndo.Duration.ToString());       
        }

        public void Add(Terminal terminal)
        {
            _teminalCollection.Add(terminal);
        }

        public void Add(Call callInfo)
        {
            _callCollectiom.Add(callInfo);
        }
    }
}
