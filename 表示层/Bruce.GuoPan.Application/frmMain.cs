using Bruce.GuoPan.Application.Common;
using Bruce.GuoPan.Bll;
using Bruce.GuoPan.Core;
using Bruce.GuoPan.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace Bruce.GuoPan.Application
{
    public partial class frmMain : Form
    {
        private GiftBll _giftbll;
        private UserBll _userbll;
        private GiftUserBll _giftUserbll;
        public frmMain()
        {
            _giftbll = new GiftBll();
            _userbll = new UserBll();
            _giftUserbll = new GiftUserBll();
            InitializeComponent();
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;//设置该属性 为false
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var data = _giftbll.GetGiftDataByName(this.txtName.Text, ((System.Collections.Generic.KeyValuePair<string, string>)cbTypes.SelectedItem).Value);
            this.gdGift.DataSource = data;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //绑定下拉框数据
            var dics = EnumHelper.EnumToDict<EnumGiftType>();
            BindingSource bs = new BindingSource();
            bs.DataSource = dics;
            cbTypes.DataSource = bs;
            cbTypes.ValueMember = "Key";
            cbTypes.DisplayMember = "Value";
            //初始化用户数据
            RefreshUserGrid();
        }

        private void gdGift_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int CIndex = e.ColumnIndex;
            if (CIndex == 9)
            {
                //领取逻辑
            }
        }

        private void gdGift_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
               e.RowBounds.Location.Y,
               gdGift.RowHeadersWidth - 4,
               e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                gdGift.RowHeadersDefaultCellStyle.Font,
                rectangle,
                gdGift.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmUser frmMytest = new frmUser();
            frmMytest.onNotify += RefreshUserGrid;
            frmMytest.ShowDialog();
        }

        /// <summary>
        /// 刷新用户列表数据
        /// </summary>
        /// <param name="isRefresh"></param>
        private void RefreshUserGrid()
        {
            //1、获取用户数据；2、判断用户状态（缓存中取一下，试试刷新用户状态）
            var users = _userbll.GetUserInfo();
            if (users != null && users.Count > 0)
            {
                foreach (var item in users)
                {
                    var usercache = CacheHelper.GetCache(item.UserName);
                    if (usercache == null)
                    {
                        //设置用户下线
                        item.State = EnumState.IsOffline.GetHashCode();
                        item.StateName = EnumHelper.GetDescription(EnumState.IsOffline);
                        _userbll.UpdateUserInfo(item);
                    }
                    else
                    {
                        //设置用户下线
                        item.State = EnumState.IsLogined.GetHashCode();
                        item.StateName = EnumHelper.GetDescription(EnumState.IsLogined);
                        _userbll.UpdateUserInfo(item);
                    }
                }
                //重新绑定数据
                dgUser.DataSource = _userbll.GetUserInfo();
            }
        }

        private void dgUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int CIndex = e.ColumnIndex;
            if (CIndex == 1)
            {
                //登录逻辑
                DataGridViewCell dgcell = dgUser.Rows[e.RowIndex].Cells["UserName"];
                DataGridViewCell dgcell_pwd = dgUser.Rows[e.RowIndex].Cells["Pwd"];
                //
                var username = (string)dgcell.FormattedValue;
                var usrpwd = (string)dgcell_pwd.FormattedValue;
                if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(usrpwd))
                {
                    var userCookie = RequestContext.GetCookie(username, usrpwd);
                    //将用户信息添加到缓存中
                    CacheHelper.SetCache(username, userCookie, 20);
                    RefreshUserGrid();
                }
                else
                {
                    MessageBox.Show("登录失败！");
                }
            }
        }

        /// <summary>
        /// 双击选择游戏礼包到待选区
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gdGift_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int CIndex = e.ColumnIndex;
            DataGridViewCell dgcell = gdGift.Rows[e.RowIndex].Cells["Id"];
            DataGridViewCell dgcell_name = gdGift.Rows[e.RowIndex].Cells["GiftName"];
            DataGridViewCell dgcell_validateTime = gdGift.Rows[e.RowIndex].Cells["ValidateTime"];
            DataGridViewCell dgcell_remain = gdGift.Rows[e.RowIndex].Cells["Remain"];
            DataGridViewCell dgcell_url = gdGift.Rows[e.RowIndex].Cells["Url"];
            //判断是否需要添加
            int lvCount = lvlist.Items.Count;
            if (lvCount > 0)
            {
                foreach (ListViewItem item in lvlist.Items)
                {
                    var id = item.Text;
                    if (dgcell.FormattedValue.ToString() == id)
                    {
                        return;
                    }
                }
            }

            lvlist.GridLines = true;//表格是否显示网格线
            lvlist.FullRowSelect = true;//是否选中整行
            lvlist.View = View.Details;//设置显示方式
            lvlist.Scrollable = true;//是否自动显示滚动条
            lvlist.MultiSelect = false;//是否可以选择多行

            //添加表头（列）
            lvlist.Columns.Add("标识", 50, HorizontalAlignment.Center);
            lvlist.Columns.Add("名称", 250, HorizontalAlignment.Center);
            lvlist.Columns.Add("有效时间", 160, HorizontalAlignment.Center);
            lvlist.Columns.Add("礼包状态", 160, HorizontalAlignment.Center);
            lvlist.Columns.Add("地址", 160, HorizontalAlignment.Center);

            ListViewItem lt = new ListViewItem();
            lt.Text = dgcell.FormattedValue.ToString();
            lt.SubItems.Add(dgcell_name.FormattedValue.ToString());
            lt.SubItems.Add(dgcell_validateTime.FormattedValue.ToString());
            lt.SubItems.Add(dgcell_remain.FormattedValue.ToString());
            lt.SubItems.Add(dgcell_url.FormattedValue.ToString());
            lvlist.Items.Add(lt);
        }

        private void lvlist_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            lvlist.SelectedItems[0].Remove();
        }

        /// <summary>
        /// 开始采集
        /// 1、待采区是否有东西；
        /// 2、是否选择用户；
        /// 3、用户是否登录；
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_StartCollect_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvlist.Items.Count <= 0)
                {
                    MessageBox.Show("请在待采区添加游戏礼包");
                    return;
                }
                List<int> rows = new List<int>();
                //判断是否有选择的用户
                for (int i = 0; i < dgUser.Rows.Count; i++)
                {
                    //如果DataGridView是可编辑的，将数据提交，否则处于编辑状态的行无法取到  
                    dgUser.EndEdit();//如果此处的DateGridView只读，此处可以省略
                    DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)dgUser.Rows[i].Cells["请选择"];//Column_CheckBox为DateGridView中checkbox列的name
                    if (Convert.ToBoolean(checkCell.Value) == true)
                    {
                        //添加你的处理
                        //记住行号
                        rows.Add(i);
                    }
                }
                if (rows.Count <= 0)
                {
                    MessageBox.Show("请选择领取礼包的用户");
                    return;
                }
                //采集某一个用户
                foreach (var item in rows)
                {
                    DataGridViewCell dgcell_Id = dgUser.Rows[item].Cells["用户Id"];
                    DataGridViewCell dgcell_uname = dgUser.Rows[item].Cells["UserName"];
                    DataGridViewCell dgcell_pwd = dgUser.Rows[item].Cells["Pwd"];
                    DataGridViewCell dgcell_stateName = dgUser.Rows[item].Cells["状态"];
                    if (dgcell_stateName.FormattedValue.ToString() == "2")
                    {
                        MessageBox.Show("选择的用户没有在线，请先登录");
                        return;
                    }
                    //采集逻辑
                    var cookieUser = (CookieContainer)CacheHelper.GetCache(dgcell_uname.FormattedValue.ToString());
                    //获取所有待采集的数据
                    ThreadStart threadStart = delegate { CollectMethod(dgcell_Id, dgcell_uname, cookieUser); };
                    Thread thCollect = new Thread(threadStart);
                    thCollect.IsBackground = true;
                    thCollect.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CollectMethod(DataGridViewCell dgcell_Id, DataGridViewCell dgcell_uname, CookieContainer cookieUser)
        {
            foreach (ListViewItem view in lvlist.Items)
            {
                //每隔2S请求一次，防止页面禁止访问
                Thread.Sleep(500);
                var giftId = view.Text;
                var userCollectUrl = (view.SubItems[4]).Text;
                var newUrl = userCollectUrl.Substring(27);
                newUrl = newUrl.Substring(0, newUrl.LastIndexOf('_'));
                newUrl = string.Format(RequestContext.giftUrl, newUrl);
                var results = RequestContext.GetContent(cookieUser, newUrl);
                if (!string.IsNullOrEmpty(results))
                {
                    JavaScriptSerializer jss = new JavaScriptSerializer();
                    var resultobj = (Dictionary<string, object>)(jss.DeserializeObject(results));
                    //GiftResult model = SerializeHelper.FromJSON<GiftResult>(results);
                    //写入数据库
                    if (_giftUserbll.AddGiftUser(int.Parse(dgcell_Id.FormattedValue.ToString()),
                       int.Parse(giftId), newUrl, resultobj) > 0
                        )
                    {
                        //写入采集记录
                        SendNotify_Ex("用户:" + dgcell_uname.FormattedValue.ToString() + "  领取结果:" + resultobj.ToJSON());
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
                this.lbRecord.Items.Add(msg);
            }

        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            frmGiftData frmMytest = new frmGiftData();
            frmMytest.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dt = _giftUserbll.GetDataTable(@"
                    SELECT 
                          [UserName] AS '用户名'
                          ,[GiftName] AS '游戏名'
                          ,[Data] AS '结果'
                    FROM
                     UserGiftRecord
                    WHERE [Result]=0
            ");
            ExcelHelper.ExportToExcel(dt);
        }
    }
}
