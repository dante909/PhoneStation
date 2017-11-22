using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phone_Station.Entities;
using Phone_Station.States;
using Phone_Station.BillingSystem;

namespace Phone_Station.BillingSystem
{
    public class Contract
    {
        public string Name { get; private set; }
        public string PhoneNumber { get; private set; }
        public Tariff Tariff { get; set; }
        public Station Ats { get; set; }

        public Contract(string name, string phoneNumber, States.Rate tariffType, Station ats)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            Tariff = new Tariff(tariffType);
            Ats = ats;
        }

        public Terminal RegisterContract()
        {
            return Ats.GetNewTerminal(PhoneNumber);
        }
    }
}
