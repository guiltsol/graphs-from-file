using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;
using System.IO;
namespace graphs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void zedGraphControl1_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            GraphPane pane = zedGraphControl1.GraphPane;
            pane.CurveList.Clear();
            PointPairList list = new PointPairList();
            string line;
            System.IO.StreamReader file = new System.IO.StreamReader("D://1.txt");
            while ((line = file.ReadLine()) != null)
            {
                string[] t1 = line.Split(',');
                for (int x=0,y=1; x< t1.Length && y < t1.Length; y++,x++)
                {
                    double xValue = double.Parse(t1[x]);
                    double yValue = double.Parse(t1[y]);
                    list.Add(xValue,yValue);
                }
                LineItem myCurve = pane.AddCurve("", list, Color.Red, SymbolType.None);
                zedGraphControl1.AxisChange();
                zedGraphControl1.Invalidate();
            }
            file.Close();
        }
    }
}
