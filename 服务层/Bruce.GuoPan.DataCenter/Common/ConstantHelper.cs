using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bruce.GuoPan.DataCenter.Common
{
    public class ConstantHelper
    {
        //安卓礼包列表
        public static readonly string android_searchUrl = "http://www.guopan.cn/search/?pt={0}&type={1}&status={2}&name=";

        public static readonly string ContentScopeRegx = @"<tr[^>]*?>([\s\S]*?)</tr>";

        public static readonly string NameRegx = @"(?<=""lb-title"">).*(?=</a>)";

        public static readonly string ValidateTimeRegx = @"(?<=""valid-time"">).*(?=</td>)";

        public static readonly string RemainRegx = @"(?<=剩余).*";

        public static readonly string UrlRegx = @"(?<=class=""common-btn2"" href="").*(?="" )";

        public static readonly string TotalGifts = @"(?<=共找到<em>).*(?=</em>)";
    }
}
