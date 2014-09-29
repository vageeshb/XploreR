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
        public delegate void priceCutDelegate(Int32 p);
        public event priceCutDelegate priceCutEvent;
        [ThreadStatic]
        private Int32 oldPrice;
        [ThreadStatic]
        private Int32 basePrice;
        Random amount = new Random();
        private Int32 pricingModel()
        {
            int var = basePrice / 2;

            Int32 newprice = amount.Next(basePrice - var, basePrice + var);
            return newprice;
        }
        public void changePrice(Int32 newprice)
        {
            if (newprice < oldPrice)
            {
                if (priceCutEvent != null)
                    priceCutEvent(newprice);
            }
            oldPrice = newprice;

        }
        public void runHotelSupplier()
        {
            if (Thread.CurrentThread.Name == "Hilton")
            {
                basePrice = 500;
                oldPrice = 500;
            }

            else
            {
                basePrice = 100;
                oldPrice = 100;
            }

            for (Int32 i = 0; i < 10; i++)
            {
                Int32 newprice = pricingModel();
                Console.WriteLine("New Price is {0} for hotel {1}", newprice, Thread.CurrentThread.Name);
                changePrice(newprice);
            }
        }
        public void orderProcessing()
        {
            //BankReference.Service1Client bankProxy = new BankReference.Service1Client();
            //long cno = 1600160016001600;
            //if (bankProxy.ValidCard(cno))
            //    Console.WriteLine("Card Accepted");
            //else Console.WriteLine("Card Declined");
            Console.WriteLine("Processing order");
        }
        public Int32 getPrice()
        {
            return oldPrice;
        }

    }
}