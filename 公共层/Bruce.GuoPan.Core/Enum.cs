using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bruce.GuoPan.Core
{
    public enum EnumGiftPlatForm
    {
        [Description("全部")]
        ALL = 0,
        [Description("安卓")]
        Android = 1,
        [Description("苹果")]
        Apple = 2
    }

    public enum EnumGiftType
    {
        [Description("全部")]
        ALL = 0,
        [Description("特权礼包")]
        TQLB = 1,
        [Description("独家礼包")]
        DJLB = 2,
        [Description("新手礼包")]
        XSLB = 3,
        [Description("新服礼包")]
        XFLB = 4,
        [Description("公会礼包")]
        GHLB = 5
    }

    public enum EnumGiftState
    {
        [Description("全部")]
        ALL = 0,
        [Description("领号")]
        LH = 1,
        [Description("淘号")]
        TH = 2,
        [Description("预号")]
        YH = 3
    }

    /// <summary>
    /// 用户状态
    /// </summary>
    public enum EnumState
    {
        [Description("在线")]
        IsLogined = 1,
        [Description("离线")]
        IsOffline = 2
    }
}
