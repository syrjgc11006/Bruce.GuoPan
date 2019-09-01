using Bruce.GuoPan.Data.DataProvider;
using Bruce.GuoPan.Model;
using Bruce.GuoPan.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bruce.GuoPan.Core;
using System.Data;

namespace Bruce.GuoPan.Bll
{
    public class GiftUserBll : BaseBll<UserGiftRecord>
    {
        readonly private BaseBll<GiftBaseData> _giftRespostitory;
        readonly private BaseBll<UserInfo> _userRespostitory;
        public GiftUserBll()
        {
            _giftRespostitory = new BaseBll<GiftBaseData>();
            _userRespostitory = new BaseBll<UserInfo>();
        }

        public int AddGiftUser(int userId, int giftId, string collectUrl, Dictionary<string, object> result)
        {
            if (result == null)
            {
                return 0;
            }
            var user = _userRespostitory.GetOne(userId);
            var gift = _giftRespostitory.GetOne(giftId);

            UserGiftRecord record = new UserGiftRecord()
            {
                UserId = userId,
                UserName = user.UserName,
                GiftId = giftId,
                GiftName = gift.GiftName,
                GiftStatuName = gift.GiftStatusName,
                GiftTypeName = gift.GiftTypeName,
                CollectUrl = collectUrl,
                PlatName = "安卓",
                Data = result["result"].ToString() == "0" ? result["data"].ToJSON() : "",
                Msg = result["msg"].ToString(),
                Result = result["result"].ToString()
            };
            var model = base.GetList(m => m.UserId == userId && m.GiftId == giftId);
            if (model != null && model.FirstOrDefault() != null)
            {
                var entity = model.FirstOrDefault();
                entity.UserId = userId;
                entity.UserName = user.UserName;
                entity.GiftId = giftId;
                entity.GiftName = gift.GiftName;
                entity.GiftStatuName = gift.GiftStatusName;
                entity.GiftTypeName = gift.GiftTypeName;
                entity.CollectUrl = collectUrl;
                entity.PlatName = "安卓";
                entity.Data = result["data"].ToJSON();
                entity.Msg = result["msg"].ToString();
                entity.Result = result["result"].ToString();
                if (result["result"].ToString() != "4")
                {
                    base.Update(entity);
                }
                return 0;
            }
            else
            {
                return base.Insert(record);
            }
        }

    }
}
