using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuclearCalculation.Models
{
    public interface IExponent<TMatrix, TType> where TMatrix : Matrix<TType> where TType : struct
    {
        TMatrix Calculate(TMatrix a, TMatrix n);
    }
}
