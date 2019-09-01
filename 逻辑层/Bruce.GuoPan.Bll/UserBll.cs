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
    public class UserBll
    {
        readonly private NliteRepository<UserInfo> _userRespostitory;
        public UserBll()
        {
            _userRespostitory = new NliteRepository<UserInfo>();
        }

        public bool IsExist(string userName)
        {
            var list = _userRespostitory.GetList(m => m.UserName == userName);
            if (list != null && list.Count > 0)
            {
                return true;
            }
            return false;
        }

        public int AddUserInfo(string userName, string pwd)
        {
            UserInfo user = new UserInfo
            {
                UserName = userName,
                Pwd = pwd,
                State = EnumState.IsOffline.GetHashCode(),
                StateName = EnumHelper.GetDescription(EnumState.IsLogined)
            };
            return _userRespostitory.Insert(user);
        }

        public List<UserInfo> GetUserInfo()
        {
            return _userRespostitory.GetAll();
        }

        /// <summary>
        /// 更新用户状态
        /// </summary>
        /// <returns></returns>
        public void UpdateUserInfo(UserInfo info)
        {
             _userRespostitory.Update(info);
        }
    }
}
