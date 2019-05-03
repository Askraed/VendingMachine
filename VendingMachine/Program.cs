using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            Machine VendingMachine1 = new Machine();
            VendingMachine1.FillMachine();
            VendingMachine1.DisplayMachine();
            
        }
    }
}
