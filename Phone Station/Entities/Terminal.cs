using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Phone_Station.Args;
using Phone_Station.States;
using Phone_Station.Interfaces;

namespace Phone_Station.Entities
{
    public class Terminal
    {

        public string PhoneNumber { get; private set; }
        private Port _terminalPort;
        public event EventHandler<CallEventArgs> CallEvent;
        public event EventHandler<AnswerEventArgs> AnswerEvent;

        public Terminal(string phonenumber, Port port)
        {
            PhoneNumber = phonenumber;
            this._terminalPort = port;
        }

        public Terminal()
        {

        }

        public void Call(string targetNumber)
        {
            CallEvent?.Invoke(this, new CallEventArgs(PhoneNumber, targetNumber));
        }

        public void TakeIncomingCall(object sender, CallEventArgs e)
        {
            bool flag = true;
            Console.WriteLine("Have incoming Call at number: {0} to terminal {1}", e.PhoneNumber, e.TargetPhoneNumber);
            while (flag == true)
            {
                Console.WriteLine("Answer? Y/N");
                char k = Console.ReadKey().KeyChar;
                if (k == 'Y' || k == 'y')
                {
                    flag = false;
                    Console.WriteLine();
                    AnswerToCall(e.PhoneNumber, CallState.Answered);
                }
                else if (k == 'N' || k == 'n')
                {
                    flag = false;
                    Console.WriteLine();
                    AnswerToCall(e.PhoneNumber, CallState.Rejected);
                }
                else
                {
                    flag = true;
                    Console.WriteLine();
                }
            }
        }

        public void ConnectToPort()
        {
            _terminalPort.Connect(this);
        }

        public void AnswerToCall(string incoming, CallState state)
        {
            AnswerEvent?.Invoke(this, new AnswerEventArgs(incoming, PhoneNumber, state));
        }

        public void TakeAnswer(object sender, AnswerEventArgs e)
        {
            if (e.StateCall == CallState.Answered)
            {
                Console.WriteLine("Terminal with number: {0}, answered a call number: {1}",
                    e.TargetPhoneNumber, e.PhoneNumber);
            }

            else if(e.StateCall == CallState.Rejected)
            {
                Console.WriteLine("Terminal with number: {0}, rejected a call number: {1}", e.TargetPhoneNumber, e.PhoneNumber);
            }
        }
    }
}
