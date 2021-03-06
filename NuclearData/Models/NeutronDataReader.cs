﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NuclearData.Constants;

namespace NuclearData.Models
{
    public class NeutronDataReader : NuclearDataReader
    {
        public NeutronDataReader()
        {
            MF = 3;
            MT = 102;
            ReactionType = FILETYP.NEUTRON;
        }
    }
}
