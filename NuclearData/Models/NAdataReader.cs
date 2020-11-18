using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NuclearData.Constants;

namespace NuclearData.Models
{
    public class NAdataReader:NuclearDataReader
    {
        public NAdataReader()
        {
            MF = 3;
            MT = 107;
            ReactionType = FILETYP.NEUTRON;
        }
    }
}
