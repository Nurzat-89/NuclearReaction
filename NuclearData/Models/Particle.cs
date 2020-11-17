using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuclearData.Models
{
    public abstract class Particle:Nuclide
    {
        public string Name { get; set; }
    }
}
