using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Onlymuxia.ExcelOperation
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
            this.textAbout.Text += "\n版本" + Application.ProductVersion.ToString() + "\n";
        }
    }
}
