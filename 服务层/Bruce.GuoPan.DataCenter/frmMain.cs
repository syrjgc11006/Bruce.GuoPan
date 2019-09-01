using Bruce.GuoPan.Bll;
using Bruce.GuoPan.DataCenter.Common;
using Bruce.GuoPan.Model;
using Bruce.GuoPan.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bruce.GuoPan.DataCenter
{
    public partial class frmMain : Form
    {
        private GiftBll _giftbll;

        private List<CollectConfigModel> configList = new List<CollectConfigModel> {
                new CollectConfigModel { GiftPlatForm = Core.EnumGiftPlatForm.Android,
                GiftStatus = Core.EnumGiftState.LH,
                GiftType = Core.EnumGiftType.TQLB,
                Url = ConstantHelper.android_searchUrl },
                 new CollectConfigModel { GiftPlatForm = Core.EnumGiftPlatForm.Android,
                GiftStatus = Core.EnumGiftState.LH,
                GiftType = Core.EnumGiftType.DJLB,
                Url = ConstantHelper.android_searchUrl },
                new CollectConfigModel { GiftPlatForm = Core.EnumGiftPlatForm.Android,
                GiftStatus = Core.EnumGiftState.LH,
                GiftType = Core.EnumGiftType.XSLB,
                Url = ConstantHelper.android_searchUrl },
                new CollectConfigModel { GiftPlatForm = Core.EnumGiftPlatForm.Android,
                GiftStatus = Core.EnumGiftState.LH,
                GiftType = Core.EnumGiftType.XFLB,
                Url = ConstantHelper.android_searchUrl },
                  new CollectConfigModel { GiftPlatForm = Core.EnumGiftPlatForm.Android,
                GiftStatus = Core.EnumGiftState.LH,
                GiftType = Core.EnumGiftType.GHLB,
                Url = ConstantHelper.android_searchUrl }
            };
        public frmMain()
        {
            InitializeComponent();
            _giftbll = new GiftBll();
        }

        private void btnColletct_Click(object sender, EventArgs e)
        {
            btnCollectOthers.Enabled = false;
            btnColletct.Enabled = false;
            foreach (var ticketData in configList)
            {
                ThreadStart threadStart = delegate { StartCollectAsync(ticketData, SendNotify); };
                Thread thCollect = new Thread(threadStart);
                thCollect.IsBackground = true;
                thCollect.Start();
            }
            this.lsbInfo.Items.Add("同步结束:" + "当前时间:" + DateTime.Now.ToString());
            //btnColletct.Enabled = true;
        }

        private void SendNotify(GiftBaseData model, bool state)
        {
            if (model != null)
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action<GiftBaseData, bool>((p, q) => { SendNotify(p, q); }), model, state);
                }
                else
                {
                    if (state)
                    {
                        this.lsbInfo.Items.Add(model.GiftTypeName + " 同步结束:" + "当前时间:" + DateTime.Now.ToString());
                    }
                    else
                    {
                        this.lsbInfo.Items.Add("礼包分类：" + model.GiftTypeName + "  礼包名称:" + model.GiftName + "剩余:" + model.Remain);
                    }
                }
            }
        }

        private void SendNotify_Ex(string msg)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<string>((p) => { SendNotify_Ex(p); }), msg);
            }
            else
            {
                this.lsbInfo.Items.Add(msg);
            }

        }

        /// <summary>
        /// 异步采集普通赛事
        /// </summary> 
        /// <param name="ticketData">彩票文件</param>
        public void StartCollectAsync(CollectConfigModel ticketData, Action<GiftBaseData, bool> CallBack)
        {
            BuildCollectTask(ticketData, CallBack);
            //及时请求最新一期的开奖结果，每15秒执行一次，低频每三分钟一次
            //Task.Run(async () =>
            //{
            //    //创建Task列表,添加延时任务 
            //    while (true)
            //    {
            //        //间隔时间 
            //        int delayTime = 180 * 1000;
            //        var tasks = new List<Task>();
            //        tasks.AddRange(BuildCollectTask(ticketData));
            //        await Task.WhenAll(tasks);
            //        await Task.Delay(delayTime);
            //    }
            //});
        }

        private void BuildCollectTask(CollectConfigModel model, Action<GiftBaseData, bool> CallBack)
        {
            TickectCollectAsync(model, CallBack);

            //var tasks = new List<Task>();
            //if (model != null)
            //{
            //    tasks.Add(TickectCollectAsync(model));
            //}
            //return tasks;
        }

        /// <summary>
        /// 进行异步采集操作
        /// </summary>s
        /// <returns></returns>
        private bool TickectCollectAsync(CollectConfigModel model, Action<GiftBaseData, bool> CallBack)
        {
            if (DayCollectAsync(model, CallBack))
            {
                return true;
            }

            return false;
        }



        private bool DayCollectAsync(CollectConfigModel model, Action<GiftBaseData, bool> CallBack)
        {
            bool isSucceed = false;
            var startTime = DateTime.Now;
            IList<GameDataModel> data = null;
            try
            {
                SendNotify_Ex("采集开始……");
                data = CollectContext.HttpGetResult(model, CallBack);
                SendNotify_Ex("采集结束，开始同步数据……");
                if (data != null && data.Count > 0)
                {
                    int i = 0;
                    foreach (var item in data)
                    {
                        i++;
                        GiftBaseData basedata = new GiftBaseData
                        {
                            GiftName = item.Name,
                            GiftStatus = item.GiftStatus.GetHashCode(),
                            GiftStatusName = item.GiftStatusName,
                            GiftType = item.GiftType.GetHashCode(),
                            GiftTypeName = item.GiftTypeName,
                            PlateForm = item.PlateForm,
                            Remain = item.Remain,
                            Url = item.Url,
                            ValidateTime = item.ValidateTime
                        };
                        isSucceed = _giftbll.AddandUpdateGift(basedata) > 0;
                        if (isSucceed)
                        {
                            if (i == data.Count)
                            {
                                CallBack(basedata, true);
                            }
                            CallBack(basedata, false);
                        }
                    }
                }
                return isSucceed;
            }
            catch (Exception)
            {
                throw;
            }
        }


        private bool All_DayCollectAsync(CollectConfigModel model, Action<GiftBaseData, bool> CallBack)
        {
            bool isSucceed = false;
            var startTime = DateTime.Now;
            IList<GameDataModel> data = null;
            try
            {
                SendNotify_Ex("采集开始……");
                data = CollectContext.HttpGetResult(model, CallBack);
                SendNotify_Ex("采集结束，开始同步数据……");
                if (data != null && data.Count > 0)
                {
                    int i = 0;
                    foreach (var item in data)
                    {
                        i++;
                        GiftBaseData basedata = new GiftBaseData
                        {
                            GiftName = item.Name,
                            GiftStatus = item.GiftStatus.GetHashCode(),
                            GiftStatusName = item.GiftStatusName,
                            GiftType = item.GiftType.GetHashCode(),
                            GiftTypeName = item.GiftTypeName,
                            PlateForm = item.PlateForm,
                            Remain = item.Remain,
                            Url = item.Url,
                            ValidateTime = item.ValidateTime
                        };
                        isSucceed = _giftbll.AddandUpdateGift_All(basedata) > 0;
                        if (isSucceed)
                        {
                            if (i == data.Count)
                            {
                                CallBack(basedata, true);
                            }
                            CallBack(basedata, false);
                        }
                    }
                }
                return isSucceed;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnCollectOthers_Click(object sender, EventArgs e)
        {
            btnCollectOthers.Enabled = false;
            btnColletct.Enabled = false;
            ThreadStart threadStart = delegate
            {
                All_DayCollectAsync(new CollectConfigModel
                {
                    GiftPlatForm = Core.EnumGiftPlatForm.Android,
                    GiftStatus = Core.EnumGiftState.LH,
                    GiftType = Core.EnumGiftType.ALL,
                    Url = ConstantHelper.android_searchUrl
                }, SendNotify);
                btnCollectOthers.Enabled = false;
            };
            Thread thCollect = new Thread(threadStart);
            thCollect.IsBackground = true;
            thCollect.Start();
        }
    }
}
