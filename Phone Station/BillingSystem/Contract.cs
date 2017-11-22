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
        public string PhoneNumber { get; private set; }
        public Tariff Tariff { get; set; }
        public Client Client { get; set; }
        public Station Ats { get; set; }

        public Contract(Client client, string phoneNumber, Rate tariffType, Station ats)
        {
            Client = client;
            PhoneNumber = phoneNumber;
            Tariff = new Tariff(tariffType);
            Ats = ats;
        }

    }
}
