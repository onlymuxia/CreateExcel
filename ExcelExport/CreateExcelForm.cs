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
using System.Text.RegularExpressions;

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
           
            if (Directory.Exists(outFile))
            {
                saveFileDialog.InitialDirectory = outFile;
            }
            else if (File.Exists(outFile))
            {
                saveFileDialog.InitialDirectory = Path.GetDirectoryName(outFile).ToString(); 
            }
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
        Regex reg = new Regex(@"^([a-zA-Z]:\\)?[^\/\:\*\?\""\<\>\|\,]*$");
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
                        if(reg.IsMatch(outFile))
                        {
                            TextHandler handler = new TextHandler(infile, outFile);
                            handler.execute();
                            this.SetText("生成成功");
                        }
                        else
                        {
                            this.SetText("导出文件填写不正确");
                        }
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
                        MessageBox.Show("Error:" + ex.Message,"生成异常",MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (String.IsNullOrEmpty(outFile))
            {
                tbOut.Text = infile.Replace(".txt", "") + ".xls";
            }
        }

        private void tbOut_TextChanged(object sender, EventArgs e)
        {
            outFile = tbOut.Text ;
        }
        private void tb_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Link; //重要代码：表明是链接类型的数据，比如文件路径
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void tbIn_DragDrop(object sender, DragEventArgs e)
        {
            string path = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            tbIn.Text = path;
        }

        private void tbOut_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Link; //重要代码：表明是链接类型的数据，比如文件路径
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void tbOut_DragDrop(object sender, DragEventArgs e)
        {
            string path = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            tbOut.Text = path;
        }

        private void 强制退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 退出ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            while (executing)
            {
                System.Threading.Thread.Sleep(1000);
            }
            this.Close();
        }

        private void 帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new About().ShowDialog();
        }
    }
}
