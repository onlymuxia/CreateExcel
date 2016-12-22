using ExcelExport;
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
            this.btSelect = new System.Windows.Forms.Button();
            this.tbSave = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.tbInfo = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.强制退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.退出ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tbOut = new ExcelExport.LimitTextBox();
            this.tbIn = new ExcelExport.LimitTextBox();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbIn
            // 
            this.lbIn.AutoSize = true;
            this.lbIn.Location = new System.Drawing.Point(11, 17);
            this.lbIn.Name = "lbIn";
            this.lbIn.Size = new System.Drawing.Size(53, 12);
            this.lbIn.TabIndex = 0;
            this.lbIn.Text = "输入文件";
            // 
            // lbout
            // 
            this.lbout.AutoSize = true;
            this.lbout.Location = new System.Drawing.Point(11, 45);
            this.lbout.Name = "lbout";
            this.lbout.Size = new System.Drawing.Size(53, 12);
            this.lbout.TabIndex = 1;
            this.lbout.Text = "导出文件";
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(331, 83);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(89, 23);
            this.btSave.TabIndex = 2;
            this.btSave.Text = "转换";
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // btSelect
            // 
            this.btSelect.Location = new System.Drawing.Point(384, 12);
            this.btSelect.Name = "btSelect";
            this.btSelect.Size = new System.Drawing.Size(60, 23);
            this.btSelect.TabIndex = 5;
            this.btSelect.Text = "File...";
            this.btSelect.Click += new System.EventHandler(this.btSelect_Click);
            // 
            // tbSave
            // 
            this.tbSave.Location = new System.Drawing.Point(384, 45);
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
            this.tbInfo.Location = new System.Drawing.Point(13, 83);
            this.tbInfo.Multiline = true;
            this.tbInfo.Name = "tbInfo";
            this.tbInfo.ReadOnly = true;
            this.tbInfo.Size = new System.Drawing.Size(301, 23);
            this.tbInfo.TabIndex = 7;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.退出ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(463, 25);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.强制退出ToolStripMenuItem,
            this.退出ToolStripMenuItem1});
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.退出ToolStripMenuItem.Text = "文件";
            // 
            // 强制退出ToolStripMenuItem
            // 
            this.强制退出ToolStripMenuItem.Name = "强制退出ToolStripMenuItem";
            this.强制退出ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.强制退出ToolStripMenuItem.Text = "强制退出";
            this.强制退出ToolStripMenuItem.Click += new System.EventHandler(this.强制退出ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.帮助ToolStripMenuItem.Text = "帮助";
            this.帮助ToolStripMenuItem.Click += new System.EventHandler(this.帮助ToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbInfo);
            this.panel1.Controls.Add(this.lbIn);
            this.panel1.Controls.Add(this.tbSave);
            this.panel1.Controls.Add(this.lbout);
            this.panel1.Controls.Add(this.btSelect);
            this.panel1.Controls.Add(this.btSave);
            this.panel1.Controls.Add(this.tbOut);
            this.panel1.Controls.Add(this.tbIn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(463, 117);
            this.panel1.TabIndex = 9;
            // 
            // 退出ToolStripMenuItem1
            // 
            this.退出ToolStripMenuItem1.Name = "退出ToolStripMenuItem1";
            this.退出ToolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.退出ToolStripMenuItem1.Text = "退出";
            this.退出ToolStripMenuItem1.Click += new System.EventHandler(this.退出ToolStripMenuItem1_Click);
            // 
            // tbOut
            // 
            this.tbOut.AllowDrop = true;
            this.tbOut.BackColor = System.Drawing.SystemColors.Window;
            this.tbOut.HintText = "请输入生成文件名";
            this.tbOut.Location = new System.Drawing.Point(70, 44);
            this.tbOut.Name = "tbOut";
            this.tbOut.RegexValue = "";
            this.tbOut.Size = new System.Drawing.Size(308, 21);
            this.tbOut.TabIndex = 4;
            this.tbOut.TextInputType = ExcelExport.InputType.String;
            this.tbOut.TextChanged += new System.EventHandler(this.tbOut_TextChanged);
            this.tbOut.DragDrop += new System.Windows.Forms.DragEventHandler(this.tbOut_DragDrop);
            this.tbOut.DragEnter += new System.Windows.Forms.DragEventHandler(this.tbOut_DragEnter);
            // 
            // tbIn
            // 
            this.tbIn.AllowDrop = true;
            this.tbIn.HintText = "请输入或选择数据文件";
            this.tbIn.Location = new System.Drawing.Point(70, 14);
            this.tbIn.Name = "tbIn";
            this.tbIn.RegexValue = "";
            this.tbIn.Size = new System.Drawing.Size(308, 21);
            this.tbIn.TabIndex = 3;
            this.tbIn.TextInputType = ExcelExport.InputType.String;
            this.tbIn.TextChanged += new System.EventHandler(this.tbIn_TextChanged);
            this.tbIn.DragDrop += new System.Windows.Forms.DragEventHandler(this.tbIn_DragDrop);
            this.tbIn.DragEnter += new System.Windows.Forms.DragEventHandler(this.tb_DragEnter);
            // 
            // createExcelForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 142);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "createExcelForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Excel生成器";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbIn;
        private System.Windows.Forms.Label lbout;
        private System.Windows.Forms.Button btSave;
        private LimitTextBox tbIn;
        private LimitTextBox tbOut;
        private System.Windows.Forms.Button btSelect;
        private System.Windows.Forms.Button tbSave;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.TextBox tbInfo;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 强制退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem1;
    }
}

