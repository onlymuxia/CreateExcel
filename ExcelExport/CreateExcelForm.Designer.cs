namespace Onlymuxia.ExcelOperation
{
    partial class createExcelForm
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(createExcelForm));
            this.lbIn = new System.Windows.Forms.Label();
            this.lbout = new System.Windows.Forms.Label();
            this.btSave = new System.Windows.Forms.Button();
            this.tbIn = new System.Windows.Forms.TextBox();
            this.tbOut = new System.Windows.Forms.TextBox();
            this.btSelect = new System.Windows.Forms.Button();
            this.tbSave = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.tbInfo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbIn
            // 
            this.lbIn.AutoSize = true;
            this.lbIn.Location = new System.Drawing.Point(12, 19);
            this.lbIn.Name = "lbIn";
            this.lbIn.Size = new System.Drawing.Size(53, 12);
            this.lbIn.TabIndex = 0;
            this.lbIn.Text = "Text文件";
            // 
            // lbout
            // 
            this.lbout.AutoSize = true;
            this.lbout.Location = new System.Drawing.Point(12, 47);
            this.lbout.Name = "lbout";
            this.lbout.Size = new System.Drawing.Size(53, 12);
            this.lbout.TabIndex = 1;
            this.lbout.Text = "导出文件";
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(332, 85);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(89, 23);
            this.btSave.TabIndex = 2;
            this.btSave.Text = "转换";
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // tbIn
            // 
            this.tbIn.Location = new System.Drawing.Point(71, 16);
            this.tbIn.Name = "tbIn";
            this.tbIn.Size = new System.Drawing.Size(308, 21);
            this.tbIn.TabIndex = 3;
            this.tbIn.TextChanged += new System.EventHandler(this.tbIn_TextChanged);
            // 
            // tbOut
            // 
            this.tbOut.BackColor = System.Drawing.SystemColors.Window;
            this.tbOut.Location = new System.Drawing.Point(71, 46);
            this.tbOut.Name = "tbOut";
            this.tbOut.ReadOnly = true;
            this.tbOut.Size = new System.Drawing.Size(308, 21);
            this.tbOut.TabIndex = 4;
            // 
            // btSelect
            // 
            this.btSelect.Location = new System.Drawing.Point(385, 14);
            this.btSelect.Name = "btSelect";
            this.btSelect.Size = new System.Drawing.Size(60, 23);
            this.btSelect.TabIndex = 5;
            this.btSelect.Text = "File...";
            this.btSelect.Click += new System.EventHandler(this.btSelect_Click);
            // 
            // tbSave
            // 
            this.tbSave.Location = new System.Drawing.Point(385, 47);
            this.tbSave.Name = "tbSave";
            this.tbSave.Size = new System.Drawing.Size(60, 23);
            this.tbSave.TabIndex = 6;
            this.tbSave.Text = "File...";
            this.tbSave.UseVisualStyleBackColor = true;
            this.tbSave.Click += new System.EventHandler(this.tbSave_Click);
            // 
            // tbInfo
            // 
            this.tbInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbInfo.Location = new System.Drawing.Point(14, 85);
            this.tbInfo.Multiline = true;
            this.tbInfo.Name = "tbInfo";
            this.tbInfo.ReadOnly = true;
            this.tbInfo.Size = new System.Drawing.Size(301, 23);
            this.tbInfo.TabIndex = 7;
            // 
            // createExcelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 120);
            this.Controls.Add(this.tbInfo);
            this.Controls.Add(this.tbSave);
            this.Controls.Add(this.btSelect);
            this.Controls.Add(this.tbOut);
            this.Controls.Add(this.tbIn);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.lbout);
            this.Controls.Add(this.lbIn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "createExcelForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Excel生成器";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbIn;
        private System.Windows.Forms.Label lbout;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.TextBox tbIn;
        private System.Windows.Forms.TextBox tbOut;
        private System.Windows.Forms.Button btSelect;
        private System.Windows.Forms.Button tbSave;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.TextBox tbInfo;
    }
}

