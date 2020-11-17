using NuclearData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuclearCalculation.Models
{
    public class Reactor
    {
        public BurnUp BurnUp { get; set; }
        public NeutronSpectra NeutronSpectra { get; set; }

    }
}
