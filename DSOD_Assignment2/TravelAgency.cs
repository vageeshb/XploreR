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
        static Random rng = new Random();
        private int senderId, cardNo, receiverId, amount, price;
        string EncodedOrder;
        // Created static methods, so no need to create instances
        //EncoderDecoder ed = new EncoderDecoder();
        //MultiCellBu\ffer mcb = new MultiCellBuffer();
         public TravelAgency(int s, int c)
        {
            senderId = s;
            cardNo = c;
        }
        public void AgencyFunc()//thread function of agency
        {
            Console.WriteLine("Started Travel Agency: {0}", Thread.CurrentThread.Name);
            //HotelSupplier hs = new HotelSupplier();
            //for(int i=0; i<10; i++)
            //{
            //    Thread.Sleep(1000);
            //    int p = hs.getPrice();
            //    //Console.WriteLine("The current price of a hotel room {0} is ${1}", Thread.CurrentThread.Name, p);
            //}
        }

        public void placeorder(int price, string receiverId)//EventHandler Class
        {
            this.price = price;
            amount = rng.Next(5, 10);
            OrderClass Order = new OrderClass(senderId, cardNo, Convert.ToInt32(receiverId), amount);
            EncodedOrder = EncoderDecoder.Encode(Order.getOrder());
            Program.mcb.setOneCell(EncodedOrder);
        }
    
    }
}
