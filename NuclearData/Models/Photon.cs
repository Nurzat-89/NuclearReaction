using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuclearData.Models
{
    public class Photon:Particle
    {
        public Photon()
        {
            Z = 0;
            A = 0;
            AtomicMass = 0;
            Name = "Photon";
        }
    }
}
