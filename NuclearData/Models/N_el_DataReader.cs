using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NuclearData.Constants;

namespace NuclearData.Models
{
    class N_el_DataReader:NuclearDataReader
    {
        public N_el_DataReader()
        {
            MF = 3;
            MT = 2;
            ReactionType = FILETYP.NEUTRON;
        }
    }
}
