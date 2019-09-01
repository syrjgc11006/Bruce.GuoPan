using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Bruce.GuoPan.Core
{
    /// <summary>
    /// 文件读写帮助类
    /// </summary>
    public class FileReadWriteHelper
    {
        public static void WriteFile(string htmlString, string path)
        {
            File.WriteAllText(path, htmlString);
        }

        public static string ReadFile(string path)
        {
            return File.ReadAllText(path);
        }
    }
}
