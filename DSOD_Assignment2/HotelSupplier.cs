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
        public delegate void priceCutDelegate(Int32 p, int id);
        public event priceCutDelegate priceCutEvent;
        private Int32 oldPrice = 100;

        Random amount = new Random();
        private Int32 pricingModel()
        {
            Int32 newprice = amount.Next(50, 100);
            return newprice;
        }
        public void changePrice(Int32 newprice)
        {
            if (newprice < oldPrice)
            {
                if (priceCutEvent != null)
                    priceCutEvent(newprice, Thread.CurrentThread.ManagedThreadId);
            }
            oldPrice = newprice;

        }
        public void runHotelSupplier()
        {
            lock (this)
            {
                for (Int32 i = 0; i < 10; i++)
                {
                    Int32 newprice = pricingModel();
                    Console.WriteLine("New Price is {0} for hotel {1}", newprice, Thread.CurrentThread.Name);
                    changePrice(newprice);
                }
            }
        }

        public Int32 getPrice()
        {
            return oldPrice;
        }
        public void newOrderPlaced(int index)
        {

            String encodedOrder = Program.mcb.getOneCell(index);
            string[] parts = EncoderDecoder.Decode(encodedOrder).Split(',');
            BankService bs = new BankService();
            // encryptReference.ServiceClient encryptProxy = new encryptReference.ServiceClient();
            encryptReference.ServiceClient encryptProxy = new encryptReference.ServiceClient();
            if (Thread.CurrentThread.Name == parts[2])
            {
                //Program.mcb.deleteCell(cell);
                if (bs.decryptCard(encryptProxy.Encrypt(parts[1])))
                {
                    DateTime completeDate = Convert.ToDateTime(DateTime.Now.ToString("dd-MMM-yyyy"));
                    Console.WriteLine("Order placed at : {0}", completeDate);
                    Int32 orderProcessingTime = Convert.ToInt32(completeDate) - Convert.ToInt32(parts[4]);
                    Console.WriteLine("Order Confirmed and time taken is : {0}", orderProcessingTime);
                }
                else Console.WriteLine("Order cannot be completed");
            }

        }

    }
}
