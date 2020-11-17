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
        public Reactor()
        {
            Cram = new Cram();
            Libraries = new Endf[3];
            //Libraries[0] = new Tendl();
            Libraries[1] = new EndfB();
            //Libraries[2] = new Jendl();
            CurrentEndf = Libraries[1];
            var isotopes = new List<Isotope>();
            isotopes.Add(CurrentEndf?.Isotopes?.FirstOrDefault(x => x.Z == 82 && x.A == 205));
            isotopes.Add(CurrentEndf?.Isotopes?.FirstOrDefault(x => x.Z == 82 && x.A == 206));
            isotopes.Add(CurrentEndf?.Isotopes?.FirstOrDefault(x => x.Z == 82 && x.A == 207));
            isotopes.Add(CurrentEndf?.Isotopes?.FirstOrDefault(x => x.Z == 82 && x.A == 208));
            isotopes.Add(CurrentEndf?.Isotopes?.FirstOrDefault(x => x.Z == 83 && x.A == 208));
            isotopes.Add(CurrentEndf?.Isotopes?.FirstOrDefault(x => x.Z == 83 && x.A == 209));
            isotopes.Add(CurrentEndf?.Isotopes?.FirstOrDefault(x => x.Z == 83 && x.A == 210));
            isotopes.Add(CurrentEndf?.Isotopes?.FirstOrDefault(x => x.Z == 84 && x.A == 210));
            isotopes.Add(CurrentEndf?.Isotopes?.FirstOrDefault(x => x.Z == 84 && x.A == 211));
            NeutronSpectra = new NeutronSpectra(1.0E14, 300);
            BurnUp = new BurnUp(isotopes, NeutronSpectra);
            var nuclDens = new List<NuclideDensity>(isotopes.Count);
            foreach (var isotope in isotopes) nuclDens.Add(new NuclideDensity(isotope, 0.0));
            nuclDens[5].Density = 1.0;
            DensityArray = new DensityArray(nuclDens);

            Calculate();
        }

        public void Calculate() 
        {
            var matrix = BurnUp.Matrix.Cast<Complex>();
            var density = DensityArray.Density.Cast<Complex>();
            DensityArray.Density = Cram.Calculate(matrix * 1E12, density).Cast<double>();    
            DensityArray.Normolize();
        }

    }
}
