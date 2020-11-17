using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuclearData.Models
{
    public class Reaction_ng : Reaction
    {
        public Reaction_ng()
        {
            IncidentParticle = new Neutron();
            OutgoingParticles = new List<Particle>();
            OutgoingParticles.Add(new Photon());
        }
        public override Isotope React(Isotope isotope)
        {
            isotope.A += 1;
            return isotope;
        }
    }
}
