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
        public delegate void priceCutDelegate(Int32 p, string id);
        // Event for price cut
        public event priceCutDelegate priceCutEvent;
        private Int32 oldPrice = 100;
        private static int priceCutCounter = 0;
        Random amount = new Random();
        private static string order;
        private Int32 pricingModel()
        {
            Int32 newprice = amount.Next(50, 100);
            return newprice;
        }

        // Function to generate new price
        public void changePrice(Int32 newprice)
        {
            lock (this)
            {
                if (newprice < oldPrice)
                {
                    if (priceCutEvent != null)
                    {
                        priceCutCounter++;
                        priceCutEvent(newprice, Thread.CurrentThread.Name);
                        
                        // Intentional pause to make the threads run in different time slices
                        Thread.Sleep(new Random().Next(1, 10) * 100);
                    }
                }
                oldPrice = newprice;
            }

        }

        // Hotel Supplier entry function
        public void runHotelSupplier()
        {
            //To ensure that there are total 10 price cuts.
            while(priceCutCounter < 10)
            {
                Int32 newprice = pricingModel();
                Console.WriteLine("New Price is ${0} for hotel {1}.", newprice, Thread.CurrentThread.Name);
                changePrice(newprice);
                
                // Function to see if new order has been placed
                getOrder();
            }
        }

        // Getter function for price
        public Int32 getPrice()
        {
            return oldPrice;
        }

        // Function to see if new order has been placed
        public void getOrder()
        {
            lock(this)
            {
                order = EncoderDecoder.Decode(Program.mcb.getOneCell());
                string[] parts = order.Split(',');
                Program.mcb.deleteCell();
                // Creating an order processing thread
                Thread processOrder = new Thread(new ThreadStart(this.processOrder));
                processOrder.Start();
                processOrder.Join();
            }
        }

        // Function to process order
        public void processOrder()
        {
            lock (order)
            {
                    String receipt;
                    string[] parts = order.Split(',');

                    // Creating a bank service proxy
                    BankService bs = new BankService();
                    encryptReference.ServiceClient encryptProxy = new encryptReference.ServiceClient();
                    string cardNo = parts[1];
            
                    // Calling Bank service to see if valid credit card
                    if (bs.isValid(encryptProxy.Encrypt(cardNo)))
                    {
                        
                        int bill = Convert.ToInt32(parts[5]) * Convert.ToInt32(parts[3]);
                        // Calculate tax
                        double tax = 0.10 * Convert.ToDouble(bill);
                        double totalAmount = bill + tax;
                        String totAmt =Convert.ToString( totalAmount);
                        receipt = "Amount including tax is " + totAmt;
                    }
                    else
                    {
                        receipt = "Invalid Credit Card provided! Order cannot be completed!";
                    }

                    // Callback to print receipt
                    TravelAgency.printReceipt(receipt,parts[4]);
                }
            }
        }
}
