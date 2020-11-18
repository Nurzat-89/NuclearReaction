using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NuclearData;

namespace KazNuclide.Views
{
    public partial class IsotopeInfoView : UserControl
    {
        public Isotope Isotope { get; set; }
        public IsotopeInfoView(Isotope isotope)
        {
            Isotope = isotope;
            InitializeComponent();
            initialize(isotope);
        }

        private void initialize(Isotope isotope)
        {
            AtomicMassLabel.Text = isotope.AtomicMass + " aem";
            IsotopeName.Text = isotope.Name;
            var time = " s";
            var halfLife = isotope.HalfLife;
            if (isotope.HalfLife < 1.0) { time = " ms"; halfLife = isotope.HalfLife * 1000.0; }
            if (isotope.HalfLife >= 60) { time = " mins"; halfLife = isotope.HalfLife / 60.0; }
            if (isotope.HalfLife >= 3600) { time = " hs"; halfLife = isotope.HalfLife / 3600.0; }
            if (isotope.HalfLife >= 86400) { time = " days"; halfLife = isotope.HalfLife / 86400.0; }
            if (isotope.HalfLife >= 31536000) { time = " yrs"; halfLife = isotope.HalfLife / 31536000; }
            HalfLifeLabel.Text = halfLife + time;

            decaysPanel.Controls.Clear();
            if (Isotope.Decays.Count == 0) { label5.Text = ""; HalfLifeLabel.Text = "stable"; }
            foreach (var decay in Isotope.Decays)
            {
                var decayView = new DecayInfoView(decay.Value);
                decaysPanel.Controls.Add(decayView);
                decayView.Dock = DockStyle.Top;
            }
            var csView = new CrossSectionInfoView(Isotope.CrossSections.Select(x => x.Value).ToList());
            crossSectionPanel.Controls.Clear();
            crossSectionPanel.Controls.Add(csView);
            csView.Dock = DockStyle.Top;
        }
    }
}
