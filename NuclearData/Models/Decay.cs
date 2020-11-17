using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuclearData.Models
{
    public class Decay
    {
        public string Name => Constants.DECAYTYPE[Id].ToString();
        public double Id { get; set; }
        public double DecayEnergy { get; set; }
        public double DecayProb { get; set; }
        public double DecayProbPerc => DecayProb * 100.0;
    }
}
