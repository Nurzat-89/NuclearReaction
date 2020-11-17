using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuclearData.Models
{
    public class NeutronSpectra
    {
        public double Flux { get; set; }
        public double Temperature { get; set; }
        public NeutronSpectra(double flux, double temperature)
        {
            Flux = flux;
            Temperature = temperature;
        }
        public double OneGroupCs(CrossSection crossSection)
        {
            double tot = 0.0;
            double totEn = 0.0;
            foreach (var cs in crossSection.CrossSectionValues)
            {
                var val = MaxwellBoltzmann(cs.EnJ);
                tot += val * cs.CsBarn;
                totEn += val;
            }
            return tot / totEn;
        }

        public double MaxwellBoltzmann(double en)
        {
            var res = 2 * Math.Sqrt(en / Math.PI) * Math.Pow(1 / (Constants.k * Temperature), 3 / 2) * Math.Exp(-en / (Constants.k * Temperature));
            return res;
        }
    }
}
