using Bruce.GuoPan.Application.Common;
using Bruce.GuoPan.Bll;
using Bruce.GuoPan.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bruce.GuoPan.Application
{
    public partial class frmUser : Form
    {
        private readonly UserBll _userbll;

        public Action onNotify { get; set; }

        public frmUser()
        {
            _userbll = new UserBll();
            InitializeComponent();
        }

        private void btn_UserAdd_Click(object sender, EventArgs e)
        {
            var userName = this.txtUser.Text;
            var userPwd = this.txtPwd.Text;
            if (string.IsNullOrEmpty(userName))
            {
                MessageBox.Show("用户名不能为空");
                return;
            }
            if (string.IsNullOrEmpty(userPwd))
            {
                MessageBox.Show("密码不能为空");
                return;
            }
            //校验账户是否存在于果盘
            var token = RequestContext.getToken(userName);
            if (token == "0")
            {
                MessageBox.Show("用户不存在于果盘不能添加");
                return;
            }
            //校验数据库中是否存在
            if (_userbll.IsExist(userName))
            {
                MessageBox.Show("用户已经存在");
                return;
            }
            if (_userbll.AddUserInfo(userName, userPwd) > 0)
            {
                var userCookie = RequestContext.GetCookie(userName, userPwd);
                //将用户信息添加到缓存中
                CacheHelper.SetCache(userName, userCookie, 20);
                MessageBox.Show("添加成功！");
                //回调刷新一下主界面用户列表
                if (onNotify != null)
                {
                    onNotify();
                }
            }
            else
            {
                MessageBox.Show("添加失败！");
            }
        }
    }
}
