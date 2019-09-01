namespace Bruce.GuoPan.DataCenter
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
            this.btnColletct = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lsbInfo = new System.Windows.Forms.ListBox();
            this.btnCollectOthers = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnColletct
            // 
            this.btnColletct.Location = new System.Drawing.Point(53, 12);
            this.btnColletct.Name = "btnColletct";
            this.btnColletct.Size = new System.Drawing.Size(110, 23);
            this.btnColletct.TabIndex = 0;
            this.btnColletct.Text = "按分类开始采集";
            this.btnColletct.UseVisualStyleBackColor = true;
            this.btnColletct.Click += new System.EventHandler(this.btnColletct_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lsbInfo);
            this.groupBox1.Location = new System.Drawing.Point(12, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(427, 464);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "采集信息";
            // 
            // lsbInfo
            // 
            this.lsbInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsbInfo.FormattingEnabled = true;
            this.lsbInfo.ItemHeight = 12;
            this.lsbInfo.Location = new System.Drawing.Point(3, 17);
            this.lsbInfo.Name = "lsbInfo";
            this.lsbInfo.Size = new System.Drawing.Size(421, 444);
            this.lsbInfo.TabIndex = 0;
            // 
            // btnCollectOthers
            // 
            this.btnCollectOthers.Location = new System.Drawing.Point(212, 12);
            this.btnCollectOthers.Name = "btnCollectOthers";
            this.btnCollectOthers.Size = new System.Drawing.Size(137, 23);
            this.btnCollectOthers.TabIndex = 2;
            this.btnCollectOthers.Text = "采集分类之外的其他";
            this.btnCollectOthers.UseVisualStyleBackColor = true;
            this.btnCollectOthers.Click += new System.EventHandler(this.btnCollectOthers_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 517);
            this.Controls.Add(this.btnCollectOthers);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnColletct);
            this.Name = "frmMain";
            this.Text = "采集器";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnColletct;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lsbInfo;
        private System.Windows.Forms.Button btnCollectOthers;
    }
}

