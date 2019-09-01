using NLite.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bruce.GuoPan.Model
{
    /// <summary>
    /// UserGiftRecord:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    [Table("UserGiftRecord")]
    public partial class UserGiftRecord:BaseEntity
    {
        public UserGiftRecord()
        { }
        #region Model
        private int _userid;
        private int _giftid;
        private string _username;
        private string _giftname;
        private string _gifttypename;
        private string _giftstatuname;
        private string _platname;
        private string _collecturl;
        private string _result;
        private string _msg;
        private string _data;
        /// <summary>
        /// 
        /// </summary>
        public int UserId
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int GiftId
        {
            set { _giftid = value; }
            get { return _giftid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GiftName
        {
            set { _giftname = value; }
            get { return _giftname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GiftTypeName
        {
            set { _gifttypename = value; }
            get { return _gifttypename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GiftStatuName
        {
            set { _giftstatuname = value; }
            get { return _giftstatuname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PlatName
        {
            set { _platname = value; }
            get { return _platname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CollectUrl
        {
            set { _collecturl = value; }
            get { return _collecturl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Result
        {
            set { _result = value; }
            get { return _result; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Msg
        {
            set { _msg = value; }
            get { return _msg; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Data
        {
            set { _data = value; }
            get { return _data; }
        }
        #endregion Model

    }
}

