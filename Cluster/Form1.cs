using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Cluster
{
    public partial class Form1 : Form
    {
        private Calc c;
        private int set;
        private int n;
        private List<PointXY> result;
        public Form1()
        {
            InitializeComponent();
            radioButton1.Checked = true;
        }

        private void DrawPlot() {
            Series[] ser = new Series[n];
            Array.Clear(ser, 0, ser.Length);
            chart1.Series.Clear();
            for (int i = 0; i < n; i++)
            {
                ser[i] = new Series("Cluster_" + (i + 1));
                ser[i].ChartType = SeriesChartType.Point;
                chart1.Series.Add(ser[i]);
            }
            for (int i = 0; i < result.Count; i++)
            {
                ser[result[i].getCluster() - 1].Points.AddXY(result[i].getX(), result[i].getY());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                set = 1;
            }
            else if (radioButton2.Checked)
            {
                set = 2;
            }
            else if (radioButton3.Checked)
            {
                set = 3;
            }
            else if (radioButton4.Checked)
            {
                set = 4;
            }
            n = Convert.ToInt32(textBox1.Text);
            c = new Calc(n, set);
            result = c.GetList();
            DrawPlot();
        }
    }
}
