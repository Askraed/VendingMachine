using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
   public class Machine
    {
        private double credit;
        public int userWantedItem = 0;
        public int userWantedQuantity = 0;
        public int newCredit = 0;
        public Machine()
        {
            credit = 0;
        }
        public double GetCredit()
        {
            Console.WriteLine("Enter credit...");
            try
            {
                newCredit = Convert.ToInt16(Console.ReadLine());
                credit += newCredit;
            }
            catch (FormatException )
            {
                Console.WriteLine("Invalid amount of credit. Please insert a  multiple of 1. Press any key to reset.");
                Console.ReadKey();
                GetCredit();
            }
            return credit;
        }
        public void Refund()
        {
            Console.WriteLine("You have been refunded " + credit + "$.");
            credit = 0;
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
            Environment.Exit(0);
        }

        public List<VendingItem> Items = new List<VendingItem>();
        public void FillMachine()
        {
            Items.Add(new VendingItem("Pepsi", 2.85, 5));
            Items.Add(new VendingItem("Diet Pepsi", 3, 10));
            Items.Add(new VendingItem("Coke", 3, 5));
            Items.Add(new VendingItem("Diet Coke", 3.2, 7));
            Items.Add(new VendingItem("Kit-Kat", 0.95, 10));
            Items.Add(new VendingItem("Twix", 0.89, 20));
            Items.Add(new VendingItem("Lays Potato Chips", 1.15, 8));
            Items.Add(new VendingItem("Cheetos", 1.08, 6));
        }

        
    
        public void DisplayMachine()
        {
            Console.Clear();
            Console.WriteLine("*******************");
            Console.WriteLine("* Vending Machine *");
            Console.WriteLine("*******************");
            Console.WriteLine();
            Console.WriteLine("Your credit is "+ credit + "$");
            Console.WriteLine();
            for (int i = 0; i < Items.Count; i++)
            {
                if(Items[i].Quantity > 0)
                Console.WriteLine(i + " - " + Items[i].Item + " -> Price: " + Items[i].Price + "$ " + " Quantity available: " +  Items[i].Quantity);
            }
            Console.WriteLine(Items.Count + " - Insert credit.");
            Console.WriteLine((Items.Count+1) + " - Refund credit.");
            
            Console.WriteLine("Please select an item... ");
            try
            {
                 userWantedItem = Convert.ToInt16(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Wrong input, please try again. Press any key to reset.");
                Console.ReadKey();
                DisplayMachine();
            }
            if (userWantedItem == 8)
            {
                GetCredit();
                DisplayMachine();
            }
            else if (userWantedItem == 9)
                Refund();
            else if (userWantedItem > 9 || userWantedItem < 0)
            {
                Console.WriteLine("Selection does not exist. Press any key to refresh!");
                Console.ReadKey();
                DisplayMachine();
            }
            else if (userWantedItem < 9 && userWantedItem >= 0)
                Console.WriteLine();
            Console.WriteLine("Please insert the quantity... ");
            try
            {
                userWantedQuantity = Convert.ToInt16(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Wrong input, please try again. Press any key to reset.");
                Console.ReadKey();
                DisplayMachine();
            }
            Console.WriteLine();
            Console.WriteLine("Enter credit if needed otherwise enter 0.");
            GetCredit();

            if(credit >= Items[userWantedItem].Price*userWantedQuantity && userWantedQuantity <= Items[userWantedItem].Quantity )
            {
                Items[userWantedItem].Quantity -= userWantedQuantity;
                credit -= Items[userWantedItem].Price * userWantedQuantity;
                Console.WriteLine("For buying something else press 1, for change press 2...");
                int userOption = Convert.ToInt16(Console.ReadLine());
                if (userOption == 1)
                    DisplayMachine();
                else
                    Console.WriteLine("Thank you for purchasing! Your change is " + credit + "$");
            }
            else if (credit >= Items[userWantedItem].Price * userWantedQuantity && userWantedQuantity > Items[userWantedItem].Quantity)
            {
                if (Items[userWantedItem].Quantity > 0)
                {
                    Console.WriteLine("Not enough items in the vending machine. You will get only " + Items[userWantedItem].Quantity + " items. If you agree press 1 otherwise press 2");
                    int userOption = Convert.ToInt16(Console.ReadLine());
                    if (userOption == 1)
                    {
                        credit -= Items[userWantedItem].Price * Items[userWantedItem].Quantity; ;
                        Items[userWantedItem].Quantity = 0;
                        DisplayMachine();
                    }
                    else
                    {
                        Console.WriteLine("For buying something else press 1, for change press 2...");
                        userOption = Convert.ToInt16(Console.ReadLine());
                        if (userOption == 1)
                            DisplayMachine();
                        else
                            Console.WriteLine("Thank you for purchasing! Your change is " + credit+ "$");
                    }
                }
                else
                {
                    Console.WriteLine("Item out of inventory, please select another item...");
                    Console.ReadKey();
                    DisplayMachine();
                }
                
            }
            else if (credit < Items[userWantedItem].Price * userWantedQuantity && userWantedQuantity <= Items[userWantedItem].Quantity)
            {
                Console.WriteLine("Not enough credit. You will be redirected to the main screen...");
                Console.ReadKey();
                DisplayMachine();
            }
            else if (credit < Items[userWantedItem].Price * userWantedQuantity && userWantedQuantity > Items[userWantedItem].Quantity)
            {
                Console.WriteLine("Not enough credit. You will be redirected to the main screen...");
                Console.ReadKey();
                DisplayMachine();
            }
            Console.ReadKey();

        }
    }
    
}
