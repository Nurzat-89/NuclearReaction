using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuclearData.Models
{
    public class Nuclide
    {
        public int A { get; set; }
        public int Z { get; set; }
        public int ZAID => Z * 1000 + A;
        public int MAT { get; set; }
        public double AtomicMass { get; set; }
    }
}
