using NLite.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bruce.GuoPan.Model
{
    [Serializable]
    [Table("UserInfo")]
    public class UserInfo : BaseEntity
    {
        /// <summary>
        /// 果盘账号  
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 密码  
        /// </summary>
        public string Pwd { get; set; }
        /// <summary>
        /// 状态  
        /// </summary>
        public int State { get; set; }

        /// <summary>
        /// 1、已登录；2、已离线
        /// </summary>
        public string StateName { get; set; }
    }
}
