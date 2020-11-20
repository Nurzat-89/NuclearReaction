using KazNuclide.Views;
using NuclearData.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KazNuclide
{
    public partial class MainForm : Form
    {
        Dictionary<Button, UserControl> userControls;

        public MainForm()
        {
            InitializeComponent();
            var endfs = new Endf[1] { new Tendl() };
            userControls = new Dictionary<Button, UserControl>()
            {
                {btnNuclearData, new MendeleevTableView(){ Isotopes = endfs[0].Isotopes} },
                {btnCalculation, new CalculationView(endfs) }
            };
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            TitleLabel.Text = button.Text;
            var userControl = userControls[button];
            MainViewPanel.Controls.Clear();
            MainViewPanel.Controls.Add(userControl);
            userControl.Dock = DockStyle.Fill;
        }
    }
}
