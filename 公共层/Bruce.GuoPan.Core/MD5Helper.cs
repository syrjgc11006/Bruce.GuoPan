using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Bruce.GuoPan.Core
{
    public class MD5Helper
    {
        public static string MD5Base(string str, int type)
        {
            switch (type)
            {
                case 16:
                    return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5").Substring(8, 16);
                default:
                    return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5");
            }
        }
        /// <summary>
        /// 对给定字符串进行MD5加密
        /// </summary>
        /// <param name="msg">待加密字符串</param>
        /// <param name="encoding">编码格式，默认UTF-8</param>
        /// <returns>加密后的字符串</returns>
        public static string Encrypt(string msg, string encoding = "UTF-8")
        {
            if (string.IsNullOrEmpty(msg))
            {
                return string.Empty;
            }

            if (string.IsNullOrEmpty(encoding.Trim()))
            {
                encoding = "UTF-8";
            }

            MD5 md5 = MD5.Create();
            byte[] bytes = Encoding.GetEncoding(encoding).GetBytes(msg);
            byte[] res = md5.ComputeHash(bytes);

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < res.Length; i++)
            {
                sb.Append(res[i].ToString("x2"));
            }
            return sb.ToString();
        }

        /// <summary>
        /// RSA加密
        /// </summary>
        /// <param name="publickey"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string RSAEncrypt(string publickey, string content)
        {
            publickey = @"<RSAKeyValue><Modulus>0wE26IHp4U9OLtPhJ+fT8ej6aWORFP8pd++MjUuhkQQm/zhcImbxQbjxtSAftz+kkDwGDFJpSldQPyigOGcUx7PofTc6VhiFik9E9SsxV9n0iEEtqUndDfmBJfPAWt+4UDMwKakgZqFoapDuwjKlTErFvKCyKCs+qN9OZvZwKWk=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            byte[] cipherbytes;
            rsa.FromXmlString(publickey);//.FromXmlString(publickey);
            cipherbytes = rsa.Encrypt(Encoding.UTF8.GetBytes(content), false);

            return Convert.ToBase64String(cipherbytes);

        }
    }
}
