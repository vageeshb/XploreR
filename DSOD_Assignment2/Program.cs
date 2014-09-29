using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace DSOD_Assignment2
{
    class Program
    {
        public static HotelSupplier hs = new HotelSupplier();
        public static TravelAgency[] ta = new TravelAgency[5];
        static void Main(string[] args)
        {
            hs.orderProcessing();
           /* hs.priceCutEvent += new HotelSupplier.priceCutDelegate(TravelAgency.placeorder);
                          
            Thread hotelHilton = new Thread(new ThreadStart(hs.runHotelSupplier));
            Thread hotelHoliday = new Thread(new ThreadStart(hs.runHotelSupplier));
            hotelHoliday.Name = "Holiday Inn";
            hotelHilton.Name = "Hilton";
            
            Thread[] travelAgency = new Thread[5];
            for (int i = 0; i < 5; i++)
            {
                ta[i] = new TravelAgency();
                travelAgency[i] = new Thread(new ThreadStart(ta[i].AgencyFunc));
                travelAgency[i].Name = (i + 1).ToString();
                travelAgency[i].Start();
            }
            hotelHoliday.Start();
            hotelHilton.Start();
            for (int i = 0; i < 5; i++)
                travelAgency[i].Join();
            hotelHilton.Join();
            hotelHoliday.Join();

            Console.WriteLine("Done"); */
            Console.ReadKey();
        }
    }
}
