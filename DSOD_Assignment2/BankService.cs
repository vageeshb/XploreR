using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSOD_Assignment2
{
    class BankService
    {
        
        public Boolean isValid(string encyptedNo)
        {
            encryptReference.ServiceClient decryptProxy = new encryptReference.ServiceClient();
            long cardNo = Convert.ToInt64( decryptProxy.Decrypt(encyptedNo));
            return (Math.Floor(Math.Log10(cardNo) + 1) == 4);
        }
    }
  }

