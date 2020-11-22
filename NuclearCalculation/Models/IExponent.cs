using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuclearCalculation.Models
{
    public interface IExponent
    {
        Matrix<double> Calculate(Matrix<double> a, Matrix<double> n);
    }
}
