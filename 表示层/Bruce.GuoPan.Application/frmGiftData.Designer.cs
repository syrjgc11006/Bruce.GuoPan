namespace Bruce.GuoPan.Application
{
    partial class frmGiftData
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
            this.dg_giftuserData = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_User = new System.Windows.Forms.TextBox();
            this.btn_search = new System.Windows.Forms.Button();
            this.btn_OutPut = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dg_giftuserData)).BeginInit();
            this.SuspendLayout();
            // 
            // dg_giftuserData
            // 
            this.dg_giftuserData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_giftuserData.Location = new System.Drawing.Point(12, 57);
            this.dg_giftuserData.Name = "dg_giftuserData";
            this.dg_giftuserData.RowTemplate.Height = 23;
            this.dg_giftuserData.Size = new System.Drawing.Size(826, 381);
            this.dg_giftuserData.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(110, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "用户名：";
            // 
            // txt_User
            // 
            this.txt_User.Location = new System.Drawing.Point(178, 22);
            this.txt_User.Name = "txt_User";
            this.txt_User.Size = new System.Drawing.Size(191, 21);
            this.txt_User.TabIndex = 2;
            // 
            // btn_search
            // 
            this.btn_search.Location = new System.Drawing.Point(424, 20);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(75, 23);
            this.btn_search.TabIndex = 3;
            this.btn_search.Text = "查询";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // btn_OutPut
            // 
            this.btn_OutPut.Location = new System.Drawing.Point(534, 20);
            this.btn_OutPut.Name = "btn_OutPut";
            this.btn_OutPut.Size = new System.Drawing.Size(105, 23);
            this.btn_OutPut.TabIndex = 4;
            this.btn_OutPut.Text = "导出领取结果";
            this.btn_OutPut.UseVisualStyleBackColor = true;
            this.btn_OutPut.Click += new System.EventHandler(this.btn_OutPut_Click);
            // 
            // frmGiftData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 441);
            this.Controls.Add(this.btn_OutPut);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.txt_User);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dg_giftuserData);
            this.Name = "frmGiftData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmGiftData";
            this.Load += new System.EventHandler(this.frmGiftData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg_giftuserData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dg_giftuserData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_User;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.Button btn_OutPut;
    }
}