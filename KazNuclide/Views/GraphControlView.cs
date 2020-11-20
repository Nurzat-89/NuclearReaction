using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace KazNuclide.Views
{
    public partial class GraphControlView : UserControl
    {

        public GraphControlView()
        {
            InitializeComponent();
            DrawGraph();
        }

        private void DrawGraph()
        {
            GraphPane pane = ZedGraph.GraphPane;
            pane.CurveList.Clear();
            PointPairList f1_list = new PointPairList();
            PointPairList f2_list = new PointPairList();
            double xmin = -50;
            double xmax = 50;
            for (double x = xmin; x <= xmax; x += 0.01)
            {
                f1_list.Add(x, x * x);
            }
            for (double x = 0; x <= xmax; x += 0.5)
            {
                f2_list.Add(x, x * x * x);
            }

            LineItem f1_curve = pane.AddCurve("Sinc", f1_list, Color.Blue, SymbolType.None);
            LineItem f2_curve = pane.AddCurve("Sin", f2_list, Color.Red, SymbolType.Plus);

            ZedGraph.AxisChange();
            ZedGraph.Invalidate();
        }
    }
}
