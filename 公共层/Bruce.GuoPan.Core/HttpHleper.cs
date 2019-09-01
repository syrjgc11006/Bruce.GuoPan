using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bruce.GuoPan.Core
{
    public class HttpHleper
    {
        HttpWebRequest wReq;
        public void Load()
        {
            wReq.Proxy = null;
            wReq.Credentials = CredentialCache.DefaultCredentials;
            //设置页面超时时间为12秒
            wReq.Timeout = 12000;
            wReq.KeepAlive = true;
            wReq.Accept = "*/*";
        }
        public string GetHtml(string url, string cookie, string webCode, string startPos, string endPos, bool IsAjax)
        {

            Encoding wCode;
            string PostPara;
            CookieContainer CookieCon = new CookieContainer();
            if (Regex.IsMatch(url, @"<POST>.*</POST>", RegexOptions.IgnoreCase))
                wReq = (HttpWebRequest)WebRequest.Create(@url.Substring(0, url.IndexOf("<POST>")));
            else
            {
                Uri uri = new Uri(url);
                wReq = (HttpWebRequest)WebRequest.Create(uri);
            }
            Match a = Regex.Match(url, @"(http://).[^/]*[?=/]", RegexOptions.IgnoreCase);
            string url1 = a.Groups[0].Value.ToString();
            wReq.Referer = url1;
            if (cookie != "")
            {
                CookieCollection cl = GetWebCookies(cookie);
                CookieCon.Add(new Uri(url), cl);
                wReq.CookieContainer = CookieCon;
            }
            if (Regex.IsMatch(url, @"(?<=<POST>)[\S\s]*(?=</POST>)", RegexOptions.IgnoreCase))
            {
                Match s = Regex.Match(url, @"(?<=<POST>).*(?=</POST>)", RegexOptions.IgnoreCase);
                PostPara = s.Groups[0].Value.ToString();
                byte[] pPara = Encoding.ASCII.GetBytes(PostPara);
                wReq.ContentType = "application/x-www-form-urlencoded";
                wReq.ContentLength = pPara.Length;
                wReq.Method = "POST";
                System.IO.Stream reqStream = wReq.GetRequestStream();
                reqStream.Write(pPara, 0, pPara.Length);
                reqStream.Close();

            }
            else
            {
                wReq.Method = "GET";
                wReq.ContentType = "text/html";
            }
            this.Load();
            HttpWebResponse wResp = GetResponse(wReq, 0, null);
            System.IO.Stream respStream = wResp.GetResponseStream();
            string strWebData = "";
            switch (webCode)
            {
                case "AUTO":
                    try
                    {
                        wCode = Encoding.Default;
                        string cType = wResp.ContentType.ToLower();
                        Match charSetMatch = Regex.Match(cType, "(?<=charset=)([^<]*)*", RegexOptions.IgnoreCase | RegexOptions.Multiline);
                        string webCharSet = charSetMatch.ToString();
                        wCode = System.Text.Encoding.GetEncoding(webCharSet);
                    }
                    catch
                    {
                        wCode = Encoding.Default;
                    }
                    break;
                case "GB2312":
                    wCode = Encoding.GetEncoding("gb2312");
                    break;
                case "UTF8":
                    wCode = Encoding.UTF8;
                    break;
                case "GBK":
                    wCode = Encoding.GetEncoding("GBK");
                    break;
                default:
                    wCode = Encoding.UTF8;
                    break;
            }
            if (wResp.ContentEncoding == "gzip")
            {
                GZipStream myGZip = new GZipStream(respStream, CompressionMode.Decompress);
                System.IO.StreamReader reader;
                reader = new System.IO.StreamReader(myGZip, wCode);
                strWebData = reader.ReadToEnd();
                reader.Close();
                reader.Dispose();
            }
            else
            {
                System.IO.StreamReader reader;
                reader = new System.IO.StreamReader(respStream, wCode);
                strWebData = reader.ReadToEnd();
                reader.Close();
                reader.Dispose();
            }
            if (!string.IsNullOrEmpty(startPos) && !string.IsNullOrEmpty(endPos))
            {
                string Splitstr = "(" + startPos + ").*?(" + endPos + ")";
                Match aa = Regex.Match(strWebData, Splitstr, RegexOptions.IgnoreCase | RegexOptions.Multiline);
                if (aa.Success)
                {
                    strWebData = aa.Groups[0].ToString();
                }
            }
            if (IsAjax == true)
            {
                strWebData = System.Web.HttpUtility.UrlDecode(strWebData, Encoding.UTF8);
            }
            wResp.Close();
            wReq.Abort();
            return strWebData;
        }

        List<string> userAgent = new List<string>()
        {
            "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1; Trident/4.0; QQWubi 133; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; CIBA; InfoPath.2)",
            "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/37.0.2062.103 Safari/537.36",
            "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.0; .NET CLR 1.1.4322; .NET CLR 2.0.50215;)",
            "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.0; SLCC1; .NET CLR 2.0.50727; .NET CLR 3.0.04506; .NET CLR 3.5.21022; .NET CLR 1.0.3705; .NET CLR 1.1.4322)",
        };

        private HttpWebResponse GetResponse(HttpWebRequest wReq, int count, Exception ex)
        {
            if (count + 1 == userAgent.Count)
            {
                throw ex;
            }
            HttpWebResponse wResp = null;
            try
            {
                wReq.UserAgent = userAgent[count];
                wResp = (HttpWebResponse)wReq.GetResponse();
            }
            catch (Exception ee)
            {
                return GetResponse(wReq, count + 1, ee);
            }
            return wResp;
        }

        private CookieCollection GetWebCookies(string cookie)
        {
            CookieCollection cl = new CookieCollection();
            foreach (string sc in cookie.Split(';'))
            {
                string ss = sc.Trim();
                if (ss.IndexOf("&") > 0)
                {
                    foreach (string s1 in ss.Split('&'))
                    {
                        string s2 = s1.Trim();
                        string s4 = s2.Substring(s2.IndexOf("=") + 1, s2.Length - s2.IndexOf("=") - 1);

                        cl.Add(new Cookie(s2.Split('=')[0].Trim(), s4, "/"));
                    }
                }
                else
                {
                    string s3 = sc.Trim();
                    cl.Add(new Cookie(s3.Split('=')[0].Trim(), s3.Split('=')[1].Trim(), "/"));
                }
            }
            return cl;
        }
        /// <summary>
        /// 请求指定Url返回字符串，支持 gzip, deflate
        /// </summary>
        /// <param name="url"></param>
        /// <param name="charsetType">编码格式 0.Default 1.UTF-8 2.GB2312 3.GBK</param>
        /// <returns></returns>
        public string GetString(string url, string charsetType)
        {
            if (string.IsNullOrWhiteSpace(charsetType))
            {
                charsetType = "UTF-8";
            }
            string result = string.Empty;
            var webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Method = "GET";
            webRequest.AllowAutoRedirect = true;
            webRequest.Headers["Accept-Encoding"] = "gzip, deflate";
            webRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/52.0.2743.116 Safari/537.36 Edge/15.15063";
            webRequest.KeepAlive = true;
            //响应请求
            using (var response = (HttpWebResponse)webRequest.GetResponse())
            {
                Stream tempStream;//根据response内容编码，返回对应格式的流
                if (response.ContentEncoding.ToLower().Contains("gzip"))
                {
                    tempStream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress);
                }
                else if (response.ContentEncoding.ToLower().Contains("deflate"))
                {
                    tempStream = new DeflateStream(response.GetResponseStream(), CompressionMode.Decompress);
                }
                else
                {
                    tempStream = response.GetResponseStream();
                }
                if (tempStream != null)
                {
                    using (var stream = new StreamReader(tempStream, Encoding.GetEncoding(charsetType)))
                    {
                        result = stream.ReadToEnd();
                        stream.Close();
                    }
                    tempStream.Close();
                }
                response.Close();
            }
            return result;
        }

        /// <summary>
        /// 请求指定Url返回字符串，支持 gzip, deflate
        /// </summary>
        /// <param name="url"></param>
        /// <param name="charsetType">编码格式 0.Default 1.UTF-8 2.GB2312 3.GBK</param>
        /// <returns></returns>
        public async Task<string> GetStringAsync(string url, string charsetType = "UTF-8")
        {
            if (string.IsNullOrWhiteSpace(charsetType))
            {
                charsetType = "UTF-8";
            }
            string result = string.Empty;
            var webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Method = "GET";
            webRequest.AllowAutoRedirect = true;
            webRequest.Headers["Accept-Encoding"] = "gzip, deflate";
            webRequest.AutomaticDecompression = DecompressionMethods.GZip;
            //webRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/52.0.2743.116 Safari/537.36 Edge/15.15063";
            webRequest.KeepAlive = true;
            var data = webRequest.GetResponse();
            //响应请求
            using (var response = (HttpWebResponse)await webRequest.GetResponseAsync())
            {
                Stream tempStream;//根据response内容编码，返回对应格式的流
                if (response.ContentEncoding.ToLower().Contains("gzip"))
                {
                    tempStream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress);
                }
                else if (response.ContentEncoding.ToLower().Contains("deflate"))
                {
                    tempStream = new DeflateStream(response.GetResponseStream(), CompressionMode.Decompress);
                }
                else
                {
                    tempStream = response.GetResponseStream();
                }
                if (tempStream != null)
                {
                    using (var stream = new StreamReader(tempStream, Encoding.GetEncoding(charsetType)))
                    {
                        result = stream.ReadToEnd();
                        stream.Close();
                    }
                    tempStream.Close();
                }
                response.Close();

            }
            return result;
        }
    }
}
