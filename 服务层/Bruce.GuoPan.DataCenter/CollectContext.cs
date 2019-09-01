using Bruce.GuoPan.Core;
using Bruce.GuoPan.DataCenter.Common;
using Bruce.GuoPan.Model;
using Bruce.GuoPan.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bruce.GuoPan.DataCenter
{
    public class CollectContext
    {
        public static IList<GameDataModel> HttpGetResult(CollectConfigModel item, Action<GiftBaseData, bool> CallBack)
        {
            var gameList = new List<GameDataModel>();
            if (string.IsNullOrEmpty(item.Url))
            {
                return null;
            }

            var status = EnumHelper.GetDescription(item.GiftStatus);
            var giftType = EnumHelper.GetDescription(item.GiftType);
            var plateform = EnumHelper.GetDescription(item.GiftPlatForm);
            //处理分页问题
            var totalRegex = new Regex(ConstantHelper.TotalGifts);
            //获取总条数采集地址
            var requsetUrl = string.Format(item.Url, plateform, giftType, status);

            string totalResults = new HttpHleper().GetString(requsetUrl, "UTF-8");

            var totalCounts = totalRegex.Matches(totalResults);
            if (totalCounts.Count > 0)
            {
                item.Count = int.Parse(totalCounts[0].Value);
                item.Page = (item.Count + item.PageSize - 1) / item.PageSize;
            }

            for (int i = 1; i <= item.Count; i++)
            {
                //检测Url为空返回 
                string result = "";
                //result = await new HttpHleper().GetStringAsync(requsetUrl, "UTF-8");
                result = new HttpHleper().GetString(string.Concat(requsetUrl, string.Format("&p={0}", i)), "UTF-8");
                //result = new HttpHleper().GetHtml(requsetUrl, "", null, @"<table class=""newGifts"">", "</table>", false);
                //正则匹配数据
                var ScopeRegex = new Regex(ConstantHelper.ContentScopeRegx);
                var nameRegx = new Regex(ConstantHelper.NameRegx);
                var validateTimeRegex = new Regex(ConstantHelper.ValidateTimeRegx);
                var remainRegex = new Regex(ConstantHelper.RemainRegx);
                var urlRegex = new Regex(ConstantHelper.UrlRegx);

                //获取内容
                var searchMatchData = ScopeRegex.Matches(result);
                //int count = searchMatchData.Count;
                foreach (Match NextMatch in searchMatchData)
                {
                    var str = NextMatch.Value;
                    if (nameRegx.IsMatch(str))
                    {
                        var model = new GameDataModel();
                        try
                        {
                            model.PlateForm = plateform;
                            model.GiftType = item.GiftType;
                            model.GiftTypeName = giftType;
                            model.GiftStatus = item.GiftStatus;
                            model.GiftStatusName = status;
                            //1.匹配名称
                            var nameData = nameRegx.Matches(str);
                            if (nameData.Count > 0)
                            {
                                model.Name = nameData[0].Value;
                            }
                            //2.提取有效时间
                            var validateTimeData = validateTimeRegex.Matches(str);
                            if (validateTimeData.Count > 0)
                            {
                                model.ValidateTime = validateTimeData[0].Value;
                            }
                            //3.提取礼包剩余量
                            var remainData = remainRegex.Matches(str);
                            if (remainData.Count > 0)
                            {
                                model.Remain = remainData[0].Value;
                            }
                            //4.提取游戏抢包详细页面
                            var urlData = urlRegex.Matches(str);
                            if (urlData.Count > 0)
                            {
                                model.Url = urlData[0].Value;
                            }
                            if (!string.IsNullOrEmpty(model.Name))
                            {
                                gameList.Add(model);
                                GiftBaseData basedata = new GiftBaseData
                                {
                                    GiftName = model.Name,
                                    GiftStatus = model.GiftStatus.GetHashCode(),
                                    GiftStatusName = model.GiftStatusName,
                                    GiftType = model.GiftType.GetHashCode(),
                                    GiftTypeName = model.GiftTypeName,
                                    PlateForm = model.PlateForm,
                                    Remain = model.Remain,
                                    Url = model.Url,
                                    ValidateTime = model.ValidateTime
                                };
                                CallBack(basedata, false);
                            }
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
                }
            }

            return gameList;
        }
    }
}
