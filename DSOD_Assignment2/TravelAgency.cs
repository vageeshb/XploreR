using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace DSOD_Assignment2
{
    class TravelAgency
    {
        static Random rng= new Random();
        int senderid, cardNo, receiverID, amount, price;
        string Order, EncodedOrder;
        OrderClass oc = new OrderClass();
        // Created static methods, so no need to create instances
        //EncoderDecoder ed = new EncoderDecoder();
        //MultiCellBuffer mcb = new MultiCellBuffer();
         public void TravelAgency(int senderID, int receiverID, int cardNo)
        {
            this.senderid = senderID;
            this.receiverID = receiverID;
            this.cardNo = cardNo;
        }
        public void AgencyFunc()//thread function of agency
        {
            HotelSupplier hs = new HotelSupplier();
            for(int i=0; i<10; i++)
            {
                Thread.Sleep(1000);
                int p = hs.getPrice();
                Console.WriteLine("The current price of a hotel room {0} is ${1}", Thread.CurrentThread.Name, p);
            }
        }

        public void placeorder(int price)//EventHandler Class
        {
            this.price = price;
            amount = rng.Next(5, 10);
            Order = oc.setorder(senderid, cardNo, receiverID, amount);
            EncodedOrder = EncoderDecoder.getEncodedOrder();
            //mcb.retrieveorder(EncodedOrder);
        }
    
    }
}
