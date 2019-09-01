using Bruce.GuoPan.Data;
using Bruce.GuoPan.DataDealWith.Model;
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
    public partial class EditGame : Form
    {
        public EditGame()
        {
            InitializeComponent();
        }

        private void 保存_Click(object sender, EventArgs e)
        {
            using (var context = new BruceContext("MasterDb"))
            {
                var selectItems = ((Bruce.GuoPan.DataDealWith.Model.C_Ticket)cb_platform.SelectedItem);
                var gametype_select = ((Bruce.GuoPan.DataDealWith.Model.C_TicketMethodGroup)cb_gametype.SelectedItem);
                var id = context.Set<C_TicketMethod>().Max(m => m.ID);
                C_TicketMethod method = new C_TicketMethod
                {
                    ID = id + 1,
                    Name = txtName.Text,
                    OutCode = txtOutCode.Text,
                    Memo = txtMomo.Text,
                    MethodGroupID = gametype_select.ID,
                    Order = 243,
                    GroupNum = 1,
                    AddUser = 1,
                    AddTime = DateTime.Now,
                    Enable = 1,
                    LastModifyTime = DateTime.Now,
                    LastModifyUser = 1
                };
                int data = context.Set<C_TicketMethod>().Insert(method);
                if (data > 0)
                {
                    MessageBox.Show("保存成功");
                }
            }
        }

        private void EditGame_Load(object sender, EventArgs e)
        {
            using (var context = new BruceContext("MasterDb"))
            {
                //初始化平台
                var tickets = context.Set<C_Ticket>().ToList();
                var ticket = tickets.FirstOrDefault();
                cb_platform.DataSource = tickets;
                cb_platform.ValueMember = nameof(ticket.ID);
                cb_platform.DisplayMember = nameof(ticket.Name);
            }
        }

        private void cb_platform_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectItems = ((Bruce.GuoPan.DataDealWith.Model.C_Ticket)cb_platform.SelectedItem);
            if (!string.IsNullOrEmpty(selectItems.Name.ToString()))
            {
                var ticketId = selectItems.ID;
                using (var context = new BruceContext("MasterDb"))
                {
                    var groups = context.Set<C_TicketMethodGroup>().Where(m => m.TicketID == ticketId).ToList();
                    if (groups.Count > 0)
                    {
                        var group = groups.FirstOrDefault();
                        cb_gametype.DataSource = groups;
                        cb_gametype.ValueMember = nameof(group.ID);
                        cb_gametype.DisplayMember = nameof(group.Name);
                    }
                }
            }
        }
    }
}
