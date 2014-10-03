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
        public static Thread[] hotelsuppliers = new Thread[3];
        public static Thread[] agencies = new Thread[5];

        static void Main(string[] args)
        {
            HotelSupplier supplier = new HotelSupplier();
            
            for (int i = 0; i < 3; i++)
            {
                hotelsuppliers[i] = new Thread(new ThreadStart(supplier.runHotelSupplier));

                hotelsuppliers[i].Name = "HS_" + (i + 1).ToString();

                hotelsuppliers[i].Start();

            }

            TravelAgency agency = new TravelAgency();
            
            supplier.priceCutEvent += new HotelSupplier.priceCutDelegate(agency.priceCut);
            MultiCellBuffer.orderPlacedEvent += new MultiCellBuffer.orderPlaced(supplier.newOrderPlaced);
            
            for (int i = 0; i < 3; i++)
            {
                hotelsuppliers[i].Join();
            }

            //for (int i = 0; i < 5; i++)
            //{
            //    agencies[i].Join();
            //}

            
            Console.WriteLine("Experiment Completed.\nPress any key to continue!");
            Console.ReadKey();
            
        }
    }
}
