using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuclearData.Models
{
    public class Reaction_n2n : Reaction
    {
        public Reaction_n2n()
        {
            IncidentParticle = new Neutron();
            OutgoingParticles = new List<Particle>();
            OutgoingParticles.Add(new Neutron());
            OutgoingParticles.Add(new Neutron());
        }
        public override Isotope React(Isotope isotope)
        {
            isotope.A -= 1;
            return isotope;
        }
    }
}
