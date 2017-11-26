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
        private DateTime LastTariffUpdate;

        public Contract(Client client, string portNumber, Rate tariffType)
        {         
            Client = client;
            PhoneNumber = "8029" + portNumber; //номер атс + номер порта
            Tariff = new Tariff(tariffType);
        }

        public bool ChangeTariff(Rate tariffType)
        {
            if (DateTime.Now.AddMonths(-1) >= LastTariffUpdate)
            {
                LastTariffUpdate = DateTime.Now;
                Tariff = new Tariff(tariffType);
                return true;
            }
            return false;
        }

    }
}
