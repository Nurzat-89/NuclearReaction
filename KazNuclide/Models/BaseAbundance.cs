using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KazNuclide.Models
{
    public class BaseAbundance: AxisData
    {
        public string IsotopeName { get; set; }
        public int Zaid { get; set; }
        public double Density { get; set; }
        public double AvgCs { get; set; }
        public override string Xname => "ZA";
        public override string Yname => "Abundances, %";
        public override double X => Zaid;
        public override double Y => Density;
    }
}
