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
        public static void check(Int32 checkvalue)
        {
            Console.WriteLine("Travel Agency event triggered by {0}", Thread.CurrentThread.Name );
        }
    }
}
