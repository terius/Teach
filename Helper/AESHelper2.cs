using System;
using System.Security.Cryptography;
using System.Text;
namespace Helpers
{
    public class AESHelper2
    {
        //public static void Main()
        //{
        //    //密码
        //    string password = "1234567890123456";
        //    //加密初始化向量
        //    string iv = "  ";
        //    string message = AESEncrypt("abcdefghigklmnopqrstuvwxyz0123456789", password, iv);
        //    Console.WriteLine(message);
        //    message = AESDecrypt("8Z3dZzqn05FmiuBLowExK0CAbs4TY2GorC2dDPVlsn/tP+VuJGePqIMv1uSaVErr", password, iv);
        //    Console.WriteLine(message);
        //}
        /// <summary>
        /// AES加密
        /// </summary>
        /// <param name="text">加密字符</param>
        /// <param name="password">加密的密码</param>
        /// <param name="iv">密钥</param>
        /// <returns></returns>
        public static string AESEncrypt(string text, string password, string iv)
        {
            RijndaelManaged rijndaelCipher = new RijndaelManaged();
            rijndaelCipher.Mode = CipherMode.CBC;
            rijndaelCipher.Padding = PaddingMode.PKCS7;
            rijndaelCipher.KeySize = 128;
            rijndaelCipher.BlockSize = 128;
            byte[] pwdBytes = System.Text.Encoding.UTF8.GetBytes(password);
            byte[] keyBytes = new byte[16];
            int len = pwdBytes.Length;
            if (len > keyBytes.Length) len = keyBytes.Length;
            System.Array.Copy(pwdBytes, keyBytes, len);
            rijndaelCipher.Key = keyBytes;
            byte[] ivBytes = System.Text.Encoding.UTF8.GetBytes(iv);
            rijndaelCipher.IV = new byte[16];
            ICryptoTransform transform = rijndaelCipher.CreateEncryptor();
            byte[] plainText = Encoding.UTF8.GetBytes(text);
            byte[] cipherBytes = transform.TransformFinalBlock(plainText, 0, plainText.Length);
            return Convert.ToBase64String(cipherBytes);
        }
        /// <summary>
        /// AES解密
        /// </summary>
        /// <param name="text"></param>
        /// <param name="password"></param>
        /// <param name="iv"></param>
        /// <returns></returns>
        public static string AESDecrypt(string text, string password, string iv)
        {
            RijndaelManaged rijndaelCipher = new RijndaelManaged();
            rijndaelCipher.Mode = CipherMode.CBC;
            rijndaelCipher.Padding = PaddingMode.PKCS7;
            rijndaelCipher.KeySize = 128;
            rijndaelCipher.BlockSize = 128;
            byte[] encryptedData = Convert.FromBase64String(text);
            byte[] pwdBytes = System.Text.Encoding.UTF8.GetBytes(password);
            byte[] keyBytes = new byte[16];
            int len = pwdBytes.Length;
            if (len > keyBytes.Length) len = keyBytes.Length;
            System.Array.Copy(pwdBytes, keyBytes, len);
            rijndaelCipher.Key = keyBytes;
            byte[] ivBytes = System.Text.Encoding.UTF8.GetBytes(iv);
            rijndaelCipher.IV = ivBytes;
            ICryptoTransform transform = rijndaelCipher.CreateDecryptor();
            byte[] plainText = transform.TransformFinalBlock(encryptedData, 0, encryptedData.Length);
            return Encoding.UTF8.GetString(plainText);
        }


        public static byte[] AesEncryptor(string input, string password)
        {
            byte[] bsFile = System.Text.Encoding.UTF8.GetBytes(input);
            RijndaelManaged aes = new RijndaelManaged();
            string MD5Pwd = MD5Encrypt(password);
            aes.Key = Encoding.UTF8.GetBytes(MD5Pwd);
            aes.IV = Encoding.UTF8.GetBytes(MD5Pwd.Substring(8, 16));
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;
            ICryptoTransform transform = aes.CreateEncryptor();
            return transform.TransformFinalBlock(bsFile, 0, bsFile.Length);
        }




        public static string AesDecryptor(byte[] bsFile, string password)
        {
            RijndaelManaged aes = new RijndaelManaged();
            string MD5Pwd = MD5Encrypt(password);
            aes.Key = Encoding.UTF8.GetBytes(MD5Pwd);
            aes.IV = Encoding.UTF8.GetBytes(MD5Pwd.Substring(8, 16));
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            ICryptoTransform transform = aes.CreateDecryptor();
            var deBytes = transform.TransformFinalBlock(bsFile, 0, bsFile.Length);
            return Encoding.UTF8.GetString(deBytes);
        }




        ///   <summary>  
        ///   给一个字符串进行MD5加密  
        ///   </summary>  
        ///   <param   name="strText">待加密字符串</param>  
        ///   <returns>加密后的字符串</returns>  
        public static string MD5Encrypt(string input)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);
            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

      
    }
}