using Bruce.GuoPan.Core;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bruce.GuoPan.House
{
    public class HouseCapture
    {
        private static readonly string tableUrl = "http://fgj.wuhan.gov.cn/zz_spfxmcx_fang.jspx?dengJh=%E6%96%B01800727&houseDengJh=%E6%96%B00002692";
        private static string tableFileName = "\\B00002692";
        private static string fileFoldName = "\\TableLog" + tableFileName;  //根据目录名称来存储所有房间信息
        private static string tableRegex = @"<div class=""xinjia""([\s\S]*?)</div>";
        private static string targetTabletxt = @"target.txt";
        private static string homeHost = "http://119.97.201.22:8080";

        private static readonly HttpHleper _httpHleper = new HttpHleper();
        public HouseCapture()
        {

        }

        public static void CrapTable()
        {
            var content = _httpHleper.GetString(tableUrl, "UTF-8");

            string directorPath = AppDomain.CurrentDomain.BaseDirectory + fileFoldName;
            Directory.CreateDirectory(directorPath);

            string path = directorPath + tableFileName + ".txt";

            FileReadWriteHelper.WriteFile(content, path);
        }

        public static void ParseTable()
        {
            string directorPath = AppDomain.CurrentDomain.BaseDirectory + fileFoldName;
            string path = directorPath + tableFileName + ".txt";
            var content = FileReadWriteHelper.ReadFile(path);

            //抓取到表格数据
            var ScopeRegex = new Regex(tableRegex);

            //获取内容
            var searchMatchData = ScopeRegex.Matches(content);

            var targetTable = searchMatchData[0].Value;

            StringBuilder sb = new StringBuilder();
            sb.Append("<html><body>");
            sb.Append(targetTable);
            sb.Append("</body></html>");

            //使用HtmlAgilityPack加载table
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(sb.ToString());

            string outpath = directorPath + tableFileName + targetTabletxt;

            StreamWriter sw = new StreamWriter(outpath, false, Encoding.Default);


            foreach (HtmlNode table in doc.DocumentNode.SelectNodes("//table"))
            {
                Console.WriteLine("Found: " + table.Id);
                foreach (HtmlNode row in table.SelectNodes("tr"))
                {
                    Console.WriteLine("row");
                    foreach (HtmlNode cell in row.SelectNodes("th|td"))
                    {
                        string text = cell.InnerText;
                        Console.WriteLine("cell: " + cell.InnerText);

                        if (cell.SelectNodes("a") != null)
                        {
                            var ahtml = cell.SelectNodes("a").FirstOrDefault();

                            if (ahtml != null)
                            {
                                if (ahtml.HasAttributes)
                                {
                                    var url = ahtml.Attributes["href"].Value;
                                    text += ':' + url;
                                }

                            }
                        }


                        // 输出到文件
                        sw.Write(text + " , ");
                        sw.Write("");
                    }
                    sw.WriteLine("\n");
                }

            }
            sw.Close();

            //抓取TR数据
            //var trRegexs = new Regex(trRegex);
            //var trsCollection = trRegexs.Matches(targetTable);
            //foreach (Match item in trsCollection)
            //{

            //}
        }


        public static void SearchPrice(string url)
        {
            var content = _httpHleper.GetString(url, "UTF-8");

            //使用HtmlAgilityPack加载table
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(content);

            string href = string.Empty;

            foreach (HtmlNode table in doc.DocumentNode.SelectNodes("//form"))
            {
                href=  table.Attributes["action"].Value;
            }

            string targetUrl =string.Concat(homeHost,"/",href);

            var content1 = _httpHleper.GetString(targetUrl, "UTF-8");
        }
    }
}
