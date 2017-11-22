using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phone_Station.Args;
using Phone_Station.States;

namespace Phone_Station.Entities
{
    public class Terminal
    {

        public string PhoneNumber { get; set; }

        private Port _terminalPort;
        public delegate void CallEventHandler(object sender, CallEventArgs e);
        public delegate void AnswerEventHandler(object sender, AnswerEventArgs e);
        public event CallEventHandler CallEvent;
        public event AnswerEventHandler AnswerEvent;

        public Terminal(string phonenumber, Port port)
        {
            PhoneNumber = phonenumber;
            this._terminalPort = port;
        }

        public void Call(string targetNumber)
        {
            if (CallEvent != null)
                CallEvent(this, new CallEventArgs(PhoneNumber, targetNumber));
        }

        public void TakeIncomingCall(object sender, CallEventArgs e)
        {
            Console.WriteLine("Have incoming Call at number: {0} to terminal {1}", e.PhoneNumber, e.TargetPhoneNumber);
        }

        public void ConnectToPort()
        {
            _terminalPort.Connect(this);
        }

        public void AnswerToCall(string incoming, CallState state)
        {
            if (AnswerEvent != null)
            {
                AnswerEvent(this, new AnswerEventArgs(incoming, PhoneNumber, state));
            }
        }

        public void TakeAnswer(object sender, AnswerEventArgs e)
        {
            if (e.StateCall == CallState.Answered)
            {
                Console.WriteLine("Terminal with number: {0}, answered a call number: {1}", e.TargetPhoneNumber, e.PhoneNumber);
            }
            else
            {
                Console.WriteLine("Terminal with number: {0}, rejected a call number: {1}", e.TargetPhoneNumber, e.PhoneNumber);
            }
        }
    }
}
