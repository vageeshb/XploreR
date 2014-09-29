using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSOD_Assignment2
{
    class OrderClass
    {
        int senderid, cardNo, receiverID, amount;
        DateTime timeOfPlaced;
        public OrderClass(int senderid, int cardNo, int receiverID, int amount, DateTime timeOfPlaced)
        {
            this.senderid = senderid;
            this.cardNo = cardNo;
            this.receiverID = receiverID;
            this.amount = amount;
            this.timeOfPlaced = timeOfPlaced;
        }

        public string getOrder()
        {
            return senderid + "," + cardNo + "," + receiverID + "," + amount + "," + timeOfPlaced;
        }
    }
}
