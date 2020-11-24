using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KazNuclide.Models
{
    public abstract class AxisData
    {
        public abstract string Xname { get; }
        public abstract string Yname { get; }
        public abstract double X { get; }
        public abstract double Y { get; }
    }
}
