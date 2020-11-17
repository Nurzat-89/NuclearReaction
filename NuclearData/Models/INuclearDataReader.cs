using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NuclearData.Constants;

namespace NuclearData.Models
{
    public interface INuclearDataReader
    {
        Isotope Read(Isotope isotope, int Z, int A, string fileName);
    }
}
