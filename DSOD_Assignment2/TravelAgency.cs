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
        Program pg = new Program();
        Thread[] agencies = new Thread[5];
        private int senderId,amount, price;
        int receiverId;
        string EncodedOrder;
        // Created static methods, so no need to create instances
        //EncoderDecoder ed = new EncoderDecoder();
        //MultiCellBu\ffer mcb = new MultiCellBuffer();
        /* public TravelAgency(int c)
        {
           
            cardNo = c;
        }*/
         public void priceCut(int price, int receiverId)//eventhandler
         {
             lock (this)
             {
                 this.price = price;
                 this.receiverId = receiverId;
                 Int64 cardNo = 1001;
                 for (int i = 0; i < 5; i++)
                 {
                     agencies[i] = new Thread(() => placeorder(price, receiverId, cardNo));

                     agencies[i].Name = (i + 1).ToString();

                     agencies[i].Start();

                 }

             }
         }

        public void placeorder(int price, int receiverId, Int64 cardNo)
        {
            Console.WriteLine("Travel Agency {0} placing the order", Thread.CurrentThread.Name);
            this.price = price;
            amount = rng.Next(5, 10);
            senderId = Convert.ToInt32(Thread.CurrentThread.Name);
           // DateTime currentDate = Convert.ToDateTime(DateTime.Now.ToString("dd-MMM-yyyy"));
            DateTime currentDate = DateTime.Now;
            Console.WriteLine("Order placed at : {0}", currentDate);
            OrderClass Order = new OrderClass(senderId, cardNo, Convert.ToInt32(receiverId), amount, currentDate);
            EncodedOrder = EncoderDecoder.Encode(Order.getOrder());
            Program.mcb.setOneCell(EncodedOrder);
        }
    
    }
}
