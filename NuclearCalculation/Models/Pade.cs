using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuclearCalculation.Models
{
    public class Pade : IExponent<Matrix<double>, double>
    {
        public Matrix<double> Calculate(Matrix<double> a, Matrix<double> n)
        {
            int p = 6;
            int q = 6;
            int col = a.Col;
            int row = a.Row;
            Matrix<double> N_pq = new MatrixDouble(col, row);
            Matrix<double> D_pq = new MatrixDouble(col, row);
            Matrix<double> temp;
            double ff;
            for (int k = 0; k <= p; k++)
            {
                ff = Globals.Factorial(p + q - k) * Globals.Factorial(p) / (Globals.Factorial(p + q) * Globals.Factorial(k) * Globals.Factorial(p - k));
                temp = a.Pow(k);
                N_pq = N_pq + (temp * ff);
            }

            for (int k = 0; k <= q; k++)
            {
                ff = Globals.Factorial(p + q - k) * Globals.Factorial(q) / (Globals.Factorial(p + q) * Globals.Factorial(k) * Globals.Factorial(q - k));
                temp = a * (-1.0);
                temp = temp.Pow(k);
                D_pq = D_pq + (temp * ff);
            }
            temp = N_pq / D_pq;
            return temp;
        }
    }
}
