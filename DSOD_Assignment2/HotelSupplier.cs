using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace DSOD_Assignment2
{
    
    class HotelSupplier
    {
        public delegate void priceCutDelegate(Int32 p, string threadName);
        public  event priceCutDelegate priceCutEvent;
        private  Int32 oldPrice = 100;
        Random amount = new Random();
        private Int32 pricingModel()
        {
            Int32 newprice = amount.Next(50, 150);
            return newprice;
        }
        public void changePrice(Int32 newprice)
        {
            if (newprice < oldPrice)
            {
                if (priceCutEvent != null)
                    priceCutEvent(newprice, Thread.CurrentThread.Name);
            }
            oldPrice = newprice;
                
        }
        public void runHotelSupplier()
        {
            for (Int32 i = 0; i < 10; i++)
            {
                Int32 newprice = pricingModel();
                Console.WriteLine("Hotel {0}: Old Price is {1}, New Price is {2}", Thread.CurrentThread.Name, oldPrice, newprice );
                changePrice(newprice);
            }
        }
        public void orderProcessing()
        {
            BankReference.Service1Client bankProxy = new BankReference.Service1Client();
            long cno = 1600160016001600;
            if (bankProxy.ValidCard(cno))
                Console.WriteLine("Card Accepted");
            else Console.WriteLine("Card Declined");
        }
        public Int32 getPrice()
        {
            return oldPrice;
        }

    }
}
