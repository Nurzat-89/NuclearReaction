using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuclearData.Models
{
    public class Neutron:Particle
    {
        public Neutron()
        {
            Name = "Neutron";
            A = 1;
            Z = 0;
            AtomicMass = Constants.MassOfNeutron;
        }
    }
}
