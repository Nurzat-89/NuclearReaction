using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuclearData.Models
{
    public class Element
    {
        public int Z { get; set; }
        public int A { get; set; }
        public int ZAID => Z * 1000 + A;
        public string Name => Constants.ElementNames[Z];
        public Element(int z, int a)
        {
            Z = z;
            A = a;
        }
    }
}
