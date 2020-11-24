using KazNuclide.Models;
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

namespace KazNuclide.Views
{
    public partial class DataGraphView<T> : UserControl where T:AxisData
    {
        enum ChartType { Line, Point, LinePoint, Bar};
        private ChartType chartType;
        public BaseDataTable<T> BaseDataTable { get; set; }
        GraphPane pane;

        public DataGraphView(BaseDataTable<T> table)
        {
            BaseDataTable = table;
            InitializeComponent();
            pane = ZedGraph.GraphPane;
            pane.Title = table.Name;
            initialize();
            chartType = ChartType.Line;
            drawChart(BaseDataTable.Data, chartType, xlog.Checked, ylog.Checked);
        }
        private void initialize() 
        {
            DataTable.DataSource = BaseDataTable.Table;
            Header.Text = BaseDataTable.Name;
        }
        public void UpdateTable(List<T> data) 
        {
            BaseDataTable.FillTable(data);
            DataTable.DataSource = BaseDataTable.Table;
            drawChart(BaseDataTable.Data, chartType, xlog.Checked, ylog.Checked);
        }
        private void drawChart(List<T> data, ChartType chartType, bool xlog, bool ylog) 
        {
            switch (chartType) 
            {
                case ChartType.Line:        chartLine(data, xlog, ylog); break;
                case ChartType.LinePoint:   chartLinePoints(data, xlog, ylog); break;
                case ChartType.Point:       chartPoints(data, xlog, ylog); break;
                case ChartType.Bar:         chartBars(data, xlog, ylog); break;
            }
        }
        private void chartLine(List<T> data, bool xlog, bool ylog)
        {
            if (data.Count == 0) return;
            pane.CurveList.Clear();
            pane.XAxis.Title = data[0].Xname;
            pane.YAxis.Title = data[0].Yname;
            if(xlog) pane.XAxis.Type = AxisType.Log; else pane.XAxis.Type = AxisType.Linear;
            if (ylog) pane.YAxis.Type = AxisType.Log; else pane.YAxis.Type = AxisType.Linear;

            PointPairList list = new PointPairList();

            foreach (var item in data)  
            {
                list.Add(item.X, item.Y);
            }

            pane.AddCurve(BaseDataTable.Name, list, Color.Blue, SymbolType.None);

            ZedGraph.AxisChange();
            ZedGraph.Invalidate();
        }
        private void chartPoints(List<T> data, bool xlog, bool ylog)
        {
            if (data.Count == 0) return;
            pane.CurveList.Clear();
            pane.XAxis.Title = data[0].Xname;
            pane.YAxis.Title = data[0].Yname;
            if (xlog) pane.XAxis.Type = AxisType.Log; else pane.XAxis.Type = AxisType.Linear;
            if (ylog) pane.YAxis.Type = AxisType.Log; else pane.YAxis.Type = AxisType.Linear;

            PointPairList list = new PointPairList();

            foreach (var item in data)
            {
                list.Add(item.X, item.Y);
            }

            var curve = pane.AddCurve(BaseDataTable.Name, list, Color.Blue, SymbolType.Square);
            curve.Line.IsVisible = false;
            curve.Symbol.Fill.Color = Color.Blue;
            curve.Symbol.Fill.Type = FillType.Solid;
            curve.Symbol.Size = 1.0f;

            ZedGraph.AxisChange();
            ZedGraph.Invalidate();
        }
        private void chartLinePoints(List<T> data, bool xlog, bool ylog)
        {
            if (data.Count == 0) return;
            pane.CurveList.Clear();
            pane.XAxis.Title = data[0].Xname;
            pane.YAxis.Title = data[0].Yname;
            if (xlog) pane.XAxis.Type = AxisType.Log; else pane.XAxis.Type = AxisType.Linear;
            if (ylog) pane.YAxis.Type = AxisType.Log; else pane.YAxis.Type = AxisType.Linear;

            PointPairList list = new PointPairList();

            foreach (var item in data)
            {
                list.Add(item.X, item.Y);
            }

            var curve = pane.AddCurve(BaseDataTable.Name, list, Color.Blue, SymbolType.Square);
            curve.Line.IsVisible = true;
            curve.Symbol.Fill.Type = FillType.Solid;
            curve.Symbol.Size = 1.0f;
            curve.Symbol.Fill.Color = Color.Blue;

            ZedGraph.AxisChange();
            ZedGraph.Invalidate();
        }
        private void chartBars(List<T> data, bool xlog, bool ylog)
        {
            if (data.Count == 0) return;
            pane.CurveList.Clear();
            pane.XAxis.Title = data[0].Xname;
            pane.YAxis.Title = data[0].Yname;
            if (xlog) pane.XAxis.Type = AxisType.Log; else pane.XAxis.Type = AxisType.Linear;
            if (ylog) pane.YAxis.Type = AxisType.Log; else pane.YAxis.Type = AxisType.Linear;

            double[] XValues = new double[data.Count];
            double[] YValues = new double[data.Count];

            for (int i = 0; i < data.Count; i++)
            {
                XValues[i] = data[i].X;
                YValues[i] = data[i].Y;
            }

            pane.AddBar(BaseDataTable.Name, XValues, YValues, Color.Blue);

            pane.MinBarGap = 0.0f;
            pane.MinClusterGap = 2.5f;

            ZedGraph.AxisChange();
            ZedGraph.Invalidate();
        }
        private void btnLine_Click(object sender, EventArgs e)
        {
            chartType = ChartType.Line;
            drawChart(BaseDataTable.Data, chartType, xlog.Checked, ylog.Checked);
        }

        private void btnLinePoints_Click(object sender, EventArgs e)
        {
            chartType = ChartType.LinePoint;
            drawChart(BaseDataTable.Data, chartType, xlog.Checked, ylog.Checked);

        }

        private void btnPoints_Click(object sender, EventArgs e)
        {
            chartType = ChartType.Point;
            drawChart(BaseDataTable.Data, chartType, xlog.Checked, ylog.Checked);
        }

        private void btnBar_Click(object sender, EventArgs e)
        {
            chartType = ChartType.Bar;
            drawChart(BaseDataTable.Data, chartType, xlog.Checked, ylog.Checked);
        }

        private void xlog_CheckedChanged(object sender, EventArgs e)
        {
            drawChart(BaseDataTable.Data, chartType, xlog.Checked, ylog.Checked);
        }

        private void ylog_CheckedChanged(object sender, EventArgs e)
        {
            drawChart(BaseDataTable.Data, chartType, xlog.Checked, ylog.Checked);
        }
    }
}
