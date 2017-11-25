using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phone_Station.BillingSystem;
using Phone_Station.States;

namespace Phone_Station.Interfaces
{
    public interface ISort<T, M>
    {
        IList<T> Sort(M inst, TypeOfSorting type);
    }
}
