using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuclearCalculation.Models
{
    public class Pade : IExponent
    {
        public Matrix<double> Calculate(Matrix<double> a, Matrix<double> n)
        {
            Matrix<double> _exp = a.Clone();

            int counter = 0;
            do
            {
                _exp = _exp / 2.0;
                counter++;
            } while (_exp.MaxValueAbs() >= 0.5);

            _exp = exp(_exp);
            for (int i = 0; i < counter; i++)
            {
                if (double.IsInfinity(_exp.Arr[9, 9])|| double.IsInfinity(_exp.Arr[8, 8])|| double.IsInfinity(_exp.Arr[7, 7]))
                {
                    Console.WriteLine("");
                }
                _exp = _exp.Pow(2);                
            }
            n = _exp * n;
            return n;
        }
        private Matrix<double> exp(Matrix<double> a)
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
