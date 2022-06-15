using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using KazNuclide.Models;
using NuclearCalculation.Models;
using NuclearData;
using NuclearData.Models;

namespace KazNuclide.Views
{
    public partial class CalculationView : UserControl
    {
        public Reactor Reactor { get; set; }
        public Endf CurrentData { get; set; }
        private MiniLoadFormHelper waitForm = new MiniLoadFormHelper();
        public bool IsBurnupSet { get 
            {             
                return groupBoxCalculation.Enabled;
            }
            set 
            {
                groupBoxCalculation.Enabled = value;
            } 
        }
        public CalculationView(Endf[] nuclearData)
        {
            InitializeComponent();
            comBoxDataLibs.DataSource = Enum.GetValues(typeof(Constants.DATALIBS));
            CurrentData = nuclearData[0];
            Reactor = new Reactor(nuclearData);
            Reactor.MatExp.ExpStatusChangedEvent += MatExp_ExpStatusChangedEvent;
        }

        private void MatExp_ExpStatusChangedEvent(int count)
        {
            calculationStatus.Value = count;
        }

        private double getText(string text, string name) 
        {
            var value = 0.0;
            try
            {
                value = double.Parse(text, System.Globalization.CultureInfo.InvariantCulture);
            }
            catch (Exception) { MessageBox.Show($"Не правильный формат: {name}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            return value;
        }
        private List<NuclideDensity> GetDensities(string text)
        {
            List<NuclideDensity> densities = new List<NuclideDensity>();
            if (!string.IsNullOrWhiteSpace(text))
            {
                var str = text.Split(' ');
                if (str != null)
                {
                    for (int i = 0; i < str.Length; i++)
                    {
                        try
                        {
                            var isowgt = str[i].Split('=');
                            var name = isowgt[0];
                            var weight = isowgt[1].Replace(',', '.');
                            var iso = CurrentData.Isotopes.FirstOrDefault(x => x.Name == name);
                            var wgth = double.Parse(weight, System.Globalization.CultureInfo.InvariantCulture);
                            densities.Add(new NuclideDensity(iso, wgth));                                                        
                        }
                        catch (Exception) { MessageBox.Show("Не правильна установлена концентрация", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                    }
                }
            }
            return densities;
        }
        private List<Isotope> GetIsotopesList(string text) 
        {
            List<Isotope> isotopes = new List<Isotope>();
            if (!string.IsNullOrWhiteSpace(text))
            {
                try
                {
                    var str = text.Replace(" ", "").Split(',');
                    for (int i = 0; i < str.Length; i++)
                    {
                        var iso = CurrentData.Isotopes.FirstOrDefault(x => x.Name == str[i]);
                        isotopes.Add(iso);
                    }
                }
                catch (Exception) { MessageBox.Show("Не правильно введены названия изотопов", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }
            return isotopes;
        }

        private List<Isotope> GetIsotopesRange(string text)
        {
            List<Isotope> isotopes = new List<Isotope>();
            if (!string.IsNullOrWhiteSpace(text))
            {
                var str = text.Split('-');
                if (str != null)
                {
                    var ind1 = Constants.ElementNames.ToList().IndexOf(str[0]);
                    var ind2 = Constants.ElementNames.ToList().IndexOf(str[1]);
                    string[] elements = new string[ind2 - ind1 + 1];
                    Array.Copy(Constants.ElementNames, ind1, elements, 0, ind2 - ind1 + 1);
                    for (int i = 0; i < elements.Length; i++)
                    {
                        isotopes.AddRange(CurrentData.Isotopes.Where(x => x.ElementName == elements[i]).ToList());
                    }
                }
            }
            return isotopes;
        }
        private void burnUpBtn_Click(object sender, EventArgs e)
        {
            waitForm.Show(this);
            buildBurnup();
            waitForm.Close();
        }
        private void calculateBtn_Click(object sender, EventArgs e)
        {
            waitForm.Show(this);
            densityCalculation();
            waitForm.Close();
        }

        private void calculateFluxMeshBtn_Click(object sender, EventArgs e)
        {
            var lines = new string[1000, 20];
            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    lines[i, j] = " ";
                }
            }
            double flux = 1.0E13;
            waitForm.Show(this);
            for (int i = 0; i < 5; i++)
            {
                buildBurnup(flux);
                var data = densityFluxMeshCalculation();
                flux = flux * 10;
                int k = 0;
                foreach (var d in data)
                {
                    lines[k, i * 2] = d.A.ToString();
                    lines[k, i * 2 + 1] = d.sig_weight.ToString();
                    k++;
                }
            }
            File.AppendAllText(@"F:\meshtime.dat", Environment.NewLine + Environment.NewLine + Environment.NewLine);

            for (int i = 0; i < 1000; i++)
            {
                var str = "";
                for (int j = 0; j < 20; j++)
                {
                    str += lines[i, j] + "\t";
                }
                File.AppendAllText(@"F:\meshtime.dat", str + Environment.NewLine);
            }
            waitForm.Close();
        }

        private void calculateMeshBtn_Click(object sender, EventArgs e)
        {
            var lines = new string[1000, 20];
            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    lines[i, j] = " ";
                }
            }
                
            var time = 5000;
            waitForm.Show(this);
            for (int i = 0; i < 5; i++)
            {
                var data = densityMeshCalculation(time);
                time = time * (i + 1);
                int k = 0;
                foreach (var d in data)
                {
                    lines[k, i * 2] = d.A.ToString();
                    lines[k, i * 2 + 1] = d.sig_weight.ToString();
                    k++;
                }
            }
            File.AppendAllText(@"F:\meshtime.dat", Environment.NewLine + Environment.NewLine + Environment.NewLine);

            for (int i = 0; i < 1000; i++)
            {
                var str = "";
                for (int j = 0; j < 20; j++)
                {
                    str += lines[i, j] + "\t";
                }
                File.AppendAllText(@"F:\meshtime.dat", str + Environment.NewLine);
            }
            waitForm.Close();
        }
        private void calculationMeshDensity() 
        {
            for (int i = 0; i < 16; i++)
            {
                var heat = densityCalculation(1.0E10);                
            }
            this.mainViewPanel.Controls.Clear();
        }
        private List<BaseAbundance> densityMeshCalculation(double time)
        {
            switch (methodComBox.Text)
            {
                case "MMPA": Reactor.MatExp = new Mmpa(); break;
                case "CRAM": Reactor.MatExp = new Cram(); break;
                case "PADE": Reactor.MatExp = new Pade(); break;
            }
            Reactor.MatExp.ExpStatusChangedEvent += MatExp_ExpStatusChangedEvent;
            calculationStatus.Value = 0;
            var densities = GetDensities(densityTextBox.Text);
            if (densities.Count == 0)
            {
                MessageBox.Show("Установите начальную концентрацию изотопов", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            Reactor.SetDensityArray(densities);
            time = time * 31536000;
            Reactor.Calculate(time);
            var data = new List<BaseAbundance>();
            var nuclides = Reactor.DensityArray.NuclideDensities.OrderBy(x => x.Isotope.A)?.ToList();
            foreach (var iso in nuclides)
            {
                var cs = 0.0;
                try { cs = iso.Isotope.CrossSections[Constants.REACT.N_G].AvgCs; } catch (Exception) { }
                if (iso.Isotope.HalfLife == 1.0E40 && iso.Density > 0.0)
                {
                    data.Add(new BaseAbundance()
                    {
                        Density = iso.Density,
                        A = iso.Isotope.A,
                        AvgCs = cs
                    });
                }
            }
            return data;
            
        }
        private List<BaseAbundance> densityFluxMeshCalculation()
        {
            switch (methodComBox.Text)
            {
                case "MMPA": Reactor.MatExp = new Mmpa(); break;
                case "CRAM": Reactor.MatExp = new Cram(); break;
                case "PADE": Reactor.MatExp = new Pade(); break;
            }
            Reactor.MatExp.ExpStatusChangedEvent += MatExp_ExpStatusChangedEvent;
            calculationStatus.Value = 0;
            var densities = GetDensities(densityTextBox.Text);
            if (densities.Count == 0)
            {
                MessageBox.Show("Установите начальную концентрацию изотопов", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            Reactor.SetDensityArray(densities);
            var str = timesComBox.SelectedItem.ToString();
            var timestr = radiationTimeTextBox.Text;
            int scale;
            try { scale = NuclearCalculation.Models.Globals.TimeScale[str]; } catch (Exception) { return null; }
            double _time = Convert.ToDouble(timestr);
            double time = _time * scale;
            Reactor.Calculate(time);
            var data = new List<BaseAbundance>();
            var nuclides = Reactor.DensityArray.NuclideDensities.OrderBy(x => x.Isotope.A)?.ToList();
            foreach (var iso in nuclides)
            {
                var cs = 0.0;
                try { cs = iso.Isotope.CrossSections[Constants.REACT.N_G].AvgCs; } catch (Exception) { }
                if (iso.Isotope.HalfLife == 1.0E40 && iso.Density > 0.0)
                {
                    data.Add(new BaseAbundance()
                    {
                        Density = iso.Density,
                        A = iso.Isotope.A,
                        AvgCs = cs
                    });
                }
            }
            return data;

        }
        private void heatDensity_Click(object sender, EventArgs e)
        {
            calculateHeatDensity();
        }
        private void calculateHeatDensity() 
        {
            double flux = 1.0E14;
            var data = new List<BaseHeatDensity>();
            var table = new HeatDensityDataTable("HeatDensity");
            for (int i = 0; i < 16; i++)
            {
                buildBurnup(flux);
                var heat = densityCalculation(1.0E10);
                data.Add(new BaseHeatDensity()
                {
                    NeutronFlux = flux,
                    HeatDensity = heat
                });
                flux *= 10;
            }
            table.FillTable(data);
            var dataGraphView = new DataGraphView<BaseHeatDensity>(table);
            this.mainViewPanel.Controls.Clear();
            this.mainViewPanel.Controls.Add(dataGraphView);
            dataGraphView.Dock = DockStyle.Fill;
        }
        private void buildBurnup()
        {
            IsBurnupSet = false;

            var flux = getText(neutronFluxTxt.Text, "Поток нейтронов");
            var temp = getText(temperTextBox.Text, "Температура");
            var kt = getText(txtBoxKt.Text, "kT");
            var neutronSpectra = new NeutronSpectra(flux, temp);
            Constants.DATALIBS dataLib;
            Enum.TryParse(comBoxDataLibs.SelectedValue.ToString(), out dataLib);

            var isotopes = GetIsotopesRange(isotopesRange.Text);
            if (isotopes.Count == 0) isotopes = GetIsotopesList(isotopesList.Text);
            if (isotopes.Count == 0)
            {
                MessageBox.Show("Установите какие диапазон изотопов", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            isotopes.RemoveAll(x => x.HalfLife <= 1000.0);
            Reactor.SetIsotopesFlux(isotopes, neutronSpectra, dataLib, kt);

            /*var  iso1 = Reactor.BurnUp.Isotopes.FirstOrDefault(x => x.Name == "Tl-206");  iso1.HalfLife = 2.52E2;    iso1.CrossSections[Constants.REACT.N_G].AvgCs = 0.0;
            var  iso2 = Reactor.BurnUp.Isotopes.FirstOrDefault(x => x.Name == "Tl-207");  iso2.HalfLife = 2.86E2;    iso2.CrossSections[Constants.REACT.N_G].AvgCs = 0.0;
            var  iso3 = Reactor.BurnUp.Isotopes.FirstOrDefault(x => x.Name == "Pb-204");  iso3.HalfLife = 1.0E40;    iso3.CrossSections[Constants.REACT.N_G].AvgCs = 0.6650334;
            var  iso4 = Reactor.BurnUp.Isotopes.FirstOrDefault(x => x.Name == "Pb-205");  iso4.HalfLife = 1.0E40;    iso4.CrossSections[Constants.REACT.N_G].AvgCs = 4.5297837;
            var  iso5 = Reactor.BurnUp.Isotopes.FirstOrDefault(x => x.Name == "Pb-206");  iso5.HalfLife = 1.0E40;    iso5.CrossSections[Constants.REACT.N_G].AvgCs = 0.0274678;
            var  iso6 = Reactor.BurnUp.Isotopes.FirstOrDefault(x => x.Name == "Pb-207");  iso6.HalfLife = 1.0E40;    iso6.CrossSections[Constants.REACT.N_G].AvgCs = 0.6265085;
            var  iso7 = Reactor.BurnUp.Isotopes.FirstOrDefault(x => x.Name == "Pb-208");  iso7.HalfLife = 1.0E40;    iso7.CrossSections[Constants.REACT.N_G].AvgCs = 2.3199E-4;
            var  iso8 = Reactor.BurnUp.Isotopes.FirstOrDefault(x => x.Name == "Pb-209");  iso8.HalfLife = 1.16E4;    iso8.CrossSections[Constants.REACT.N_G].AvgCs = 0.0;
            var  iso9 = Reactor.BurnUp.Isotopes.FirstOrDefault(x => x.Name == "Pb-210");  iso9.HalfLife = 7.01E8;    iso9.CrossSections[Constants.REACT.N_G].AvgCs = 0.503063;
            var iso10 = Reactor.BurnUp.Isotopes.FirstOrDefault(x => x.Name == "Pb-211");  iso10.HalfLife = 2.17E3;  iso10.CrossSections[Constants.REACT.N_G].AvgCs = 0.0;
            var iso11 = Reactor.BurnUp.Isotopes.FirstOrDefault(x => x.Name == "Bi-209");  iso11.HalfLife = 1.0E40;  iso11.CrossSections[Constants.REACT.N_G].AvgCs = 0.0403781;
            var iso12 = Reactor.BurnUp.Isotopes.FirstOrDefault(x => x.Name == "Bi-210");  iso12.HalfLife = 4.33E5;  iso12.CrossSections[Constants.REACT.N_G].AvgCs = 0.0;
            var iso13 = Reactor.BurnUp.Isotopes.FirstOrDefault(x => x.Name == "Bi-211");  iso13.HalfLife = 1.28E2;  iso13.CrossSections[Constants.REACT.N_G].AvgCs = 0.0;
            var iso14 = Reactor.BurnUp.Isotopes.FirstOrDefault(x => x.Name == "Po-210");  iso14.HalfLife = 1.2E7;   iso14.CrossSections[Constants.REACT.N_G].AvgCs = 0.030174702;
            var iso15 = Reactor.BurnUp.Isotopes.FirstOrDefault(x => x.Name == "Po-211");  iso15.HalfLife = 5.16E-1; //iso15.CrossSections[Constants.REACT.N_G].AvgCs = 0.0;
            
            Reactor.BurnUp.SetBurnMatrix();
            CalculationView.PrintMatrix<double>(terminal, Reactor.BurnUp.Matrix);
            */
            IsBurnupSet = true;
        }

        private void buildBurnup(double flux)
        {
            IsBurnupSet = false;

            var temp = getText(temperTextBox.Text, "Температура");
            var kt = getText(txtBoxKt.Text, "kT");
            var neutronSpectra = new NeutronSpectra(flux, temp);
            Constants.DATALIBS dataLib;
            Enum.TryParse(comBoxDataLibs.SelectedValue.ToString(), out dataLib);

            var isotopes = GetIsotopesRange(isotopesRange.Text);
            if (isotopes.Count == 0) isotopes = GetIsotopesList(isotopesList.Text);
            if (isotopes.Count == 0)
            {
                MessageBox.Show("Установите какие диапазон изотопов", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Reactor.SetIsotopesFlux(isotopes, neutronSpectra, dataLib, kt);

            IsBurnupSet = true;
        }
        private void densityCalculation()
        {
            switch (methodComBox.Text)
            {
                case "MMPA": Reactor.MatExp = new Mmpa();break;                    
                case "CRAM": Reactor.MatExp = new Cram();break;                    
                case "PADE": Reactor.MatExp = new Pade();break;                    
            }
            Reactor.MatExp.ExpStatusChangedEvent += MatExp_ExpStatusChangedEvent;
            calculationStatus.Value = 0;
            var densities = GetDensities(densityTextBox.Text);
            if (densities.Count == 0)
            {
                MessageBox.Show("Установите начальную концентрацию изотопов", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Reactor.SetDensityArray(densities);

            if (!string.IsNullOrWhiteSpace(radiationTimeTextBox.Text))
            {
                var str = timesComBox.SelectedItem.ToString();
                var timestr = radiationTimeTextBox.Text;
                int scale;
                try { scale = NuclearCalculation.Models.Globals.TimeScale[str]; } catch (Exception) { return; }
                double _time = Convert.ToDouble(timestr);
                double time = _time * scale;
                Reactor.Calculate(time);

                var data = new List<BaseAbundance>();
                var table = new AbundanceDataTable("Abundances");
                foreach (var iso in Reactor.DensityArray.NuclideDensities)
                {
                    var cs = 0.0;
                    //if (!iso.Isotope.Stable) continue;
                    try { cs = iso.Isotope.CrossSections[Constants.REACT.N_G].AvgCs; } catch (Exception) { }
                    data.Add(new BaseAbundance()
                    {
                        IsotopeName = iso.NuclideName,
                        Density = iso.Density,
                        AvgCs = cs,                        
                        AtomicWeight = iso.AtomicWeight,
                        A = iso.Isotope.A,
                        HalfLife = iso.Isotope.HalfLife
                    });
                }
                table.FillTable(data);
                var dataGraphView = new DataGraphView<BaseAbundance>(table);
                this.mainViewPanel.Controls.Clear();
                this.mainViewPanel.Controls.Add(dataGraphView);
                dataGraphView.Dock = DockStyle.Fill;
            }
        }

        private double densityCalculation(double _time)
        {
            calculationStatus.Value = 0;
            var densities = GetDensities(densityTextBox.Text);
            if (densities.Count == 0)
            {
                MessageBox.Show("Установите начальную концентрацию изотопов", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return 0.0;
            }
            Reactor.SetDensityArray(densities);
            double heatDensity = 0.0;

            if (!string.IsNullOrWhiteSpace(radiationTimeTextBox.Text))
            {
                var str = timesComBox.SelectedItem.ToString();
                int scale;
                try { scale = NuclearCalculation.Models.Globals.TimeScale[str]; } catch (Exception) { return 0.0; }
                double time = _time * scale;
                Reactor.Calculate(time);
                foreach (var iso in Reactor.DensityArray.NuclideDensities)
                {
                    double decen = 0.0;
                    foreach (var dec in iso.Isotope.Decays)
                    {
                        decen += dec.Value.DecayEnergy * dec.Value.DecayProb;              
                    }
                    heatDensity += decen * iso.Isotope.DecayConst * iso.Density;
                }
            }
            return heatDensity;
        }
        public static void PrintMatrix<T>(RichTextBox richTextBox, Matrix<T> matrix) where T:struct
        {
            string str = "";
            for (int i = 0; i < matrix.Col; i++)
            {
                for (int j = 0; j < matrix.Row; j++)
                {
                    str += String.Format("{0:0.####E+00}", matrix.Arr[i, j]) + "\t\t";                        
                }
                str += "\n";
            }
            richTextBox.Text = str;
        }
        private void txtBoxKt_TextChanged(object sender, EventArgs e)
        {           
            var kt = getText(txtBoxKt.Text, "kT");
            var flux = getText(fluxTextBox.Text, "flux");
            var vel = Math.Sqrt(2 * kt * 1000 * Constants.q_electron / 1.6749E-27) * 100;
            var t = NuclearData.Constants.q_electron * kt * 1.0e3 / (NuclearData.Constants.k);
            temperTextBox.Text = string.Format(t + "", "D2");
            neutronFluxTxt.Text = string.Format(flux * vel + "", "D1").Replace(',','.');
        }      

        private void isotopesRange_TextChanged(object sender, EventArgs e)
        {
            isotopesList.Enabled = string.IsNullOrWhiteSpace(isotopesRange.Text);
            try
            {
                var isotopes = GetIsotopesRange(isotopesRange.Text);
                //isotopes.RemoveAll(x => x.HalfLife <= 10.0);
                totIsotopes.Text = isotopes.Count + "";
            }
            catch (Exception) { totIsotopes.Text = "0"; }
        }

        private void isotopesList_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var isotopes = GetIsotopesList(isotopesList.Text);
                //isotopes.RemoveAll(x => x.HalfLife <= 10.0);
                totIsotopes.Text = isotopes.Count + "";
            }
            catch (Exception) { totIsotopes.Text = "0"; }
        }

        private void fluxTextBox_TextChanged(object sender, EventArgs e)
        {
            var kt = getText(txtBoxKt.Text, "kT");
            var flux = getText(fluxTextBox.Text, "flux");
            var vel = Math.Sqrt(2 * kt * 1000 * Constants.q_electron / 1.6749E-27) * 100;
            neutronFluxTxt.Text = string.Format(flux * vel + "", "D1").Replace(',', '.');
        }
    }
}


