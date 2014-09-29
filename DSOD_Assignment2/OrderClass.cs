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
        public OrderClass(int senderid, int cardNo, int receiverID, int amount)
        {
            this.senderid = senderid;
            this.cardNo = cardNo;
            this.receiverID = receiverID;
            this.amount = amount;
        }

        public string getOrder()
        {
            return "senderId:" + senderid + ", cardNo:" + cardNo + ", receiverId:" + receiverID + ", Amount:" + amount;
        }
    }
}
