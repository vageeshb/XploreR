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
        Thread[] agencies = new Thread[3];
        private int senderId, cardNo, amount, price;
        string receiverId;
        string EncodedOrder;
        // Created static methods, so no need to create instances
        //EncoderDecoder ed = new EncoderDecoder();
        //MultiCellBu\ffer mcb = new MultiCellBuffer();
         public TravelAgency(int s, int c)
        {
            senderId = s;
            cardNo = c;
        }
        public void priceCut(int price, string receiverId)//eventhandler
        {
            this.price = price;
            this.receiverId = receiverId;
            for (int i = 0; i < 5; i++)
            {
                agencies[i] = new Thread(() => placeorder(price, receiverId));

                agencies[i].Name = (i + 1).ToString();

                agencies[i].Start();

            }
        }

            

        public void placeorder(int price, string receiverId)
        {
            this.price = price;
            amount = rng.Next(5, 10);
            DateTime currentDate = Convert.ToDateTime(DateTime.Now.ToString("dd-MMM-yyyy"));
            Console.WriteLine("Order placed at : {0}", currentDate);
            OrderClass Order = new OrderClass(senderId, cardNo, Convert.ToInt32(receiverId), amount, currentDate);
            EncodedOrder = EncoderDecoder.Encode(Order.getOrder());
            Program.mcb.setOneCell(EncodedOrder);
        }
    
    }
}
