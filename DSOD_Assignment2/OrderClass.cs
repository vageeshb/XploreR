using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSOD_Assignment2
{
    class OrderClass
    {
        string senderid, receiverID;
        int amount;
        long cardNo;
        DateTime timeOfPlaced;
        int price;

        // Constructor to set instance variables
        public OrderClass(string senderid, long cardNo, string receiverID, int amount, DateTime timeOfPlaced, int price)
        {
            this.senderid = senderid;
            this.cardNo = cardNo;
            this.receiverID = receiverID;
            this.amount = amount;
            this.timeOfPlaced = timeOfPlaced;
            this.price = price;
        }

        // Utility function to return order in string format
        public string getOrder()
        {
            return senderid + "," + cardNo + "," + receiverID + "," + amount + "," + timeOfPlaced+"," + price;
        }
    }
}
