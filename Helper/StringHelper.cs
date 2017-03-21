using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace Helpers
{
    public class StringHelper
    {
        public static string TenToTwo(int value)
        {
            string j = Convert.ToString(value, 2);//j就是转换后的二进制了！！
            return j.PadLeft(14, '0');
        }

        public static int TwoToTen(string value)
        {
            int j = Convert.ToInt32(value, 2);
            return j;
        }

        /// <summary>
        /// 数字的安全转换
        /// </summary>
        /// <param name="oInt"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static int SafeGetIntFromObj(object oInt, int defaultVal = 0)
        {
            int iTemp = defaultVal;
            if (oInt == null)
                return defaultVal;
            return int.TryParse(oInt.ToString(), out iTemp) ? iTemp : defaultVal;
        }


        /// <summary>
        /// Double数字的安全转换
        /// </summary>
        /// <param name="oInt"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static double SafeGetDoubleFromObj(object oInt, double defaultVal = 0)
        {
            double iTemp = 0;
            if (oInt == null)
                return defaultVal;
            return double.TryParse(oInt.ToString(), out iTemp) ? iTemp : defaultVal;
        }


        /// <summary>
        /// 安全时间转换
        /// </summary>
        /// <param name="oDateTime"></param>
        /// <returns></returns>
        public static DateTime SafeGetDateTimeFromObj(object oDateTime, string defaultTime = null)
        {
            DateTime dftime = string.IsNullOrEmpty(defaultTime) ? DateTime.MinValue : Convert.ToDateTime(defaultTime);
            if (oDateTime == null)
            {
                return dftime;
            }
            DateTime t = dftime;
            if (DateTime.TryParse(oDateTime.ToString(), out t))
            {
                return t;
            }
            else
            {
                return dftime;
            }


        }

        public static DateTime? SafeGetNullAbleDateTimeFromObj(object oDateTime)
        {
            if (oDateTime == null)
            {
                return null;
            }
            DateTime t = DateTime.Now;
            if (DateTime.TryParse(oDateTime.ToString(), out t))
            {
                return t;
            }
            else
            {
                return null;
            }


        }

        public static bool SafeGetBooleanFromObj(object oData)
        {
            bool rs = false;
            if (oData == null)
            {
                return false;
            }
            if (bool.TryParse(oData.ToString(), out rs))
            {
                return rs;
            }
            return false;
        }
        public static decimal? SafeGetNullAbleDecimalFromObj(object ob)
        {
            if (ob == null)
            {
                return null;
            }
            decimal t = 0;
            if (decimal.TryParse(ob.ToString(), out t))
            {
                return t;
            }
            else
            {
                return null;
            }


        }

        public static decimal SafeGetDecimalFromObj(object ob)
        {
            decimal t = 0;
            if (decimal.TryParse(ob.ToString(), out t))
            {
                return t;
            }
            else
            {
                return 0;
            }


        }



        /// <summary>
        /// 比较两个byte[]数组是否相等
        /// </summary>
        /// <param name="b1"></param>
        /// <param name="b2"></param>
        /// <returns></returns>
        public static bool ByteEquals(byte[] b1, byte[] b2)
        {
            if (b1 == null || b2 == null) return false;
            if (b1.Length != b2.Length) return false;

            for (int i = 0; i < b1.Length; i++)
                if (b1[i] != b2[i])
                    return false;
            return true;
        }

        /// <summary>
        /// 根据枚举得到描述信息
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetEnumDescription(Enum value)
        {
            if (value == null)
            {
                return "未知";
            }
            FieldInfo field = value.GetType().GetField(value.ToString());
            if (field == null)
            {
                return "未知";
            }
            DescriptionAttribute[] attributes = (DescriptionAttribute[])field.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return (attributes.Length > 0) ? attributes[0].Description : value.ToString();
        }


        /// <summary>
        /// 获取一天上下午晚上描述
        /// </summary>
        /// <param name="daypart"></param>
        /// <returns></returns>
        public static string GetDayPartText(int daypart)
        {
            switch (daypart)
            {
                case 1:
                    return "上午";
                case 2:
                    return "下午";
                case 3:
                    return "晚上";
                default:
                    break;
            }
            return "";
        }


        public static string NumToChineseNum(int num)
        {
            string chineseNum = "";
            switch (num)
            {
                case 0:
                    chineseNum = "零";
                    break;
                case 1:
                    chineseNum = "一";
                    break;
                case 2:
                    chineseNum = "二";
                    break;
                case 3:
                    chineseNum = "三";
                    break;
                case 4:
                    chineseNum = "四";
                    break;
                case 5:
                    chineseNum = "五";
                    break;
                case 6:
                    chineseNum = "六";
                    break;
                case 7:
                    chineseNum = "七";
                    break;
                case 8:
                    chineseNum = "八";
                    break;
                case 9:
                    chineseNum = "九";
                    break;
                case 10:
                    chineseNum = "十";
                    break;
                default:
                    break;
            }
            return chineseNum;
        }

        public static string ByteArrayToHexString(byte[] data)
        {
            StringBuilder sb = new StringBuilder(data.Length * 3);
            foreach (byte b in data)
                sb.Append(Convert.ToString(b, 16).PadLeft(2, '0').PadRight(3, ' '));
            return sb.ToString().ToUpper();
        }


        /// <summary>
        /// 验证身份证号码
        /// </summary>
        /// <param name="Id">身份证号码</param>
        /// <returns>验证成功为True，否则为False</returns>
        public static bool CheckIDCard(string Id)
        {
            if (Id.Length == 18)
            {
                bool check = CheckIDCard18(Id);
                return check;
            }
            else if (Id.Length == 15)
            {
                bool check = CheckIDCard15(Id);
                return check;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 验证15位身份证号
        /// </summary>
        /// <param name="Id">身份证号</param>
        /// <returns>验证成功为True，否则为False</returns>
        private static bool CheckIDCard15(string Id)
        {
            long n = 0;
            if (long.TryParse(Id, out n) == false || n < Math.Pow(10, 14))
            {
                return false;//数字验证
            }
            string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(Id.Remove(2)) == -1)
            {
                return false;//省份验证
            }
            string birth = Id.Substring(6, 6).Insert(4, "-").Insert(2, "-");
            DateTime time = new DateTime();
            if (!DateTime.TryParse(birth, out time))
            {
                return false;//生日验证
            }
            return true;//符合15位身份证标准
        }


        /// <summary>
        /// 验证18位身份证号
        /// </summary>
        /// <param name="Id">身份证号</param>
        /// <returns>验证成功为True，否则为False</returns>
        private static bool CheckIDCard18(string Id)
        {
            long n = 0;
            if (long.TryParse(Id.Remove(17), out n) == false || n < Math.Pow(10, 16) || long.TryParse(Id.Replace('x', '0').Replace('X', '0'), out n) == false)
            {
                return false;//数字验证
            }
            string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(Id.Remove(2)) == -1)
            {
                return false;//省份验证
            }
            string birth = Id.Substring(6, 8).Insert(6, "-").Insert(4, "-");
            DateTime time = new DateTime();
            if (DateTime.TryParse(birth, out time) == false)
            {
                return false;//生日验证
            }
            string[] arrVarifyCode = ("1,0,x,9,8,7,6,5,4,3,2").Split(',');
            string[] Wi = ("7,9,10,5,8,4,2,1,6,3,7,9,10,5,8,4,2").Split(',');
            char[] Ai = Id.Remove(17).ToCharArray();
            int sum = 0;
            for (int i = 0; i < 17; i++)
            {
                sum += int.Parse(Wi[i]) * int.Parse(Ai[i].ToString());
            }
            int y = -1;
            Math.DivRem(sum, 11, out y);
            if (arrVarifyCode[y] != Id.Substring(17, 1).ToLower())
            {
                return false;//校验码验证
            }
            return true;//符合GB11643-1999标准
        }


        public static DateTime GetBirthdayFromIdCard(string idcard)
        {
            DateTime dt = Convert.ToDateTime("1980-01-01");
            string birth = idcard.Length > 14 ? idcard.Substring(6, 8).Insert(6, "-").Insert(4, "-") : "1980-01-01";
            if (DateTime.TryParse(birth, out dt))
            {
                return dt;
            }
            return dt;
        }


        public static bool GetSexFromIdCard(string idcard)
        {
            string sexFlag = "1";
            if (idcard.Length == 15)
            {
                sexFlag = idcard.Substring(14, 1);
            }
            else if (idcard.Length == 18)
            {
                sexFlag = idcard.Substring(16, 1);
            }
            bool sex = Convert.ToInt32(sexFlag) % 2 == 1;
            return sex;
        }


        ///// <summary>
        ///// 数组去除重复数据和空字符串
        ///// </summary>
        ///// <param name="s"></param>
        ///// <returns></returns>
        //public static string[] DelDupAndEmpty(string[] s)
        //{

        //    HashSet<string> hs = new HashSet<string>(s); //此时已经去掉重复的数据保存在hashset中
        //    hs.Remove("");//去除空字符串
        //    String[] rid = new string[hs.Count];
        //    hs.CopyTo(rid);
        //    return rid;
        //}





        //public static bool CheckDateIsInPlan(DateTime selectDate, int PlanValue)
        //{
        //    if (PlanValue <= 0)
        //    {
        //        return false;
        //    }
        //    if (selectDate <DateTime.Now)
        //    {
        //        return false;
        //    }
        //    string planStr = TenToTwo(PlanValue);

        //    DayOfWeek dow = selectDate.DayOfWeek;
        //    int timeWeek = (int)dow == 0 ? 7 : (int)dow;
        //    bool timeIsShangWu = selectDate.Hour < 12 ? true : false;
        //    int idx = 0;
        //    foreach (char c in planStr)
        //    {
        //        if (c.ToString() == "1")
        //        {
        //            int week = idx / 2 + 1;
        //            bool isShangWu = idx % 2 == 0 ? true : false;
        //            if (timeWeek == week)
        //            {
        //                if (timeIsShangWu == isShangWu)
        //                {
        //                    return true;
        //                }
        //            }
        //        }
        //        idx++;
        //    }

        //    return false;
        //}


        //public static bool CheckPlan(string bigStr, string smallStr)
        //{
        //    if (bigStr == "00000000000000" || string.IsNullOrEmpty(bigStr))
        //    {
        //        return false;
        //    }
        //    if (smallStr == "00000000000000" || string.IsNullOrEmpty(smallStr))
        //    {
        //        return true;
        //    }

        //    if (bigStr.Length != smallStr.Length)
        //    {
        //        return false;
        //    }
        //    for (int i = 0; i < smallStr.Length; i++)
        //    {
        //        if (smallStr[i].ToString() == "1")
        //        {
        //            if (bigStr[i] == smallStr[i])
        //            {
        //                continue;
        //            }
        //            else
        //            {
        //                return false;
        //            }
        //        }
        //    }
        //    return true;
        //}



        #region RSA加解密
        //加密算法  
        public static string RSAEncrypt(string encryptString)
        {


            CspParameters csp = new CspParameters();
            csp.KeyContainerName = "teriusyouareveryniubihahaha";

            RSACryptoServiceProvider RSAProvider = new RSACryptoServiceProvider(csp);
            byte[] encryptBytes = RSAProvider.Encrypt(ASCIIEncoding.ASCII.GetBytes(encryptString), true);
            string str = "";
            foreach (byte b in encryptBytes)
            {
                str = str + string.Format("{0:x2}", b);
            }
            return str;
        }


        //解密算法  
        public static string RSADecrypt(string decryptString)
        {
            CspParameters csp = new CspParameters();
            csp.KeyContainerName = "teriusyouareveryniubihahaha";
            RSACryptoServiceProvider RSAProvider = new RSACryptoServiceProvider(csp);
            int length = (decryptString.Length / 2);
            byte[] decryptBytes = new byte[length];
            for (int index = 0; index < length; index++)
            {
                string substring = decryptString.Substring(index * 2, 2);
                decryptBytes[index] = Convert.ToByte(substring, 16);
            }
            decryptBytes = RSAProvider.Decrypt(decryptBytes, true);
            return ASCIIEncoding.ASCII.GetString(decryptBytes);
        }

        #endregion


        public static string Sha256(string plainText)
        {
            SHA256Managed _sha256 = new SHA256Managed();
            byte[] _cipherText = _sha256.ComputeHash(Encoding.Default.GetBytes(plainText));
            return Convert.ToBase64String(_cipherText);
        }


        public static byte[] IntToByte4(int Num)
        {
            byte[] abyte = new byte[8]; //int为32位除4位，数组为8
            int j = 0xf;
            int z = 4; //转换的位数 
            for (int i = 0; i < 8; i++)
            {
                int y = j << z * i;
                int x = Num & y;
                x = x >> (z * i);
                abyte[i] = (byte)(x);
            }

            return abyte;
        }

        /// <summary>  
        /// 把int32类型的数据转存到4个字节的byte数组中  
        /// </summary>  
        /// <param name="m">int32类型的数据</param>  
        /// <param name="arry">4个字节大小的byte数组</param>  
        /// <returns></returns>  
        public static bool ConvertIntToByteArray4(Int32 m, ref byte[] arry)
        {
            if (arry == null) return false;
            if (arry.Length < 4) return false;

            arry[0] = (byte)(m & 0xFF);
            arry[1] = (byte)((m & 0xFF00) >> 8);
            arry[2] = (byte)((m & 0xFF0000) >> 16);
            arry[3] = (byte)((m >> 24) & 0xFF);

            return true;
        }

    }
}
