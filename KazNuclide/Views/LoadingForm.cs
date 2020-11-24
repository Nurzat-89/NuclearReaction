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

namespace KazNuclide.Views
{
    public partial class LoadingForm : Form
    {
        Endf[] Endfs;
        public LoadingForm()
        {
            InitializeComponent();
            Endfs = new Endf[1];
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Endfs = new Endf[1] { new Tendl() };            
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Hide();
            var mainForm = new MainForm(Endfs);
            mainForm.Show();
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
        }
    }
}
