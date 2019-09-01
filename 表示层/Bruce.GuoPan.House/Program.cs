using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bruce.GuoPan.House
{
    class Program
    {
        static void Main(string[] args)
        {
            //step1:抓取table
            //HouseCapture.CrapTable();
            //step2:通过table获取其中的有效房屋信息，并存储在内存中
            //HouseCapture.ParseTable();

            HouseCapture.SearchPrice("http://119.97.201.22:8080/chktest2.aspx?gid=91BF7FDD-265F-49C0-A654-F2BC1EF74CCC");

            Console.ReadLine();
        }
    }
}
