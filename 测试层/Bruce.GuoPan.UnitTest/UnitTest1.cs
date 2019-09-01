using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Bruce.GuoPan.ViewModel;
using Bruce.GuoPan.DataCenter;
using Bruce.GuoPan.Model;
using Bruce.GuoPan.Bll;
using Bruce.GuoPan.DataCenter.Common;
using Bruce.GuoPan.Application.Common;
using Bruce.GuoPan.Core;
using System.Net;

namespace Bruce.GuoPan.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var data = RequestContext.getToken("1507102ee165");
        }

        [TestMethod]
        public void TestMethod2()
        {
            CookieContainer cookie = RequestContext.GetCookie("15071021675", "123456");

            CacheHelper.SetCache("15071021675", cookie, 2000);
            var datas = (CookieContainer)(CacheHelper.GetCache("15071021675"));
            //CacheHelper.Add("15071021675", cookie, 2);
            //var datas = (CookieContainer)(CacheHelper.Get("15071021675"));

            //var strcookie = SerializeHelper.ToJSON(cookie);
            //var data = SerializeHelper.FromJSON<CookieContainer>(strcookie);
        }

        [TestMethod]
        public void TestMethod3()
        {
            string captureUrl = "http://m.guopan.cn/user/api/libao_ajax.php?pid=0&ajax=getLibao&pf=0&gid=15253";
            var data = RequestContext.GetCookie("15071021675", "123456");
            RequestContext.GetContent(data, captureUrl);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var datas = (CookieContainer)(CacheHelper.GetCache("15071021675"));
        }

        [TestMethod]
        public void TestMethod5()
        {
            string url = "http://www.guopan.cn/libao/612_0/";
            string newurl = url.Substring(27);
            string a= newurl.Substring(0, newurl.LastIndexOf('_'));

        }
    }

}
