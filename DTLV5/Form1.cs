using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Threading;

namespace DTLV5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            int index = this.dataGridView1.Rows.Add();
            this.dataGridView1.Rows[index].Cells[0].Value = "1";
            this.dataGridView1.Rows[index].Cells[1].Value = "2";
            this.dataGridView1.Rows[index].Cells[2].Value = "监听";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Clear();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private Random rand = new Random();
        //private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        //public delegate void AddDataDelegate();
        //public AddDataDelegate addDataDel;

        //private void startTrending_Click()
        //{
 
        //    minValue = DateTime.Now;
        //    maxValue = minValue.AddSeconds(120);
        //    chart1.ChartAreas[0].AxisX.Minimum = minValue.ToOADate();
        //    chart1.ChartAreas[0].AxisX.Maximum = maxValue.ToOADate();
        //    // Reset number of series in the chart.  
        //    chart1.Series.Clear();    // create a line chart series 
        //    Series newSeries = new Series("Series1");
        //    newSeries.ChartType = SeriesChartType.Line;
        //    newSeries.BorderWidth = 2;
        //    newSeries.Color = Color.OrangeRed;
        //    newSeries.XValueType = ChartValueType.DateTime;
        //    chart1.Series.Add(newSeries);
           
        //}

        //public void AddData()
        //{
        //    DateTime timeStamp = DateTime.Now;
        //    foreach (Series ptSeries in chart1.Series)
        //    {
        //        AddNewPoint(timeStamp, ptSeries);
        //    }
        //}
        ///// The AddNewPoint function is called for each series in the chart when
        ///// new points need to be added.  The new point will be placed at specified
        ///// X axis (Date/Time) position with a Y value in a range +/- 1 from the previous
        ///// data point's Y value, and not smaller than zero.
        //public void AddNewPoint(DateTime timeStamp, System.Windows.Forms.DataVisualization.Charting.Series ptSeries)
        //{
        //    double newVal = 0;
        //    if (ptSeries.Points.Count > 0)
        //    {
        //        newVal = ptSeries.Points[ptSeries.Points.Count - 1].YValues[0] + ((rand.NextDouble() * 2) - 1);
        //    } if (newVal < 0)
        //        newVal = 0;
        //    // Add new data point to its series.    
        //    ptSeries.Points.AddXY(timeStamp.ToOADate(), rand.Next(10, 20));
        //    // remove all points from the source series older than 1.5 minutes.    
        //    double removeBefore = timeStamp.AddSeconds((double)(90) * (-1)).ToOADate();
        //    //remove oldest values to maintain a constant number of data points   
        //    while (ptSeries.Points[0].XValue < removeBefore)
        //    { ptSeries.Points.RemoveAt(0); }
        //    chart1.ChartAreas[0].AxisX.Minimum = ptSeries.Points[0].XValue;
        //    chart1.ChartAreas[0].AxisX.Maximum = DateTime.FromOADate(ptSeries.Points[0].XValue).AddMinutes(2).ToOADate();
        //    chart1.Invalidate();
        //}

        //public DateTime minValue { get; set; }

        //public DateTime maxValue { get; set; }
    }
}
