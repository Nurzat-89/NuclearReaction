using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuclearData.Models
{
    public class Macs
    {
        public Element Element { get; set; }
        public double AvgCs { get; set; }
        public double kT { get; set; }        
        public string DataLib { get; set; }
    }
}
