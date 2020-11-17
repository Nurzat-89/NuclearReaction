using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuclearData.Models
{
    public class Proton:Particle
    {
        public Proton()
        {
            Name = "Proton";
            AtomicMass = Constants.MassOfProton;
            Z = 1;
            A = 1;
        }
    }
}
