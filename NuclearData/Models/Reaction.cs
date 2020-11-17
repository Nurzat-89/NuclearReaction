using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuclearData.Models
{
    public abstract class Reaction : IReaction
    {
        public int Id { get; set; }
        public Particle IncidentParticle { get; set; }
        public List<Particle> OutgoingParticles { get; set; }

        public abstract Isotope React(Isotope isotope);
    }
}
