using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuclearData.Models
{
    public class CrossSectionValue
    {
        public double EneV { get; set; }
        public double EnJ => EneV * Constants.q_electron;
        public double CsBarn { get; set; }
        public double Cssm2 => CsBarn * Constants.barn;
    }
}
