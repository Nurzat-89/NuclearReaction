using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace NuclearCalculation.Models
{
    public class Cram : IExponent<Matrix<Complex>, Complex>
    {
        public Matrix<Complex> Calculate(Matrix<Complex> a, Matrix<Complex> n)
        {
            Matrix<Complex> U = new MatrixComplex(a.Col, a.Row);
            Matrix<Complex> N = n * Globals.Alpha[0].Real;            

            U = U.Unity();
            for (int i = 1; i <= 7; i++)
            {
                var temp = a - (U * Globals.Theta[i]);
                var temp1 = temp.Inverse();
                var nn = temp1 * n * Globals.Alpha[i];
                N = N + nn;
            }
            N = N * 2;
            return N;
        }
    }
}
