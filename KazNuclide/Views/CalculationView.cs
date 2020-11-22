using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
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

        private void burnUpBtn_Click(object sender, EventArgs e)
        {
            var fluxTxt = fluxTextBox.Text;
            var tempTxt = temperTextBox.Text;
            var flux = 0.0;
            try
            {
                flux = double.Parse(fluxTxt, System.Globalization.CultureInfo.InvariantCulture);
            }
            catch (Exception) { MessageBox.Show("Не правильный формат числа потока нейтронов", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning); }

            var temp = 0.0;
            try
            {
                temp = double.Parse(tempTxt, System.Globalization.CultureInfo.InvariantCulture);
            }
            catch (Exception) { MessageBox.Show("Не правильна установлена температура", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            var neutronSpectra = new NeutronSpectra(flux, temp);

            var isotopes = new List<Isotope>();
            var densities = new List<NuclideDensity>();
                
            if (!string.IsNullOrWhiteSpace(isotopesList.Text))
            {
                try
                {
                    var str = isotopesList.Text.Replace(" ", "").Split(',');

                    for (int i = 0; i < str.Length; i++)
                    {
                        var iso = CurrentData.Isotopes.FirstOrDefault(x => x.Name == str[i]);
                        isotopes.Add(iso);
                        densities.Add(new NuclideDensity(iso, 0.0));
                    }
                }
                catch(Exception) { MessageBox.Show("Не правильно введено название изотопов", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }
            else if(!string.IsNullOrWhiteSpace(isotopesRange.Text))
            {
                var str = isotopesRange.Text.Split('-');
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
                }
            }
            else
            {
                MessageBox.Show("Установите какие диапазон изотопов", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (!string.IsNullOrWhiteSpace(densityTextBox.Text))
            {
                var str = densityTextBox.Text.Split(' ');
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
                        }
                        catch(Exception) { MessageBox.Show("Не правильна установлена концентрация", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                    }
                }
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


            //string m = "";
            //for (int i = 0; i < Reactor.BurnUp.Matrix.Col; i++)
            //{
            //    for (int j = 0; j < Reactor.BurnUp.Matrix.Row; j++)
            //    {
            //        m += Reactor.BurnUp.Matrix.Arr[i, j] + "\t";
            //    }
            //    m += "\n";
            //}
            //terminalTxtBox.Text = m;
        }

        private void calculateBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(radiationTimeTextBox.Text))
            {
                var str = timesComBox.SelectedItem.ToString();
                var timestr = radiationTimeTextBox.Text;
                int scale = 0;
                switch (str)
                {
                    case "sec": scale = 1; break;
                    case "mins": scale = 60; break;
                    case "hours": scale = 3600; break;
                    case "days": scale = 86400; break;
                    case "months": scale = 2592000; break;
                    case "years": scale = 31536000; break;
                }
                var time = Convert.ToInt32(timestr) * scale;
                Reactor.Calculate(time);
                string m = "";
                for (int i = 0; i < Reactor.DensityArray.Density.Col; i++)
                {
                    for (int j = 0; j < Reactor.DensityArray.Density.Row; j++)
                    {
                        m += Reactor.DensityArray.NuclideDensities[i].NuclideName + " " + Reactor.DensityArray.Density.Arr[i, j] + "\t";
                    }
                    m += "\n";
                }
                terminalTxtBox.Text = m;
            }
        }
    }
}
