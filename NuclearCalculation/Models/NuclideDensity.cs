using NuclearData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuclearCalculation.Models
{
    public class NuclideDensity
    {
        public string NuclideName => Isotope?.Name;
        public double Density { get; set; }
        public Isotope Isotope { get; set; }
        public NuclideDensity(Isotope isotope, double density)
        {
            Isotope = isotope;
            Density = density;
        }
    }
}
