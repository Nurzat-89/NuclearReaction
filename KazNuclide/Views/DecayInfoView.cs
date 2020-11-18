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
    public partial class DecayInfoView : UserControl
    {
        public Decay Decay;
        public DecayInfoView(Decay decay)
        {
            Decay = decay;
            InitializeComponent();
            DecayTypeLabel.Text = decay.Name;
            var dim = " ev";
            var ener = Decay.DecayEnergy;
            if (decay.DecayEnergy >= 1.0E3) { dim = " keV"; ener = Decay.DecayEnergy / 1.0E3; }
            if (decay.DecayEnergy >= 1.0E6) { dim = " MeV"; ener = Decay.DecayEnergy / 1.0E6; }
            if (decay.DecayEnergy >= 1.0E12) { dim = " GeV"; ener = Decay.DecayEnergy / 1.0E12; }
            EnergyLabel.Text = ener + dim;
            Probability.Text = decay.DecayProbPerc + " %";
        }
    }
}
