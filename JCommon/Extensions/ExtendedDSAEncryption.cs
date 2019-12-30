using System;
using System.Security.Cryptography;
using System.Text;

namespace JCommon.Extensions
{
    public static class ExtendedDSAEncryption
    {
        public static byte[] key = new byte[8] { 1, 2, 3, 4, 5, 6, 7, 8 };
        public static byte[] iv = new byte[8] { 1, 2, 3, 4, 5, 6, 7, 8 };

        public static string StringToDSA(this string text)
        {
            using (SymmetricAlgorithm algorithm = DES.Create())
            {
                ICryptoTransform transform = algorithm.CreateEncryptor(key, iv);
                byte[] inputbuffer = Encoding.Unicode.GetBytes(text);
                byte[] outputBuffer = transform.TransformFinalBlock(inputbuffer, 0, inputbuffer.Length);
                return Convert.ToBase64String(outputBuffer);
            }
        }

        public static string DSAToString(this string text)
        {
            using (SymmetricAlgorithm algorithm = DES.Create())
            {
                ICryptoTransform transform = algorithm.CreateDecryptor(key, iv);
                byte[] inputbuffer = Convert.FromBase64String(text);
                byte[] outputBuffer = transform.TransformFinalBlock(inputbuffer, 0, inputbuffer.Length);
                return Encoding.Unicode.GetString(outputBuffer);
            }
        }

        public static string ToBase64(this string text)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(text));
        }

        public static string FromBase64(this string text)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(text));
        }

        public static byte[] BytesToDSA(this byte[] inputbuffer)
        {
            using (SymmetricAlgorithm algorithm = DES.Create())
            {
                ICryptoTransform transform = algorithm.CreateEncryptor(key, iv);
                return transform.TransformFinalBlock(inputbuffer, 0, inputbuffer.Length);
            }
        }

        public static byte[] DSAToBytes(this byte[] inputbuffer)
        {
            using (SymmetricAlgorithm algorithm = DES.Create())
            {
                ICryptoTransform transform = algorithm.CreateDecryptor(key, iv);
                return transform.TransformFinalBlock(inputbuffer, 0, inputbuffer.Length);
            }
        }
    }

}
