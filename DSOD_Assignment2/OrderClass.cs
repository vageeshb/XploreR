﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSOD_Assignment2
{
    class OrderClass
    {
        int senderid, cardNo, receiverID, amount;
        public string setorder(int senderid, int cardNo, int receiverID, int amount)//setting the order
        {
            this.senderid = senderid;
            this.cardNo = cardNo;
            this.receiverID = receiverID;
            this.amount = amount;
            return "senderid" + senderid + "cardNo" + cardNo + "receiverID" + receiverID + "amount" + amount;
        }
    }
}
