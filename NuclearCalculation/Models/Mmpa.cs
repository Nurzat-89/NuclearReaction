using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuclearCalculation.Models
{
    public class Mmpa : IExponent
    {
        public event Globals.ExpStatusChangedDelegate ExpStatusChangedEvent;
        public Matrix<double> Calculate(Matrix<double> a, Matrix<double> n)
        {
            int order = 12;
            Matrix<double> U = new MatrixDouble(a.Col, a.Row);
            Matrix<double> S = new MatrixDouble(a.Col, a.Row);
            U = U.Unity();
            S = S.Unity();
            U = U * 11.88124;
            var Inv = (a - U).Inverse();
            var At = (a + U) * Inv;
            var N = n * Globals.MMPA_a12[0];
            var dx = 100.0 / (order + 1.0);
            ExpStatusChangedEvent?.Invoke((int)dx);
            for (int i = 1; i <= order; i++)
            {              
                S = At * S;
                N = N + S * n * Globals.MMPA_a12[i];
                ExpStatusChangedEvent?.Invoke((int)((i + 1) * dx));
            }
            N.RemoveMinuses();

            return N;
        }
    }
}
