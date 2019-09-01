using Bruce.GuoPan.Core;
using Bruce.GuoPan.Data.DataProvider;
using Bruce.GuoPan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bruce.GuoPan.Bll
{
    public class GiftBll
    {
        readonly private NliteRepository<GiftBaseData> _giftRespostitory;
        public GiftBll()
        {
            _giftRespostitory = new NliteRepository<GiftBaseData>();
        }

        public List<GiftBaseData> GetAllGiftData()
        {
            return _giftRespostitory.GetAll();
        }

        public List<GiftBaseData> GetGiftDataByName(string name,string typeId)
        {
            if (string.IsNullOrEmpty(name)&&string.IsNullOrEmpty(typeId))
            {
                return _giftRespostitory.GetAll();
            }
            return _giftRespostitory.GetList(m => m.GiftName.Contains(name)&&m.GiftTypeName==typeId);
        }

        /// <summary>
        /// 新增礼包
        /// </summary>
        /// <param name="loginUser"></param>
        /// <returns></returns>
        public int AddandUpdateGift(GiftBaseData giftData)
        {
            if (_giftRespostitory.GetList(m => m.GiftName == giftData.GiftName).Count == 0)
            {
                return _giftRespostitory.Insert(giftData);
            }
            else
            {
                var model = _giftRespostitory.GetList(m => m.GiftName == giftData.GiftName).FirstOrDefault();
                model.GiftName = giftData.GiftName;
                model.GiftStatus = giftData.GiftStatus;
                model.GiftType = giftData.GiftType;
                model.GiftStatusName = giftData.GiftStatusName;
                model.GiftTypeName = giftData.GiftTypeName;
                model.PlateForm = giftData.PlateForm;
                model.Url = giftData.Url;
                model.ValidateTime = giftData.ValidateTime;
                model.Remain = giftData.Remain;
                _giftRespostitory.Update(model);
                return 1;
            }
        }

        /// <summary>
        /// 其他礼包新增
        /// </summary>
        /// <param name="giftData"></param>
        /// <returns></returns>
        public int AddandUpdateGift_All(GiftBaseData giftData)
        {
            if (_giftRespostitory.GetList(m => m.GiftName == giftData.GiftName).Count == 0)
            {
                return _giftRespostitory.Insert(giftData);
            }
            else
            {
                var model = _giftRespostitory.GetList(m => m.GiftName == giftData.GiftName &&
                m.GiftType != 1 && m.GiftType != 2 && m.GiftType != 3 && m.GiftType != 4 && m.GiftType != 5
                ).FirstOrDefault();
                if (model != null)
                {
                    model.GiftName = giftData.GiftName;
                    model.GiftStatus = giftData.GiftStatus;
                    model.GiftType = giftData.GiftType;
                    model.GiftStatusName = giftData.GiftStatusName;
                    model.GiftTypeName = giftData.GiftTypeName;
                    model.PlateForm = giftData.PlateForm;
                    model.Url = giftData.Url;
                    model.ValidateTime = giftData.ValidateTime;
                    model.Remain = giftData.Remain;
                    _giftRespostitory.Update(model);
                }
                return 1;
            }
        }
    }
}
