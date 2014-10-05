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
        // Class variables
        static Random rng = new Random();
        Program pg = new Program();
        private int amount, price;
        public string Name;
        string senderId, receiverId;
        string EncodedOrder;
        
        // Event handler function
        public void priceCut(int price, string receiverId)
        {
            Console.WriteLine("Price Cut event for Hotel Supplier : {0}", receiverId);
            this.price = price;
            this.receiverId = receiverId;
            Int64 cardNo = 1001;
            for (int i = 0; i < 5; i++)
            {
                // Creating travel agency threads and starting them
                Thread agency = new Thread(() => placeorder(price, receiverId, cardNo++));
                // Assigning Agency object names to threads
                agency.Name = Program.agencies[i].Name;
                agency.Start();
            }
         }

        // Travel Agency thread function
        public void placeorder(int price, string receiverId, long cardNo)
        {
            this.price = price;
            amount = rng.Next(5, 10);
            senderId = Thread.CurrentThread.Name;
            DateTime currentDate = DateTime.Now;
            Console.WriteLine("Order placed by Travel Agency {0} at : {1}", Thread.CurrentThread.Name, currentDate);
            
            // Generating order object
            OrderClass Order = new OrderClass(senderId, cardNo, receiverId, amount, currentDate,price);
            
            // Encoding order object
            EncodedOrder = EncoderDecoder.Encode(Order.getOrder());
            
            // Setting the MCB Cell
            Program.mcb.setOneCell(EncodedOrder);
        }

        // Handler function to print order confirmation
        public static void printReceipt(String receipt, String parts)
        {
            //Print receipt
            DateTime completeDate = DateTime.Now;
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine(receipt);

            //Calculating the time to complete the order
            TimeSpan orderProcessingTime = completeDate.Subtract(Convert.ToDateTime(parts));
            Console.WriteLine("Total time taken is : {0}", orderProcessingTime);
            Console.WriteLine("----------------------------------------------------");
        }
    
    }
}
