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
        public string PortNumber { get; set; }

        public event EventHandler<CallEventArgs> IncomingCallEvent;
        public event EventHandler<AnswerEventArgs> PortAnswerEvent;

        public Port(Station station, string portNumber)
        {
            PortNumber = portNumber;        
            State = PortState.Disconnect;
            this.station = station;
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
                //terminal.EndCallEvent += station.ToAnswer;
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
                //terminal.EndCallEvent -= station.ToAnswer;
                Flag = false;
            }
            return false;
        }

        public void IncomingCall(string number, string incomingNumber)
        {
            IncomingCallEvent?.Invoke(this, new CallEventArgs(number, incomingNumber));
        }

        public void AnswerCall(string number, string outcomingNumber, CallState state)
        {
            PortAnswerEvent?.Invoke(this, new AnswerEventArgs(outcomingNumber, number, state));
        }

    }
}
