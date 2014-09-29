using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSOD_Assignment2
{
    class BankService
    {
        public Boolean decryptCard(string encyptedNo)
        {
        encryptReference.ServiceClient decryptProxy = new encryptReference.ServiceClient();
            BankRef.Service1Client bankProxy = new BankRef.Service1Client();
         long cardNo = Convert.ToInt64( decryptProxy.Decrypt(encyptedNo));
         if (bankProxy.ValidCard(cardNo))
             return true;
         else return false;

        }
    }
}
