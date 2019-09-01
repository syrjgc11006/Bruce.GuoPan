namespace Bruce.GuoPan.Application
{
    partial class frmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lvlist = new System.Windows.Forms.ListView();
            this.cbTypes = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.gdGift = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiftStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiftType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiftName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlateForm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValidateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remain = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiftStatusName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiftTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Url = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_Collect = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.dgUser = new System.Windows.Forms.DataGridView();
            this.请选择 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.GridBtn_Login = new System.Windows.Forms.DataGridViewButtonColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.用户Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.状态 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pwd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_Search = new System.Windows.Forms.Button();
            this.lbRecord = new System.Windows.Forms.ListBox();
            this.btn_StartCollect = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdGift)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgUser)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.cbTypes);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.gdGift);
            this.groupBox1.Location = new System.Drawing.Point(12, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(642, 682);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询区";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(267, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "类型：";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lvlist);
            this.groupBox3.Location = new System.Drawing.Point(6, 416);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(630, 266);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "待采集区";
            // 
            // lvlist
            // 
            this.lvlist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvlist.Location = new System.Drawing.Point(3, 17);
            this.lvlist.Name = "lvlist";
            this.lvlist.Size = new System.Drawing.Size(624, 246);
            this.lvlist.TabIndex = 0;
            this.lvlist.UseCompatibleStateImageBehavior = false;
            this.lvlist.View = System.Windows.Forms.View.Details;
            this.lvlist.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvlist_MouseDoubleClick);
            // 
            // cbTypes
            // 
            this.cbTypes.FormattingEnabled = true;
            this.cbTypes.Location = new System.Drawing.Point(315, 22);
            this.cbTypes.Name = "cbTypes";
            this.cbTypes.Size = new System.Drawing.Size(121, 20);
            this.cbTypes.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "名称：";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(452, 20);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "搜索";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(88, 19);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(154, 21);
            this.txtName.TabIndex = 1;
            // 
            // gdGift
            // 
            this.gdGift.AllowUserToAddRows = false;
            this.gdGift.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gdGift.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.GiftStatus,
            this.GiftType,
            this.GiftName,
            this.PlateForm,
            this.ValidateTime,
            this.Remain,
            this.GiftStatusName,
            this.GiftTypeName,
            this.Url,
            this.btn_Collect});
            this.gdGift.Location = new System.Drawing.Point(6, 49);
            this.gdGift.Name = "gdGift";
            this.gdGift.RowTemplate.Height = 23;
            this.gdGift.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gdGift.Size = new System.Drawing.Size(630, 361);
            this.gdGift.TabIndex = 0;
            this.gdGift.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gdGift_CellContentClick);
            this.gdGift.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gdGift_CellDoubleClick);
            this.gdGift.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.gdGift_RowPostPaint);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // GiftStatus
            // 
            this.GiftStatus.DataPropertyName = "GiftStatus";
            this.GiftStatus.HeaderText = "GiftStatus";
            this.GiftStatus.Name = "GiftStatus";
            this.GiftStatus.Visible = false;
            // 
            // GiftType
            // 
            this.GiftType.DataPropertyName = "GiftType";
            this.GiftType.HeaderText = "GiftType";
            this.GiftType.Name = "GiftType";
            this.GiftType.Visible = false;
            // 
            // GiftName
            // 
            this.GiftName.DataPropertyName = "GiftName";
            this.GiftName.HeaderText = "名称";
            this.GiftName.Name = "GiftName";
            // 
            // PlateForm
            // 
            this.PlateForm.DataPropertyName = "PlateForm";
            this.PlateForm.HeaderText = "平台";
            this.PlateForm.Name = "PlateForm";
            this.PlateForm.Visible = false;
            // 
            // ValidateTime
            // 
            this.ValidateTime.DataPropertyName = "ValidateTime";
            this.ValidateTime.HeaderText = "有效时间";
            this.ValidateTime.Name = "ValidateTime";
            this.ValidateTime.Visible = false;
            // 
            // Remain
            // 
            this.Remain.DataPropertyName = "Remain";
            this.Remain.HeaderText = "礼包状态";
            this.Remain.Name = "Remain";
            // 
            // GiftStatusName
            // 
            this.GiftStatusName.DataPropertyName = "GiftStatusName";
            this.GiftStatusName.HeaderText = "状态";
            this.GiftStatusName.Name = "GiftStatusName";
            // 
            // GiftTypeName
            // 
            this.GiftTypeName.DataPropertyName = "GiftTypeName";
            this.GiftTypeName.HeaderText = "类型";
            this.GiftTypeName.Name = "GiftTypeName";
            // 
            // Url
            // 
            this.Url.DataPropertyName = "Url";
            this.Url.HeaderText = "明细地址";
            this.Url.Name = "Url";
            this.Url.Visible = false;
            // 
            // btn_Collect
            // 
            this.btn_Collect.HeaderText = "操作";
            this.btn_Collect.Name = "btn_Collect";
            this.btn_Collect.Text = "领取";
            this.btn_Collect.UseColumnTextForButtonValue = true;
            this.btn_Collect.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAddUser);
            this.groupBox2.Controls.Add(this.dgUser);
            this.groupBox2.Location = new System.Drawing.Point(660, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(698, 280);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "用户区";
            // 
            // btnAddUser
            // 
            this.btnAddUser.Location = new System.Drawing.Point(11, 19);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(75, 23);
            this.btnAddUser.TabIndex = 1;
            this.btnAddUser.Text = "新增";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // dgUser
            // 
            this.dgUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgUser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.请选择,
            this.GridBtn_Login,
            this.UserName,
            this.Status,
            this.用户Id,
            this.状态,
            this.Pwd});
            this.dgUser.Location = new System.Drawing.Point(6, 48);
            this.dgUser.Name = "dgUser";
            this.dgUser.RowTemplate.Height = 23;
            this.dgUser.Size = new System.Drawing.Size(686, 223);
            this.dgUser.TabIndex = 0;
            this.dgUser.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgUser_CellContentClick);
            // 
            // 请选择
            // 
            this.请选择.HeaderText = "选择";
            this.请选择.Name = "请选择";
            // 
            // GridBtn_Login
            // 
            this.GridBtn_Login.HeaderText = "登录";
            this.GridBtn_Login.Name = "GridBtn_Login";
            this.GridBtn_Login.Text = "请登录";
            this.GridBtn_Login.UseColumnTextForButtonValue = true;
            // 
            // UserName
            // 
            this.UserName.DataPropertyName = "UserName";
            this.UserName.HeaderText = "账号";
            this.UserName.Name = "UserName";
            // 
            // Status
            // 
            this.Status.DataPropertyName = "StateName";
            this.Status.HeaderText = "状态";
            this.Status.Name = "Status";
            // 
            // 用户Id
            // 
            this.用户Id.DataPropertyName = "Id";
            this.用户Id.HeaderText = "用户Id";
            this.用户Id.Name = "用户Id";
            this.用户Id.Visible = false;
            // 
            // 状态
            // 
            this.状态.DataPropertyName = "State";
            this.状态.HeaderText = "状态";
            this.状态.Name = "状态";
            this.状态.Visible = false;
            // 
            // Pwd
            // 
            this.Pwd.DataPropertyName = "Pwd";
            this.Pwd.HeaderText = "密码";
            this.Pwd.Name = "Pwd";
            this.Pwd.Visible = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button1);
            this.groupBox4.Controls.Add(this.btn_Search);
            this.groupBox4.Controls.Add(this.lbRecord);
            this.groupBox4.Controls.Add(this.btn_StartCollect);
            this.groupBox4.Location = new System.Drawing.Point(660, 289);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(698, 396);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "采集区";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(358, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 31);
            this.button1.TabIndex = 3;
            this.button1.Text = "导出领取结果";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_Search
            // 
            this.btn_Search.Location = new System.Drawing.Point(225, 17);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(89, 30);
            this.btn_Search.TabIndex = 2;
            this.btn_Search.Text = "查看领取结果";
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // lbRecord
            // 
            this.lbRecord.FormattingEnabled = true;
            this.lbRecord.ItemHeight = 12;
            this.lbRecord.Location = new System.Drawing.Point(11, 54);
            this.lbRecord.Name = "lbRecord";
            this.lbRecord.Size = new System.Drawing.Size(687, 340);
            this.lbRecord.TabIndex = 1;
            // 
            // btn_StartCollect
            // 
            this.btn_StartCollect.Location = new System.Drawing.Point(82, 17);
            this.btn_StartCollect.Name = "btn_StartCollect";
            this.btn_StartCollect.Size = new System.Drawing.Size(88, 30);
            this.btn_StartCollect.TabIndex = 0;
            this.btn_StartCollect.Text = "开始领取";
            this.btn_StartCollect.UseVisualStyleBackColor = true;
            this.btn_StartCollect.Click += new System.EventHandler(this.btn_StartCollect_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 697);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmMain";
            this.Text = "主界面";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gdGift)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgUser)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView gdGift;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbTypes;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgUser;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridViewCheckBoxColumn 请选择;
        private System.Windows.Forms.DataGridViewButtonColumn GridBtn_Login;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn 用户Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn 状态;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pwd;
        private System.Windows.Forms.ListView lvlist;
        private System.Windows.Forms.Button btn_StartCollect;
        private System.Windows.Forms.ListBox lbRecord;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiftStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiftType;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiftName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlateForm;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValidateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remain;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiftStatusName;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiftTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Url;
        private System.Windows.Forms.DataGridViewButtonColumn btn_Collect;
    }
}

