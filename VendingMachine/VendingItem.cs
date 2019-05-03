using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class VendingItem
    {
        protected string item;
        protected double price;
        protected int quantity;
        public VendingItem (string item, double price, int quantity)
        {
            this.item = item;
            this.price = price;
            this.quantity = quantity;
        }
        public void ReduceInventory()
        {
            quantity--;
        }
        public string Item
        {
            get => item;
            set => item = value;
        }
        public double Price
        {
            get => price;
            set => price = value;
        }
        public int Quantity
        {
            get => quantity;
            set => quantity = value;
        }



    }
}
