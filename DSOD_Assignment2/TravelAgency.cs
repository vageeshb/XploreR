using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSOD_Assignment2
{
    class TravelAgency
    {
        static Random rng= new Random();
        int senderid, cardNo, receiverID, amount;
        string Order, EncodedOrder;
        OrderClass oc = new OrderClass();
        EnCoderDecoder ed = new EnCoderDecoder();
        MultiCellBuffer mcb = new MultiCellBuffer();
        public void TravelAgency(int senderID, int receiverID, int cardNo)
        {
            amount=rng.Next(5,10);
            
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

        public void placeorder()//EventHandler Class
        {
            Order= oc.setorder(senderid, cardNo, receiverID, amount);
            setencodedorder(Order);
            EncodedOrder = ed.getencodedorder();
            mcb.retrieveorder(EncodedOrder);
        }
    
    }
}
