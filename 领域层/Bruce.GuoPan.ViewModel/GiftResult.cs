using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bruce.GuoPan.ViewModel
{
    public class GiftResult
    {
        public string result { get; set; }

        public GiftDatails data { get; set; }

        public string msg { get; set; }
    }

    public class GiftDatails
    {
        public string id { get; set; }
        public string gift_id { get; set; }

        public string gift_code { get; set; }

        public string uin { get; set; }

        public string get_time { get; set; }

        public string beDel { get; set; }

        public string get_from { get; set; }

        public string ip { get; set; }

    }
}
