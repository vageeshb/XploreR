using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSOD_Assignment2
{
    class BankService
    {
        // Function to see if the credit card is valid
        public Boolean isValid(string encyptedNo)
        {
            encryptReference.ServiceClient decryptProxy = new encryptReference.ServiceClient();
            long cardNo = Convert.ToInt64( decryptProxy.Decrypt(encyptedNo));
            // Check to see if the Card No is 4 digits
            return (Math.Floor(Math.Log10(cardNo) + 1) == 4);
        }
    }
  }

