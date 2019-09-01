using Bruce.GuoPan.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bruce.GuoPan.ViewModel
{
    public class GameDataModel
    {
        public string Name { get; set; }
        public string PlateForm { get; set; }
        public string ValidateTime { get; set; }
        public string Remain { get; set; }
        public EnumGiftState GiftStatus { get; set; }
        public string GiftStatusName { get; set; }
        public EnumGiftType GiftType { get; set; }
        public string GiftTypeName { get; set; }
        public string Url { get; set; }
    }
}
