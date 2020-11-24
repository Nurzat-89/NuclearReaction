using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KazNuclide.Models
{
    public class BaseCrossSection: AxisData
    {
        public double En { get; set; }
        public double Cs { get; set; }
        public override string Xname => "E, eV";
        public override string Yname => "cs, barn";
        public override double X => En;
        public override double Y => Cs;
    }
}
