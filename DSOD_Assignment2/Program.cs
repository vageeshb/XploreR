using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace DSOD_Assignment2
{

    //------------------------------------------
    // Each team member hass given equal contribution towards developing this project
    //------------------------------------------

    class Program
    {
        public static MultiCellBuffer mcb = new MultiCellBuffer(3);
        public static Thread[] hotelsuppliers = new Thread[3];
        public static TravelAgency[] agencies = new TravelAgency[5];

        static void Main(string[] args)
        {
            // Registering the event to its delegate
            HotelSupplier supplier = new HotelSupplier();
            TravelAgency agency = new TravelAgency();
            supplier.priceCutEvent += new HotelSupplier.priceCutDelegate(agency.priceCut);

            // Creating Hotel Supplier Threads
            for (int i = 0; i < 3; i++)
            {
                hotelsuppliers[i] = new Thread(new ThreadStart(supplier.runHotelSupplier));
                hotelsuppliers[i].Name = "HS_" + (i + 1).ToString();
                hotelsuppliers[i].Start();//starting threads
            }

            // Creating Travel agency instances
            for (int i = 0; i < 5; i++)
            {
                agencies[i] = new TravelAgency();
                agencies[i].Name = "TA_" + (i + 1);
            }
            
            // Waiting for the Hotel Supplier threads to finish their processing
            for (int i = 0; i < 3; i++)
            {
                hotelsuppliers[i].Join();
            }
            
            Console.WriteLine("Experiment Completed.\nPress any key to continue!");
            Console.ReadKey();
            
        }
    }
}
