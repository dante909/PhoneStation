using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Phone_Station.States;
using Phone_Station.Args;
using Phone_Station.Entities;
using Phone_Station.Interfaces;
using Phone_Station.BillingSystem;


namespace Phone_Station.Entities
{
    public class Station : IStation<CallInfo>
    {

        private IList<Port> _listPorts;
        private IList<string> _listPhoneNumbers;
        private IList<CallInfo> _callList = new List<CallInfo>();
        private IList<Contract> _listContracts;

        public Station()
        {
            _listPorts = new List<Port>();
            _listPhoneNumbers = new List<string>();
            _listContracts = new List<Contract>();
        }

        public Terminal GetNewTerminal(Contract contract)
        {
            _listPhoneNumbers.Add(contract.PhoneNumber);
            var newPort = new Port(this, contract.PhoneNumber);
            _listPorts.Add(newPort);
            _listContracts.Add(contract);
            var newTerminal = new Terminal(contract.PhoneNumber, newPort);
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
                CallInfo info = null;
                CallInfo call = new CallInfo();
                System.Timers.Timer t = new System.Timers.Timer();
                int index = _listPhoneNumbers.IndexOf(e.PhoneNumber);
                if (_listPorts[index].State == PortState.Connect && e.StateCall == CallState.Answered)
                {
                    _listPorts[index].AnswerCall(e.TargetPhoneNumber, e.PhoneNumber, e.StateCall);
                    t.Start();
                    call.MyPhoneNumber = e.PhoneNumber;
                    call.TargetPhoneNumber = e.TargetPhoneNumber;
                    call.Start = DateTime.Now;
                    Console.ReadKey();
                    t.Stop();
                    call.Duration = DateTime.Now - call.Start;
                    var costOfTalk = _listContracts[index].Tariff.CostOfMinutes * call.Duration.TotalSeconds; //TotalSeconds
                    call.CostOfTalk = (int)costOfTalk;
                    info = new CallInfo(call.Start, call.Duration, call.MyPhoneNumber, call.TargetPhoneNumber, call.CostOfTalk);
                    _callList.Add(info);

                }

                else
                {
                    _listPorts[index].AnswerCall(e.TargetPhoneNumber, e.PhoneNumber, e.StateCall);
                }
            }
        }

        public IList<CallInfo> GetInfoList()
        {
            return _callList;
        }
    }
}
