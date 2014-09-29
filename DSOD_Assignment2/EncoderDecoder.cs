using System;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Security.Cryptography;

namespace DSOD_Assignment2
{
    class EncoderDecoder
    {
        // Encode the order
        public static string Encode(string order)
        {
            // Debugging
            Console.WriteLine("Sent the order : " + order);

            // Encrypt the order and send to the retailers
            return Encrypt(order, "ABCDEFGHIJKLMNOP");
        }

        // Decode the order
        public static string Decode(string order) 
        {
            // Debugging
            Console.WriteLine("Got the order : " + order);
            
            return Decrypt(order, "ABCDEFGHIJKLMNOP");
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
