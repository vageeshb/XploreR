using System;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Security.Cryptography;

namespace DSOD_Assignment2
{
    class EncoderDecoder
    {
        public static string getEncodedOrder()
        {
            try
            {
                // Getting the order from the buffer
                string order = Program.mcb.getOneCell();

                // Debugging
                Console.WriteLine("Got the order : " + order);
                
                // Encrypt the order and send to the retailers
                return Encrypt(order, "ABCDEFGHIJKLMNOP");
            }
        }

        // Ecrypt the Order Object
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

        // Decrypt the Order Object
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
