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
            Thread[] hotelsuppliers = new Thread[3];
            for (int i = 0; i < 3; i++)
            {
                hotelsuppliers[i] = new Thread(new ThreadStart(supplier.runHotelSupplier));

                hotelsuppliers[i].Name = (i + 1).ToString();

                hotelsuppliers[i].Start();

            }

            //Thread hotelSupplier = new Thread(new ThreadStart(supplier.runHotelSupplier));

            //hotelSupplier.Start();         // Start one HotelSupplier thread

            TravelAgency agency = new TravelAgency();

            supplier.priceCutEvent += new HotelSupplier.priceCutDelegate(agency.priceCut);
            MultiCellBuffer.orderPlacedEvent += new MultiCellBuffer.orderPlaced(supplier.newOrderPlaced);
            for (int i = 0; i < 3; i++)
            {
                hotelsuppliers[i].Join();
            }

            Console.ReadKey();
            Console.WriteLine("Press any key to continue!");


        }
    }
}
