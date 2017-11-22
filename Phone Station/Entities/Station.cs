using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Phone_Station.States;
using Phone_Station.Args;
using Phone_Station.Entities;


namespace Phone_Station.Entities
{
    public class Station
    {

        private IList<Port> _listPorts;
        private IList<string> _listPhoneNumbers;

        public Station()
        {
            _listPorts = new List<Port>();
            _listPhoneNumbers = new List<string>();
        }

        public Terminal GetNewTerminal(string portNumber)
        {
            _listPhoneNumbers.Add(portNumber);
            var newPort = new Port(this, portNumber);
            _listPorts.Add(newPort);
            var newTerminal = new Terminal(portNumber, newPort);
            return newTerminal;
        }

        public void PhoneCall(object sender, CallEventArgs e)
        {
            if (_listPhoneNumbers.Contains(e.TargetPhoneNumber) && e.TargetPhoneNumber != e.PhoneNumber)
            {
                var index = _listPhoneNumbers.IndexOf(e.TargetPhoneNumber);
                if (_listPorts[index].State == PortState.Connect)
                {
                    _listPorts[index].IncomingCall(e.PhoneNumber, e.TargetPhoneNumber);
                }
            }
            else if (!_listPhoneNumbers.Contains(e.TargetPhoneNumber))
            {
                Console.WriteLine("You have calling a non-existent number!");
            }
            else
            {
                Console.WriteLine("You have calling a your number!");
            }
        }

        public void ToAnswer(object sender, AnswerEventArgs e)
        {
            if (_listPhoneNumbers.Contains(e.PhoneNumber))
            {
                var index = _listPhoneNumbers.IndexOf(e.PhoneNumber);
                if (_listPorts[index].State == PortState.Connect)
                {
                    _listPorts[index].AnswerCall(e.TargetPhoneNumber, e.PhoneNumber, e.StateCall);
                }
            }
        }
    }
}
