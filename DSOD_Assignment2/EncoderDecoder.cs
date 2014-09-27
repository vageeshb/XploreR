using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace DSOD_Assignment2
{
    class EncoderDecoder
    {
        public delegate void encodeDelegate();
        public static event encodeDelegate encoded;
        string Order;

        // EncorderDecorder Thread will run  10 times 
        // So, each thread will place 5 orders
        public static void encorderDecorderFunc()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("waiting for orders");
                Thread.Sleep(1000);
            }
        }

        //This method will be called when a retailer thread place an order
        public static void getencodedorder(String Order)
        {
            this.Order = Order;
            Monitor.Enter(Program.bo);
            try
            {
                 Console.WriteLine("Encoding the order : " + Order);
                // Encript the order and send the order to two retailers r1 and r2


                  int result=Program.r1.getEncoded(Encrypt(Order, "ABCDEFGHIJKLMNOP"));
                //Program.r2.getEncoded(Encrypt(Order, "ABCDEFGHIJKLMNOP"));
                 return result;
            }
            finally { Monitor.Exit(Program.bo); }
        }
        public static string Encrypt(String input, String key)
        {
            byte[] inputArray = UTF8Encoding.UTF8.GetBytes(input);
            String result = "";
            try
            {
                TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
                tripleDES.Key = UTF8Encoding.UTF8.GetBytes(key);
                tripleDES.Mode = CipherMode.ECB;
                tripleDES.Padding = PaddingMode.PKCS7;
                ICryptoTransform cTransform = tripleDES.CreateEncryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
                tripleDES.Clear();
                result = Convert.ToBase64String(resultArray, 0, resultArray.Length);
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.ToString());
            }
            return result;
        }

        public static String Decrypt(String input, string key)
        {
            Byte[] inputArray = Convert.FromBase64String(input);
            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
            tripleDES.Key = UTF8Encoding.UTF8.GetBytes(key);
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tripleDES.CreateDecryptor();
            Byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDES.Clear();
            return UTF8Encoding.UTF8.GetString(resultArray);
        }
    }
}
