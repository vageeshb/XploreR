using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSOD_Assignment2
{
    class Program
    {
        public static MultiCellBuffer mcb = new MultiCellBuffer(3);
        public static TravelAgency agency1 = new TravelAgency();
        public static TravelAgency agency2 = new TravelAgency();
        public static TravelAgency agency3 = new TravelAgency();
        public static TravelAgency agency4 = new TravelAgency();
        public static TravelAgency agency5 = new TravelAgency();
        
        static void Main(string[] args)
        {
            ChickenFarm chicken = new ChickenFarm();

            Thread farmer = new Thread(new ThreadStart(chicken.farmerFunc));

            farmer.Start();         // Start one farmer thread

            Retailer chickenstore = new Retailer();

            ChickenFarm.priceCut += new priceCutEvent(chickenstore.chickenOnSale);

            Thread[] retailers = new Thread[3];

            for (int i = 0; i < 3; i++)  // N =  3 here
            {   // Start N retailer threads

                retailers[i] = new Thread(new ThreadStart(chickenstore.retailerFunc));

                retailers[i].Name = (i + 1).ToString();

                retailers[i].Start();

            }

        }
    }
}
