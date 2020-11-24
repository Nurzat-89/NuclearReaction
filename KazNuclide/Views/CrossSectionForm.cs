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

namespace KazNuclide.Views
{
    public partial class CrossSectionForm : Form
    {
        public DataGraphView<BaseCrossSection> DataGraphView { get; set; }
        public CrossSectionForm(BaseDataTable<BaseCrossSection> table)
        {
            InitializeComponent();
            DataGraphView = new DataGraphView<BaseCrossSection>(table);
            this.Controls.Add(DataGraphView);
            DataGraphView.Dock = DockStyle.Fill;
        }
    }
}
