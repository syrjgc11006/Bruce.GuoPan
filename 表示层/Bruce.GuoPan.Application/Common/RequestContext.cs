using Bruce.GuoPan.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bruce.GuoPan.Application.Common
{
    /// <summary>
    /// 1、模拟登录；
    /// 2、登录后点击领取礼包；
    /// </summary>
    public class RequestContext
    {
        private static string tokenUrl = "http://www.guopan.cn/user/api/userExist.php?u={0}&s=1";  //获取用户token
        private static string loginUrl = "http://www.guopan.cn/user/api/login2.php";
        public static string giftUrl = "http://m.guopan.cn/user/api/libao_ajax.php?pid=0&ajax=getLibao&pf=0&gid={0}";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uname"></param>
        /// <returns>0：用户不存在</returns>
        public static string getToken(string uname)
        {
            string token = new HttpHleper().GetString(string.Format(tokenUrl, uname), "UTF-8");
            return token;
        }

        /// <summary>
        /// 通过用户名密码获取登录cookie
        /// </summary>
        /// <param name="uname"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public static CookieContainer GetCookie(string uname, string pwd)
        {
            var token = getToken(uname);
            if (token == "0")
            {
                MessageBox.Show("用户不存在");
            }
            CookieContainer myCookieContainer = new CookieContainer();
            Stream stream = null;
            HttpWebResponse webResponse = null;
            HttpWebRequest webRequest = null;
            var logindata = string.Format("uname={0}&upwd={1}&ac=login&s=1", uname, MD5Helper.MD5Base(token.TrimEnd('"').TrimStart('"') + pwd, 2).ToLower());
            try
            {
                byte[] byteArray = Encoding.UTF8.GetBytes(logindata);
                webRequest = (HttpWebRequest)WebRequest.Create(loginUrl);
                webRequest.CookieContainer = myCookieContainer;
                webRequest.Method = "POST";
                webRequest.KeepAlive = false;
                webRequest.ContentLength = byteArray.Length;
                webRequest.ContentType = "application/x-www-form-urlencoded";
                webRequest.Accept = "*/*";
                webRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/48.0.2564.109 Safari/537.36";
                stream = webRequest.GetRequestStream();
                stream.Write(byteArray, 0, byteArray.Length);
                webResponse = (HttpWebResponse)webRequest.GetResponse();
                StreamReader streamLoginReader = new StreamReader(webResponse.GetResponseStream(), Encoding.Default);
                var resultString = streamLoginReader.ReadToEnd();
                return myCookieContainer;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                stream.Close();
                webRequest = null;
                webRequest = null;
            }
        }

        /// <summary>
        /// 通过获取的Cookie
        /// </summary>
        /// <param name="cookie"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string GetContent(CookieContainer cookie, string url)
        {
            string content = string.Empty;
            HttpWebRequest httpRequest = (HttpWebRequest)HttpWebRequest.Create(url);
            httpRequest.CookieContainer = cookie;
            httpRequest.Referer = url;
            httpRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64; Trident/7.0; rv:11.0) like Gecko";
            httpRequest.Accept = "text/html, application/xhtml+xml, */*";
            httpRequest.ContentType = "application/json";
            httpRequest.Headers.Add("Accept-Language", "zh-CN,zh;q=0.9");
            httpRequest.Headers.Add("Accept-Encoding", "gzip, deflate");
            httpRequest.Method = "GET";

            HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (Stream responsestream = httpResponse.GetResponseStream())
            {
                Stream tempStream;//根据response内容编码，返回对应格式的流
                if (httpResponse.ContentEncoding.ToLower().Contains("gzip"))
                {
                    tempStream = new GZipStream(httpResponse.GetResponseStream(), CompressionMode.Decompress);
                }
                else if (httpResponse.ContentEncoding.ToLower().Contains("deflate"))
                {
                    tempStream = new DeflateStream(httpResponse.GetResponseStream(), CompressionMode.Decompress);
                }
                else
                {
                    tempStream = httpResponse.GetResponseStream();
                }
                if (tempStream != null)
                {
                    using (var stream = new StreamReader(tempStream, Encoding.GetEncoding("UTF-8")))
                    {
                        content = stream.ReadToEnd();
                        stream.Close();
                    }
                    tempStream.Close();
                }
                responsestream.Close();
            }
            //System.Web.HttpUtility.UrlDecode("\u8bf7\u4e0b\u8f7d\u679c\u76d8APP\u9886\u53d6!")，可解析格式
            return content;
        }
    }
}
