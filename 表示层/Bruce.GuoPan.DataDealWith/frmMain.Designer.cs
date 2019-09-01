namespace Bruce.GuoPan.DataDealWith
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
            this.dg_game = new System.Windows.Forms.DataGridView();
            this.cb_platform = new System.Windows.Forms.ComboBox();
            this.cb_gametype = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Search = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dg_game)).BeginInit();
            this.SuspendLayout();
            // 
            // dg_game
            // 
            this.dg_game.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_game.Location = new System.Drawing.Point(12, 63);
            this.dg_game.Name = "dg_game";
            this.dg_game.RowTemplate.Height = 23;
            this.dg_game.Size = new System.Drawing.Size(826, 403);
            this.dg_game.TabIndex = 0;
            // 
            // cb_platform
            // 
            this.cb_platform.FormattingEnabled = true;
            this.cb_platform.Location = new System.Drawing.Point(115, 22);
            this.cb_platform.Name = "cb_platform";
            this.cb_platform.Size = new System.Drawing.Size(121, 20);
            this.cb_platform.TabIndex = 1;
            this.cb_platform.SelectedIndexChanged += new System.EventHandler(this.cb_platform_SelectedIndexChanged);
            // 
            // cb_gametype
            // 
            this.cb_gametype.FormattingEnabled = true;
            this.cb_gametype.Location = new System.Drawing.Point(390, 22);
            this.cb_gametype.Name = "cb_gametype";
            this.cb_gametype.Size = new System.Drawing.Size(121, 20);
            this.cb_gametype.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "游戏平台";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(323, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "游戏分类";
            // 
            // btn_Search
            // 
            this.btn_Search.Location = new System.Drawing.Point(579, 20);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(75, 23);
            this.btn_Search.TabIndex = 4;
            this.btn_Search.Text = "查询";
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(680, 20);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(75, 23);
            this.btn_add.TabIndex = 5;
            this.btn_add.Text = "新增";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 468);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.btn_Search);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_gametype);
            this.Controls.Add(this.cb_platform);
            this.Controls.Add(this.dg_game);
            this.Name = "frmMain";
            this.Text = "主页";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg_game)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dg_game;
        private System.Windows.Forms.ComboBox cb_platform;
        private System.Windows.Forms.ComboBox cb_gametype;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.Button btn_add;
    }
}

