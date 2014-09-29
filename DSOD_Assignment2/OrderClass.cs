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
        // We can implement this in a constructor
        public string setorder(int senderid, int cardNo, int receiverID, int amount)//setting the order
        {
            this.senderid = senderid;
            this.cardNo = cardNo;
            this.receiverID = receiverID;
            this.amount = amount;

            // Why returning the object from 'setOrder' method?
            return "senderid" + senderid + "cardNo" + cardNo + "receiverID" + receiverID + "amount" + amount ;
        }

        // I need to fetch the order details in the buffer, so have to create a getOrder method
        public string getOrder()
        {
            return "senderId:" + senderid + ", cardNo:" + cardNo + ", receiverId:" + receiverID + ", Amount:" + amount;
        }
    }
}
