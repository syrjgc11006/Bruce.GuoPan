using Bruce.GuoPan.Application.Common;
using Bruce.GuoPan.Bll;
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
    public partial class frmGiftData : Form
    {
        private GiftUserBll _giftUserbll;
        public frmGiftData()
        {
            _giftUserbll = new GiftUserBll();
            InitializeComponent();
        }

        private void frmGiftData_Load(object sender, EventArgs e)
        {
            this.dg_giftuserData.DataSource = _giftUserbll.GetAll();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            var username = txt_User.Text;
            this.dg_giftuserData.DataSource = _giftUserbll.GetList(m => m.UserName == username);
        }

        private void btn_OutPut_Click(object sender, EventArgs e)
        {
           var dt  =_giftUserbll.GetDataTable(@"
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
