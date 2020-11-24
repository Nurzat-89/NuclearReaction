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
using KazNuclide.Models;

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
            var name = $"{CrossSection.IsotopeName}{NuclearData.Constants.REACTname[CrossSection.Type]}";
            var table = new CrossSectionDataTable(name);
            var csValues = new List<BaseCrossSection>();
            foreach (var data in CrossSection.CrossSectionValues)
            {
                if (data.CsBarn == 0.0) continue;
                csValues.Add(new BaseCrossSection()
                {
                    Cs = data.CsBarn,
                    En = data.EneV
                });
            }
            table.FillTable(csValues);
            var form = new CrossSectionForm(table);
            form.ShowDialog();
        }
    }
}
