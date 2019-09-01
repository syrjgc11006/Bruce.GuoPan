using Bruce.GuoPan.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bruce.GuoPan.ViewModel
{
    public class CollectConfigModel
    {
        public EnumGiftPlatForm GiftPlatForm { get; set; }

        public EnumGiftState GiftStatus { get; set; }

        public EnumGiftType GiftType { get; set; }
        /// <summary>
        /// Url
        /// </summary>		
        public string Url { get; set; }

        /// <summary>
        /// 总条数
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// 总页数
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// 每页大小
        /// </summary>

        public int PageSize { get { return 10; } }
    }
}
