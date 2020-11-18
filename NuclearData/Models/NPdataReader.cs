using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NuclearData.Constants;

namespace NuclearData.Models
{
    public class NPdataReader:NuclearDataReader
    {
        public NPdataReader()
        {
            MF = 3;
            MT = 103;
            ReactionType = FILETYP.NEUTRON;
        }
    }
}
