using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Station.Classes
{
    static void Display(object sender, CallEventArgs e)
    {
        Console.WriteLine(e.Message);
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
