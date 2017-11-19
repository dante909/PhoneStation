using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Phone_Station.Classes
{
    public class Station
    {
        private List<Terminal> _teminalCollection;
        private List<Port> _portCollection;
        private List<Call> _callCollectiom;

        public event CallStateHandler Connecting;
        public event CallStateHandler Connected;

        public void PhoneCall(string number)
        {
            foreach (Terminal terminal in _teminalCollection)
            {
                Connecting(this, new CallEventArgs("Connecting..."));
                if (terminal.Equals(_teminalCollection) && terminal.Port.Condition == PortCondition.Connected)
                {
                    Connected(this, new CallEventArgs($"Connected"));
                }
            }
        }
    }
}
