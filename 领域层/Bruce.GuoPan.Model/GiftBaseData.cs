using NLite.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bruce.GuoPan.Model
{

    /// <summary>
    /// 礼品基础数据
    /// </summary>
    [Serializable]
    [Table("GiftBaseData")]
    public partial class GiftBaseData : BaseEntity
    {
        public GiftBaseData()
        { }
        #region Model
        private string _giftname;
        private string _plateform;
        private string _validatetime;
        private string _remain;
        private int _giftstatus;
        private string _giftstatusname;
        private int _gifttype;
        private string _gifttypename;
        private string _url;
        /// <summary>
        /// 礼包名称
        /// </summary>
        public string GiftName
        {
            set { _giftname = value; }
            get { return _giftname; }
        }
        /// <summary>
        /// 平台
        /// </summary>
        public string PlateForm
        {
            set { _plateform = value; }
            get { return _plateform; }
        }
        /// <summary>
        /// 有效时间
        /// </summary>
        public string ValidateTime
        {
            set { _validatetime = value; }
            get { return _validatetime; }
        }
        /// <summary>
        /// 礼品还剩多少
        /// </summary>
        public string Remain
        {
            set { _remain = value; }
            get { return _remain; }
        }
        /// <summary>
        /// 礼包状态（0：全部；1:、领号；2、淘号；3、预号）
        /// </summary>
        public int GiftStatus
        {
            set { _giftstatus = value; }
            get { return _giftstatus; }
        }
        /// <summary>
        /// 礼包状态名称
        /// </summary>
        public string GiftStatusName
        {
            set { _giftstatusname = value; }
            get { return _giftstatusname; }
        }
        /// <summary>
        /// 礼包类别（0：全部；1、特权礼包；2、独家礼包；3、新手礼包；4、新服礼包；5、公会礼包）
        /// </summary>
        public int GiftType
        {
            set { _gifttype = value; }
            get { return _gifttype; }
        }
        /// <summary>
        /// 礼包类别名称
        /// </summary>
        public string GiftTypeName
        {
            set { _gifttypename = value; }
            get { return _gifttypename; }
        }
        /// <summary>
        /// 领包地址
        /// </summary>
        public string Url
        {
            set { _url = value; }
            get { return _url; }
        }
        #endregion Model
    }
}
