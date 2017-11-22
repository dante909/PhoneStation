using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phone_Station.States;

namespace Phone_Station.Entities
{
    public class Client
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public Client(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
