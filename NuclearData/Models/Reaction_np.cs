using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuclearData.Models
{
    public class Reaction_np : Reaction
    {
        public Reaction_np()
        {
            IncidentParticle = new Neutron();
            OutgoingParticles = new List<Particle>();
            OutgoingParticles.Add(new Proton());
        }
        public override Isotope React(Isotope isotope)
        {
            isotope.Z -= 1;
            return isotope;
        }
    }
}
