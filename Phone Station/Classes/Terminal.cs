using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Station.Classes
{
    public class Terminal : IEquatable<Terminal>
    {
        public string PhoneNumber { get; private set; }
        public string PhoneModel { get; private set; }
        public Port Port { get; private set; }


        public Terminal(string phoneNumber, string phoneModel, Port port)
        {
            PhoneNumber = "8029" + port.PortNumber;
            PhoneModel = phoneModel;
            Port = port;
        }

        public Terminal(Port port)
        {
            PhoneNumber = "8029" + port.PortNumber;
            Port = port;
        }

        public Terminal()
        {

        }

        public bool Equals(Terminal other)
        {
            if (this.PhoneNumber == other.PhoneNumber)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
