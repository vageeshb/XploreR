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
        public delegate void priceCutDelegate(Int32 p, String name);
        public  event priceCutDelegate priceCutEvent;
        private  Int32 oldPrice = 100 ;
        
        Random amount = new Random();
        private Int32 pricingModel()
        {
            Int32 newprice = amount.Next(50,100);
            return newprice;
        }
        public void changePrice(Int32 newprice)
        {
            if (newprice < oldPrice)
            {
                if (priceCutEvent != null)
                    priceCutEvent(newprice,Thread.CurrentThread.Name );
            }
            oldPrice = newprice;
                
        }
        public void runHotelSupplier()
        {
                          
            for (Int32 i = 0; i < 10; i++)
            {
                Int32 newprice = pricingModel();
                Console.WriteLine("New Price is {0} for hotel {1}", newprice, Thread.CurrentThread.Name );
                changePrice(newprice,Thread.CurrentThread.);
            }
        }
        public void orderProcessing()
        {
           BankService bs = new BankService();
           // encryptReference.ServiceClient encryptProxy = new encryptReference.ServiceClient();
         encryptReference.ServiceClient encryptProxy = new encryptReference.ServiceClient();
            long cardNo = 1600160016001600;
            bs.decryptCard(encryptProxy.Encrypt(cardNo.ToString()));
        }
        public Int32 getPrice()
        {
            return oldPrice;
        }
        public void orderProcessed(String order)
        {

        }

    }
}
