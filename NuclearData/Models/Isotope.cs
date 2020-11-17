using NuclearData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuclearData
{
    public class Isotope:Nuclide
    {
        #region Properties
        public int DecayTypes => Decays.Count;
        public string Name => $"{Constants.ElementNames[Z]}-{A}"; 
        public string ElementName => Constants.ElementNames[Z];
        public bool Stable => Decays.Count != 0;
        public double HalfLife { get; set; }
        public double DecayConst => Constants.ln2 / HalfLife;
        public Dictionary<Constants.RTYPE, Decay> Decays { get; set; }
        public Dictionary<Constants.REACT, CrossSection> CrossSections { get; set; }
        public Isotope()
        {
            Decays = new Dictionary<Constants.RTYPE, Decay>();
            CrossSections = new Dictionary<Constants.REACT, CrossSection>();
        }
        public Isotope(int z, int a)
        {
            Z = z;
            A = a;
            Decays = new Dictionary<Constants.RTYPE, Decay>();
            CrossSections = new Dictionary<Constants.REACT, CrossSection>();
        }
        #endregion
    }
}
