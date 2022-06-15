using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KazNuclide.Models
{
    public class BaseHeatDensity : AxisData
    {
        public double HeatDensity { get; set; }
        public double NeutronFlux { get; set; }
        public override string Xname => "Flux, 1/cm2*sec";

        public override string Yname => "J/sec*cm3";

        public override double X => NeutronFlux;

        public override double Y => HeatDensity;
    }
}
