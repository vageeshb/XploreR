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
        public static MultiCellBuffer mcb = new MultiCellBuffer(3);
        
        static void Main(string[] args)
        {
            HotelSupplier supplier = new HotelSupplier();

            Thread hotelSupplier = new Thread(new ThreadStart(supplier.runHotelSupplier));

            hotelSupplier.Start();         // Start one farmer thread

            TravelAgency agency = new TravelAgency(1, 3);

            supplier.priceCutEvent += new HotelSupplier.priceCutDelegate(agency.placeorder);

            Thread[] agencies = new Thread[3];

            for (int i = 0; i < 3; i++)  // N =  3 here
            {   // Start N retailer threads

                agencies[i] = new Thread(new ThreadStart(agency.AgencyFunc));

                agencies[i].Name = (i + 1).ToString();

                agencies[i].Start();

            }

            for (int i = 0; i < 3; i++)  // N =  3 here
            {
                agencies[i].Join();
            }

            hotelSupplier.Join();
            
            Console.ReadKey();
            Console.WriteLine("Press any key to continue!");


        }
    }
}
