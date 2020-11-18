using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NuclearData.Constants;

namespace NuclearData.Models
{
    public class N2NdataReader:NuclearDataReader
    {
        public N2NdataReader()
        {
            MF = 3;
            MT = 16;
            ReactionType = FILETYP.NEUTRON;
        }
    }
}
