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
            var densityArray = new DensityArray(densities);
                
            if (!string.IsNullOrWhiteSpace(isotopesList.Text))
            {
                try
                {
                    var str = isotopesList.Text.Trim().Split(',');

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
                    string[] elements = new string[ind2 - ind1];
                    Array.Copy(Constants.ElementNames, ind1, elements, 0, ind2 - ind1);
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
                            var iso = densities.FirstOrDefault(x => x.Isotope.Name == name);
                            var wgth = double.Parse(weight, System.Globalization.CultureInfo.InvariantCulture);
                            iso.Density = wgth;
                        }
                        catch(Exception) { MessageBox.Show("Не правильна установлена концентрация", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                    }
                }
            }
            Reactor.SetIsotopesFlux(isotopes, neutronSpectra, densityArray);

        }

        private void calculateBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
