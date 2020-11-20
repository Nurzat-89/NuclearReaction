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
        IExponent<Matrix<Complex>, Complex> Cram { get; set; }
        public Reactor(List<Isotope> isotopes, NeutronSpectra spectra, DensityArray densityArray, Endf[] nuclearData)
        {
            Cram = new Cram();
            Libraries = nuclearData;
            CurrentEndf = Libraries[0];
            NeutronSpectra = spectra;
            BurnUp = new BurnUp(isotopes, NeutronSpectra);
            DensityArray = densityArray;
            Calculate(1.0E6);
        }
        public Reactor(Endf[] nuclearData)
        {
            Cram = new Cram();
            Libraries = nuclearData;
            CurrentEndf = Libraries[0];
        }
        public void SetIsotopesFlux(List<Isotope> isotopes, NeutronSpectra neutronSpectra, DensityArray densityArray) 
        {
            DensityArray = densityArray;
            NeutronSpectra = neutronSpectra;
            BurnUp = new BurnUp(isotopes, neutronSpectra);
        }
        public void Calculate(double sec) 
        {
            var matrix = BurnUp.Matrix.Cast<Complex>();
            var density = DensityArray.Density.Cast<Complex>();
            DensityArray.Density = Cram.Calculate(matrix * sec, density).Cast<double>();    
            DensityArray.Normolize();
        }

    }
}
