using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phone_Station.States;
using Phone_Station.Args;

namespace Phone_Station.Entities
{
    public class Port
    {
        public PortState State { get; set; }
        private  Station station;
        public bool Flag { get; set; }

        public delegate void PortEventHandler(object sender, CallEventArgs e);
        public delegate void PortAnswerEventHandler(object sender, AnswerEventArgs e);
        public event PortEventHandler IncomingCallEvent;
        public event PortAnswerEventHandler PortAnswerEvent;

        public Port(Station station)
        {
            State = PortState.Disconnect;
            this.station = station;
        }
        public Port()
        {
            State = PortState.Disconnect;
        }

        public bool Connect(Terminal terminal)
        {
            if (State == PortState.Disconnect)
            {
                State = PortState.Connect;
                terminal.CallEvent += station.PhoneCall;
                IncomingCallEvent = terminal.TakeIncomingCall;
                terminal.AnswerEvent += station.ToAnswer;
                PortAnswerEvent = terminal.TakeAnswer;
                Flag = true;
            }
            return Flag;
        }

        public bool Disconnect(Terminal terminal)
        {
            if (State == PortState.Connect)
            {
                State = PortState.Disconnect;
                terminal.CallEvent -= station.PhoneCall;
                IncomingCallEvent -= terminal.TakeIncomingCall;
                Flag = false;
            }
            return false;
        }

        public void IncomingCall(string number, string incomingNumber)
        {
            if (IncomingCallEvent != null)
            {
                IncomingCallEvent(this, new CallEventArgs(number, incomingNumber));
            }
        }

        public void AnswerCall(string number, string outcomingNumber, CallState state)
        {
            if (PortAnswerEvent != null)
            {
                PortAnswerEvent(this, new AnswerEventArgs(outcomingNumber, number, state));
            }
        }

    }
}
