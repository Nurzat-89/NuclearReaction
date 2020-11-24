using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuclearData.Models
{
    public class CrossSection
    {
        public List<CrossSectionValue> CrossSectionValues { get; set; }
        public int Id { get; set; }
        public Constants.REACT Type => Constants.REACTIONTYPE[Id];
        public string Name => Type.ToString();
        public string IsotopeName { get; set; }
        public double AvgCs { get; set; }
        public IReaction Reaction { get; set; }
        public CrossSection(int id)
        {
            Id = id;
            CrossSectionValues = new List<CrossSectionValue>();
        }

        public void SetAvgCs(NeutronSpectra neutronSpectra) 
        {
            AvgCs = neutronSpectra.OneGroupCs(this);
        }
    }
}
