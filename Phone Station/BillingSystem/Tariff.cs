using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phone_Station.States;

namespace Phone_Station.BillingSystem
{
    public class Tariff
    {
        public int CostOfMonth { get; set; }
        public int CostOfMinutes { get; set; }
        public Rate TariffType { get; private set; }
        public Tariff(Rate type)
        {
            TariffType = type;
            switch (TariffType)
            {
                case Rate.Absolute:
                    {
                        CostOfMonth = 10;
                        CostOfMinutes = 3;
                        break;
                    }
                case Rate.Ultra:
                    {
                        CostOfMonth = 20;
                        CostOfMinutes = 4;
                        break;
                    }
                default:
                    {
                        CostOfMonth = 0;
                        CostOfMinutes = 0;
                        break;
                    }
            }
        }
    }
}
