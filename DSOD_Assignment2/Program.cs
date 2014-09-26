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
        static void Main(string[] args)
        {
            hs.priceCutEvent += new HotelSupplier.priceCutDelegate(TravelAgency.check);


            Thread hotelHilton = new Thread(new ThreadStart(hs.runHotelSupplier));
            Thread hotelHoliday = new Thread(new ThreadStart(hs.runHotelSupplier));
            hotelHoliday.Name = "Holiday Inn";
            hotelHilton.Name = "Hilton";
            hotelHoliday.Start();
            hotelHilton.Start();
            hotelHilton.Join();
            hotelHoliday.Join();

            Console.WriteLine("Done");
            Console.ReadKey();
        }
    }
}
