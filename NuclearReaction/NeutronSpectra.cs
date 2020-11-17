using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalysisCode
{
    public class NeutronSpectra
    {
        public double Flux { get; set; }
        public List<double> En { get; set; }
        public List<double> Spectrum { get; set; }
        public double Temperature { get; set; } // Temperature of star in K
        public NeutronSpectra(double flux = 1.0E13, double temp = 3000)
        {
            Flux = flux;
            Temperature = temp;
            Spectrum = new List<double>();
        }

        public double MaxwellCurve(double en) 
        {
            en = en * Constants.q_electron;
            var res = 2 * Math.Sqrt(en / Math.PI) * Math.Pow(1 / (Constants.k * Temperature), 3 / 2) * Math.Exp(-en / (Constants.k * Temperature));
            return res;
        }
        public static double MaxwellCurve(double en, double temp)
        {
            en = en * Constants.q_electron;
            var res = 2 * Math.Sqrt(en / Math.PI) * Math.Pow(1 / (Constants.k * temp), 1.5) * Math.Pow(Math.E , -en / (Constants.k * temp));
            return res;
        }
    }
}
