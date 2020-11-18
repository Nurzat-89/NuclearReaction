using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NuclearData.Models;

namespace KazNuclide.Views
{
    public partial class CrossSectionInfoView : UserControl
    {
        public List<CrossSection> CrossSections;
        public CrossSectionInfoView(List<CrossSection> crossSections) 
        {
            CrossSections = crossSections;
            InitializeComponent();
            reactionsPanel.Controls.Clear();
            foreach (var cs in crossSections)
            {
                var csView = new ReactionInfoView(cs);
                reactionsPanel.Controls.Add(csView);
                csView.Dock = DockStyle.Top;
            }
        }
    }
}
