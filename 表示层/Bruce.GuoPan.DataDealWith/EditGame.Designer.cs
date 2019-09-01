namespace Bruce.GuoPan.DataDealWith
{
    partial class EditGame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtOutCode = new System.Windows.Forms.TextBox();
            this.txtMomo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_gametype = new System.Windows.Forms.ComboBox();
            this.cb_platform = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(246, 55);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 21);
            this.txtName.TabIndex = 0;
            // 
            // txtOutCode
            // 
            this.txtOutCode.Location = new System.Drawing.Point(246, 297);
            this.txtOutCode.Name = "txtOutCode";
            this.txtOutCode.Size = new System.Drawing.Size(100, 21);
            this.txtOutCode.TabIndex = 0;
            // 
            // txtMomo
            // 
            this.txtMomo.Location = new System.Drawing.Point(246, 123);
            this.txtMomo.Name = "txtMomo";
            this.txtMomo.Size = new System.Drawing.Size(100, 21);
            this.txtMomo.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(183, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "名称";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(183, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mono";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(183, 300);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "OutCode";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(212, 351);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.保存_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(183, 249);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "游戏分类";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(183, 198);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "游戏平台";
            // 
            // cb_gametype
            // 
            this.cb_gametype.FormattingEnabled = true;
            this.cb_gametype.Location = new System.Drawing.Point(250, 242);
            this.cb_gametype.Name = "cb_gametype";
            this.cb_gametype.Size = new System.Drawing.Size(121, 20);
            this.cb_gametype.TabIndex = 4;
            // 
            // cb_platform
            // 
            this.cb_platform.FormattingEnabled = true;
            this.cb_platform.Location = new System.Drawing.Point(242, 195);
            this.cb_platform.Name = "cb_platform";
            this.cb_platform.Size = new System.Drawing.Size(121, 20);
            this.cb_platform.TabIndex = 5;
            this.cb_platform.SelectedIndexChanged += new System.EventHandler(this.cb_platform_SelectedIndexChanged);
            // 
            // EditGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 443);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cb_gametype);
            this.Controls.Add(this.cb_platform);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMomo);
            this.Controls.Add(this.txtOutCode);
            this.Controls.Add(this.txtName);
            this.Name = "EditGame";
            this.Text = "EditGame";
            this.Load += new System.EventHandler(this.EditGame_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtOutCode;
        private System.Windows.Forms.TextBox txtMomo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cb_gametype;
        private System.Windows.Forms.ComboBox cb_platform;
    }
}