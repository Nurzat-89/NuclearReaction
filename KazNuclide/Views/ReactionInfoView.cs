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
    public partial class ReactionInfoView : UserControl
    {
        public CrossSection CrossSection;
        public ReactionInfoView(CrossSection crossSection)
        {
            CrossSection = crossSection;
            InitializeComponent();
            reactionNameLabel.Text = CrossSection.Name;
            endfName.Text = "";
        }

        private void PlotButtton_Click(object sender, EventArgs e)
        {

        }
    }
}
