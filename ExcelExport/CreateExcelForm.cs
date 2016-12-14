using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using System.IO;

namespace Onlymuxia.ExcelOperation
{
    public partial class createExcelForm : Form
    {
        public string infile { get; set; }
        public string outFile { get; set; }
        public bool executing { get; set; }
        public Thread processThread { get; set; }

        public createExcelForm()
        {
            InitializeComponent();
            executing = false;
        }

        private void btSelect_Click(object sender, EventArgs e)
        {
            DialogResult result=  openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                infile = openFileDialog.FileName;
                tbIn.Text = infile;
            }
        }

        private void tbSave_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "Execl files (*.xls)|*.xls";
            DialogResult result = saveFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                outFile = saveFileDialog.FileName;
                tbOut.Text = outFile;
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            this.processThread =  new Thread(new ThreadStart(this.ThreadProcSafe));
            this.processThread.Start();
            tbInfo.Text = " ";
        }


        // 共分三步
        // 第一步：定义委托类型
        // 将text更新的界面控件的委托类型
        delegate void SetTextCallback(string text);

        //第二步：定义线程的主体方法
        /// <summary>
        /// 线程的主体方法
        /// </summary>
        private void ThreadProcSafe()
        {
            if (!executing)
            {
                try
                {
                    executing = true;

                    if (File.Exists(infile))
                    {
                        TextHandler handler = new TextHandler(infile, outFile);
                        handler.execute();
                        this.SetText("生成成功");
                    }
                    else
                    {
                        this.SetText("输入文件不存在");
                    }
                    
                }
                catch (Exception ex)
                {
                    if (ex is UnSaveException)
                    {
                        this.SetText("未保存成功:"+ex.Message);

                    }
                    else
                    {
                        MessageBox.Show("Error:" + ex.Message);
                    }
                }

                executing = false;
            }
        }
        //第三步：定义更新UI控件的方法
        /// <summary>
        /// 更新文本框内容的方法
        /// </summary>
        /// <param name="text"></param>
        private void SetText(string text)
        {
            if (this.tbInfo.InvokeRequired)//如果调用控件的线程和创建创建控件的线程不是同一个则为True
            {
                while (!this.tbInfo.IsHandleCreated)
                {
                    //解决窗体关闭时出现“访问已释放句柄“的异常
                    if (this.tbInfo.Disposing || this.tbInfo.IsDisposed)
                        return;
                }
                SetTextCallback d = new SetTextCallback(SetText);
                this.tbInfo.Invoke(d, new object[] { text });
            }
            else
            {
                this.tbInfo.Text = text;
            }
        }

        private void tbIn_TextChanged(object sender, EventArgs e)
        {
            infile = tbIn.Text;
        }

    }
}
