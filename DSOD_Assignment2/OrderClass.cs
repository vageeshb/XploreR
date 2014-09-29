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
        DateTime CurrentDate;
        public OrderClass(int senderid, int cardNo, int receiverID, int amount, DateTime CurrentDate)
        {
            this.senderid = senderid;
            this.cardNo = cardNo;
            this.receiverID = receiverID;
            this.amount = amount;
            this.CurrentDate = CurrentDate;
        }

        public string getOrder()
        {
            return "senderId:" + senderid + ", cardNo:" + cardNo + ", receiverId:" + receiverID + ", Amount:" + amount+ "orderplaceTime:" + CurrentDate;
        }
    }
}
