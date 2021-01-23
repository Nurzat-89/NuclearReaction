using AutoMapper;
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
        Endf[] NuclearLibs;
        public MainForm(Endf[] endfs)
        {
            InitializeComponent();
            NuclearLibs = endfs;
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
            try
            {
                var userControl = userControls[button];
                MainViewPanel.Controls.Clear();
                MainViewPanel.Controls.Add(userControl);
                userControl.Dock = DockStyle.Fill;
            }
            catch (Exception) { return; }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var dr = MessageBox.Show("Вы действительно хотите закрыть?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dr == DialogResult.Yes) { Application.Exit(); }
            else e.Cancel = true;
        }
    }
}
