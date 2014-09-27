﻿using System;
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
        int senderid, cardNo, receiverID, amount;
        string Order, EncodedOrder;
        static int s;
        OrderClass oc = new OrderClass();



        public static void placeorder(Int32 a)//EventHandler Class
        {
            Console.WriteLine("Event Called");
        }
        public void AgencyFunc()//thread function of agency
        {
            HotelSupplier hs = new HotelSupplier();
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(1000);
                
            }
        }

        
    }
}
