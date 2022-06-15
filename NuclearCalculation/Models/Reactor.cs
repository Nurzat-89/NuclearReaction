using NuclearData;
using NuclearData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace NuclearCalculation.Models
{
    public class Reactor
    {
        public BurnUp BurnUp { get; set; }
        public Endf[] Libraries { get; set; } 
        public Endf CurrentEndf { get; set; }
        public NeutronSpectra NeutronSpectra { get; set; }
        public DensityArray DensityArray { get; set; }
        public IExponent MatExp { get; set; }
        public Reactor(List<Isotope> isotopes, NeutronSpectra spectra, DensityArray densityArray, Endf[] nuclearData)
        {
            initialize(nuclearData);
            NeutronSpectra = spectra;
            BurnUp = new BurnUp(isotopes, NeutronSpectra);
            DensityArray = densityArray;
            //Calculate(1.0E6);
        }
        public Reactor(Endf[] nuclearData)
        {
            initialize(nuclearData);
        }
        private void initialize(Endf[] nuclearData)
        {
            MatExp = new Cram();
            Libraries = nuclearData;
            CurrentEndf = Libraries[0];
        }
        public void SetIsotopesFlux(List<Isotope> isotopes, NeutronSpectra neutronSpectra)
        {
            NeutronSpectra = neutronSpectra;
            BurnUp = new BurnUp(isotopes, neutronSpectra);
        }
        public void SetIsotopesFlux(List<Isotope> isotopes, NeutronSpectra neutronSpectra, Constants.DATALIBS dataLib, double kt) 
        {
            NeutronSpectra = neutronSpectra;
            var macs = CurrentEndf.EndfMacs.GetMacsList(dataLib, kt);
            BurnUp = new BurnUp(isotopes, neutronSpectra, macs);
        }
        public void SetDensityArray(List<NuclideDensity> initDensities) 
        {
            var densities = new List<NuclideDensity>();
            foreach (var iso in BurnUp.Isotopes)
            {
                var dens = initDensities.FirstOrDefault(x => x.NuclideName == iso.Name);
                var weight = dens == null ? 0.0 : dens.Density;
                densities.Add(new NuclideDensity(iso, weight));              
            }
            DensityArray = new DensityArray(densities);
        }
        public void Calculate(double sec) 
        {
            var matrix = BurnUp.Matrix;
            var density = DensityArray.InitialDensity;
            DensityArray.Density = MatExp.Calculate(matrix * sec, density);
            DensityArray.Normolize();
        }
        public void Calculate(double kev, double dens, double expos)
        {

        }

    }
}
