using System;
using System.Collections.Generic;
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
        public CalculationView(Endf[] nuclearData)
        {
            InitializeComponent();
            CurrentData = nuclearData[0];
            Reactor = new Reactor(nuclearData);
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
        private bool SetDensities(string text,  List<NuclideDensity> densities)
        {
            bool result = false;
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
                            var iso = densities.FirstOrDefault(x => x.NuclideName == name);
                            var wgth = double.Parse(weight, System.Globalization.CultureInfo.InvariantCulture);
                            iso.Density = wgth;
                            result = true;
                        }
                        catch (Exception) { MessageBox.Show("Не правильна установлена концентрация", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                    }
                }
            }
            return result;
        }
        private bool SetIsotopesDensity(string text, List<Isotope> isotopes, List<NuclideDensity> densities) 
        {
            bool result = false;
            if (!string.IsNullOrWhiteSpace(text))
            {
                try
                {
                    var str = text.Replace(" ", "").Split(',');
                    for (int i = 0; i < str.Length; i++)
                    {
                        var iso = CurrentData.Isotopes.FirstOrDefault(x => x.Name == str[i]);
                        isotopes.Add(iso);
                        densities.Add(new NuclideDensity(iso, 0.0));
                    }
                    result = true;
                }
                catch (Exception) { MessageBox.Show("Не правильно введены названия изотопов", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }
            return result;
        }

        private bool SetIsotopesRangeDensity(string text, List<Isotope> isotopes, List<NuclideDensity> densities)
        {
            bool result = false;
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
                    foreach (var isotope in isotopes)
                    {
                        densities.Add(new NuclideDensity(isotope, 0.0));
                    }
                    result = true;
                }
            }
            return result;
        }
        private void burnUpBtn_Click(object sender, EventArgs e)
        {
            var flux = getText(fluxTextBox.Text, "Поток нейтронов");
            var temp = getText(temperTextBox.Text, "Температура");            
            var neutronSpectra = new NeutronSpectra(flux, temp);

            var isotopes = new List<Isotope>();
            var densities = new List<NuclideDensity>();
            var isSuccess = SetIsotopesDensity(isotopesList.Text, isotopes, densities);
            if (!isSuccess) isSuccess = SetIsotopesRangeDensity(isotopesRange.Text, isotopes, densities);
            if(!isSuccess)
            {
                MessageBox.Show("Установите какие диапазон изотопов", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            isSuccess = SetDensities(densityTextBox.Text, densities);
            if (!isSuccess)
            {
                MessageBox.Show("Установите начальную концентрацию изотопов", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }            
            var densityArray = new DensityArray(densities);

            Reactor.SetIsotopesFlux(isotopes, neutronSpectra, densityArray);

            /*var iso1 = Reactor.BurnUp.Isotopes.FirstOrDefault(x => x.Name == "Tl-206"); iso1.HalfLife = 2.52E2; iso1.CrossSections[Constants.REACT.N_G].AvgCs = 0.0;
            var iso2 = Reactor.BurnUp.Isotopes.FirstOrDefault(x => x.Name == "Tl-207"); iso2.HalfLife = 2.86E2; iso2.CrossSections[Constants.REACT.N_G].AvgCs = 0.0;
            var iso3 = Reactor.BurnUp.Isotopes.FirstOrDefault(x => x.Name == "Pb-204"); iso3.HalfLife = 1.0E40; iso3.CrossSections[Constants.REACT.N_G].AvgCs = 0.6650334;
            var iso4 = Reactor.BurnUp.Isotopes.FirstOrDefault(x => x.Name == "Pb-205"); iso4.HalfLife = 1.0E40; iso4.CrossSections[Constants.REACT.N_G].AvgCs = 4.5297837;
            var iso5 = Reactor.BurnUp.Isotopes.FirstOrDefault(x => x.Name == "Pb-206"); iso5.HalfLife = 1.0E40; iso5.CrossSections[Constants.REACT.N_G].AvgCs = 0.0274678;
            var iso6 = Reactor.BurnUp.Isotopes.FirstOrDefault(x => x.Name == "Pb-207"); iso6.HalfLife = 1.0E40; iso6.CrossSections[Constants.REACT.N_G].AvgCs = 0.6265085;
            var iso7 = Reactor.BurnUp.Isotopes.FirstOrDefault(x => x.Name == "Pb-208"); iso7.HalfLife = 1.0E40; iso7.CrossSections[Constants.REACT.N_G].AvgCs = 2.3199E-4;
            var iso8 = Reactor.BurnUp.Isotopes.FirstOrDefault(x => x.Name == "Pb-209"); iso8.HalfLife = 1.16E4; iso8.CrossSections[Constants.REACT.N_G].AvgCs = 0.0;
            var iso9 = Reactor.BurnUp.Isotopes.FirstOrDefault(x => x.Name == "Pb-210"); iso9.HalfLife = 7.01E8; iso9.CrossSections[Constants.REACT.N_G].AvgCs = 0.503063;
            var iso10 = Reactor.BurnUp.Isotopes.FirstOrDefault(x => x.Name == "Pb-211"); iso10.HalfLife = 2.17E3; iso10.CrossSections[Constants.REACT.N_G].AvgCs = 0.0;
            var iso11 = Reactor.BurnUp.Isotopes.FirstOrDefault(x => x.Name == "Bi-209"); iso11.HalfLife = 1.0E40; iso11.CrossSections[Constants.REACT.N_G].AvgCs = 0.0403781;
            var iso12 = Reactor.BurnUp.Isotopes.FirstOrDefault(x => x.Name == "Bi-210"); iso12.HalfLife = 4.33E5; iso12.CrossSections[Constants.REACT.N_G].AvgCs = 0.0;
            var iso13 = Reactor.BurnUp.Isotopes.FirstOrDefault(x => x.Name == "Bi-211"); iso13.HalfLife = 1.28E2; iso13.CrossSections[Constants.REACT.N_G].AvgCs = 0.0;
            var iso14 = Reactor.BurnUp.Isotopes.FirstOrDefault(x => x.Name == "Po-210"); iso14.HalfLife = 1.2E7; iso14.CrossSections[Constants.REACT.N_G].AvgCs = 0.030174702;
            var iso15 = Reactor.BurnUp.Isotopes.FirstOrDefault(x => x.Name == "Po-211"); iso15.HalfLife = 5.16E-1; //iso15.CrossSections[Constants.REACT.N_G].AvgCs = 0.0;
            */
            Reactor.BurnUp.setCaptureProbabilityMatrix();
            Reactor.BurnUp.setDecayProbabilityMatrix();
            Reactor.BurnUp.SetBurnMatrix();
        }

        private void calculateBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(radiationTimeTextBox.Text))
            {
                var str = timesComBox.SelectedItem.ToString();
                var timestr = radiationTimeTextBox.Text;
                int scale;
                try { scale = NuclearCalculation.Models.Globals.TimeScale[str]; } catch (Exception) { return; }
                var time = Convert.ToInt32(timestr) * scale;
                Reactor.Calculate(time);

                var data = new List<BaseAbundance>();
                var table = new AbundanceDataTable("Abundances");
                foreach (var iso in Reactor.DensityArray.NuclideDensities)
                {
                    var cs = 0.0;
                    try{ cs = iso.Isotope.CrossSections[Constants.REACT.N_G].AvgCs; } catch (Exception) { }
                    data.Add(new BaseAbundance() 
                    { 
                        IsotopeName = iso.NuclideName, 
                        Density = iso.Density, 
                        AvgCs = cs, 
                        Zaid = iso.Isotope.ZAID 
                    });
                }
                table.FillTable(data);
                var dataGraphView = new DataGraphView<BaseAbundance>(table);
                this.mainViewPanel.Controls.Clear();
                this.mainViewPanel.Controls.Add(dataGraphView);
                dataGraphView.Dock = DockStyle.Fill;
                //string m = "";
                //for (int i = 0; i < Reactor.DensityArray.Density.Col; i++)
                //{
                //    for (int j = 0; j < Reactor.DensityArray.Density.Row; j++)
                //    {
                //        var avg = 0.0;
                //        try
                //        {
                //            avg = Reactor.DensityArray.NuclideDensities[i].Isotope.CrossSections[Constants.REACT.N_G].AvgCs;
                //        }
                //        catch (Exception) { }
                //        m += Reactor.DensityArray.NuclideDensities[i].NuclideName + "\t" + avg + "\t"  + Reactor.DensityArray.Density.Arr[i, j] + "\t";
                //    }
                //    m += "\n";
                //}

                //var table = new BaseDataTable<NuclideDensity>(Reactor.DensityArray.NuclideDensities.ToList());
                //ResultDataTable.DataSource = table.Table;
            }
            }

        private void txtBoxKt_TextChanged(object sender, EventArgs e)
        {
           var kt = getText(txtBoxKt.Text, "kT");
            var t = NuclearData.Constants.q_electron * kt * 1.0e3 / (NuclearData.Constants.k);
            temperTextBox.Text = string.Format(t + "", "D2");
        }

        private void backWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

        }

        private void backWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {

        }
    }
}
