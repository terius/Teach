using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Helpers
{
    /// <summary>  
    /// 实现传送数据的加解密  
    /// </summary>  
    public partial class AESHelper
    {
        /// <summary>  
        /// 哈希算法的密钥  
        /// </summary>  
        private const String _hmackey = "昨夜星辰昨夜风，画楼西畔桂堂东。身无彩凤双飞翼，心有灵犀一点通。";

        /// <summary>  
        /// AES对称算法的托管实现  
        /// </summary>  
        protected AesManaged _aes;

        /// <summary>  
        /// 加密密钥字段  
        /// </summary>  
        private String _secretKey;

        /// <summary>  
        /// 加密密钥属性  
        /// </summary>  
        public String SecretKey
        {
            get { return _secretKey; }
            set
            {
                _secretKey = value;
                if (String.IsNullOrEmpty(value))
                {   // 关闭加密传输模块  
                    SecurityClose();
                }
                else
                {
                    if (_aes == null) _aes = new AesManaged();

                    // 更新加密密钥（256位）  
                    using (SHA256Managed sha = new SHA256Managed())
                    {
                        _aes.Key = sha.ComputeHash(Encoding.UTF8.GetBytes(value + _salt));
                        sha.Clear();    // 清除敏感数据  
                    }

                    // 更新初始向量（128位）  
                    using (HMACMD5 hmacmd5 = new HMACMD5(Encoding.UTF8.GetBytes(_hmackey)))
                    {
                        _aes.IV = hmacmd5.ComputeHash(Encoding.UTF8.GetBytes(_salt));
                        hmacmd5.Clear();    // 清除敏感数据  
                    }
                }
            }
        }

        /// <summary>  
        /// 最短密码佐料长度  
        /// </summary>  
        public const Int32 MinSaltLength = 16;

        /// <summary>  
        /// 密码佐料字段  
        /// </summary>  
        private String _salt = "雄关漫道真如铁，而今迈步从头越。从头越，苍山如海，残阳如血。";

        /// <summary>  
        /// 密码佐料属性  
        /// </summary>  
        public String Salt
        {
            get { return _salt; }
            set
            {   // 要求Salt的长度大于16个字符  
                if (!String.IsNullOrEmpty(value) && value.Length >= MinSaltLength)
                {
                    _salt = value;
                    if (!String.IsNullOrEmpty(_secretKey))
                    {   // 更新加密密钥（256位）  
                        using (SHA256Managed sha = new SHA256Managed())
                        {
                            _aes.Key = sha.ComputeHash(Encoding.UTF8.GetBytes(_secretKey + value));
                            sha.Clear();    // 清除敏感数据  
                        }

                        // 更新初始向量（128位）  
                        using (HMACMD5 hmacmd5 = new HMACMD5(Encoding.UTF8.GetBytes(_hmackey)))
                        {
                            _aes.IV = hmacmd5.ComputeHash(Encoding.UTF8.GetBytes(value));
                            hmacmd5.Clear();    // 清除敏感数据  
                        }
                    }
                }
            }
        }

        /// <summary>  
        /// 加密数据  
        /// </summary>  
        /// <param name="buffer">原始数据</param>  
        /// <param name="offset">字节偏移量</param>  
        /// <param name="count">要写入当前流的字节数</param>  
        /// <returns>加密后的数据</returns>          
        public Byte[] Encrypt(Byte[] buffer, Int32 offset, Int32 count)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, _aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(buffer, offset, count);
                    cs.Close();
                    return ms.ToArray();
                }
            }
        }

        /// <summary>  
        /// 解密数据  
        /// </summary>  
        /// <param name="buffer">原始数据</param>  
        /// <param name="offset">字节偏移量</param>  
        /// <param name="count">要写入当前流的字节数</param>  
        /// <returns>解密后的数据</returns>  
        public Byte[] Decrypt(Byte[] buffer, Int32 offset, Int32 count)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, _aes.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(buffer, offset, count);
                    cs.Close();
                    return ms.ToArray();
                }
            }
        }

        /// <summary>  
        /// 关闭加密传输模块  
        /// </summary>  
        private void SecurityClose()
        {
            if (_aes != null)
            {
                _aes.Clear();    // 清除敏感数据  
                _aes.Dispose();  // 释放资源  
                _aes = null;
            }
        }
    }
}
