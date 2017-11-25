using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phone_Station.BillingSystem;

namespace Phone_Station.Interfaces
{
    public interface ISort<T,M>
    {
        IList<T> SortByDateOfCall(M inst);
        IList<T> SortByCost(M inst);
        IList<T> SortByNumber(M inst);
    }
}
