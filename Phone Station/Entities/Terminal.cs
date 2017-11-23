using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
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
            //условие да нет AnswerTo
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
            if (AnswerEvent != null)
            {
                AnswerEvent(this, new AnswerEventArgs(incoming, PhoneNumber, state));
            }
        }

        public void TakeAnswer(object sender, AnswerEventArgs e)
        {
            CallInfo call = new CallInfo();
            System.Timers.Timer t = new System.Timers.Timer();
            if (e.StateCall == CallState.Answered)
            {
                Console.WriteLine("Terminal with number: {0}, answered a call number: {1}", e.TargetPhoneNumber, e.PhoneNumber);
                t.Start();
                call.Start = DateTime.Now;
                Console.ReadKey();
                t.Stop();
                call.Duration = DateTime.Now - call.Start;
                Console.WriteLine("{0}, {1}", call.Start.ToString(), call.Duration.ToString());
            }
            else
            {
                Console.WriteLine("Terminal with number: {0}, rejected a call number: {1}", e.TargetPhoneNumber, e.PhoneNumber);
            }
        }
    }
}
