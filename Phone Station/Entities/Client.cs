using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phone_Station.States;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Phone_Station.Entities
{
    public class Client : INotifyPropertyChanged
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        private double _balance;

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public double Balance
        {
            get
            {
                return _balance;
            }
            set
            {
                if (value != _balance && value > 0)
                {
                    _balance = value;
                    NotifyPropertyChanged();
                }
                                    
            }
        }

        public Client(string firstName, string lastName, double balance)
        {
            FirstName = firstName;
            LastName = lastName;
            Balance = balance;
        }

        public void AddMoney(double money)
        {
            Balance += money;
        }

        public void RemoveMoney(double money)
        {
            Balance -= money;
        }

        public void ShowBalance()
        {
            Console.WriteLine(Balance);
        }
    }
}
