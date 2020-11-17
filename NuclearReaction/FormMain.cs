using CatalysisCode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NuclearReaction
{
    public partial class FormMain : Form
    {
        Endf Endf;
        Thread threadFile;
        NeutronSpectra neutronSpectra;
        public FormMain()
        {
            InitializeComponent();
            

        }

        public void ReadAllNuclearData()
        {
            Endf = new Endf(neutronSpectra);
            MessageBox.Show("Finished");
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            if(txtB_Nuclear.Text==null || txtB_Nuclear.Text=="")
            {
                MessageBox.Show("Не правльный формат названия изотопа, должно быть U-235", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var iso = Endf.GetIsotope(txtB_Nuclear.Text);
                var str = Isotope.ShowIsotope(iso);
                txtB_Info.Text = str;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            double Flux = 1.0E30; // 1/cm^2/s
            double StarTemperatue = 3000; // Kelvin
            neutronSpectra = new NeutronSpectra(Flux, StarTemperatue);
            using (StreamWriter writer = new StreamWriter("dataNeutron.dat"))
            {
                double en = 1E-6;
                for (int i = 0; i < 35; i++)
                {

                    var data = NeutronSpectra.MaxwellCurve(en, StarTemperatue);
                    writer.WriteLine($"{en}\t{data}");
                    en = en * 10;
                }
            }

            var task = Task.Run(() => ReadAllNuclearData());
        }

        private void btnSubmitRange_Click(object sender, EventArgs e)
        {
            var t1 = Endf.ElementNames.ToList().FindIndex(x => x == txt_FirstNucl.Text);
            var t2 = Endf.ElementNames.ToList().FindIndex(x => x == txt_SecondNucl.Text);
            if (t1 == -1 || t2 == -1)
            {
                MessageBox.Show("Элемент не найден");
                return;
            }
            var isotopes = Endf.GetIsotopes(txt_FirstNucl.Text, txt_SecondNucl.Text);
            var mainIsotopes = new List<Isotope>();
            var Catalysis = new BurnUp(isotopes.ToList(), 1.0E13);
            Catalysis.NeutronfluxLevel = 1.0E13;
            Catalysis.SetMatrixDecayProb();
            Catalysis.SetMatrixCaptureProb();

            //Endf.ShowIsotopes(mainIsotopes);
            Catalysis.ResetAllToInitialState(Catalysis.NeutronfluxLevel);
            Catalysis.NuclideDensity = Matrix.ExpCram(Catalysis.A * 1e12, Catalysis.InitailDensities);
            Catalysis.NuclideDensity.Norm();
            var str = BurnUp.ShowDensity(Catalysis);
            txt_Concen.Text = str;
        }
    }
}
