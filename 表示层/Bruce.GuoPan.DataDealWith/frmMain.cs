using Bruce.GuoPan.Data;
using Bruce.GuoPan.DataDealWith.Model;
using Bruce.GuoPan.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bruce.GuoPan.DataDealWith
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            using (var context = new BruceContext("MasterDb"))
            {
                //初始化平台
                var tickets = context.Set<C_Ticket>().ToList();
                var ticket = tickets.FirstOrDefault();
                cb_platform.DataSource = tickets;
                cb_platform.ValueMember = nameof(ticket.ID);
                cb_platform.DisplayMember = nameof(ticket.Name);

                var data = context.Set<V_GameMethod>();
                dg_game.DataSource = data.ToList();
            }
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            var selectItems = ((Bruce.GuoPan.DataDealWith.Model.C_Ticket)cb_platform.SelectedItem);
            var gametype_select = ((Bruce.GuoPan.DataDealWith.Model.C_TicketMethodGroup)cb_gametype.SelectedItem);
            using (var context = new BruceContext("MasterDb"))
            {
                var data = context.Set<V_GameMethod>().Where(m=>m.TicketId==selectItems.ID&&m.MethodGroupID==gametype_select.ID);
                dg_game.DataSource = data.ToList();
            }
        }

        /// <summary>
        /// 改变时查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cb_platform_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(cb_platform.SelectedItem.ToString());
            //MessageBox.Show(cb_platform.SelectedText.ToString());
            //MessageBox.Show(cb_platform.SelectedValue.ToString());
            //MessageBox.Show(cb_platform.SelectedIndex.ToString());
            var selectItems= ((Bruce.GuoPan.DataDealWith.Model.C_Ticket)cb_platform.SelectedItem);
            if (!string.IsNullOrEmpty(selectItems.Name.ToString()))
            {
                var ticketId = selectItems.ID;
                using (var context = new BruceContext("MasterDb"))
                {
                    var groups=  context.Set<C_TicketMethodGroup>().Where(m => m.TicketID == ticketId).ToList();
                    if (groups.Count>0)
                    {
                        var group = groups.FirstOrDefault();
                        cb_gametype.DataSource = groups;
                        cb_gametype.ValueMember = nameof(group.ID);
                        cb_gametype.DisplayMember = nameof(group.Name);
                    }
                }
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            EditGame game = new EditGame();
            game.ShowDialog();
        }
    }
}
