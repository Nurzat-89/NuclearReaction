using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static NuclearCalculation.Models.Globals;

namespace NuclearCalculation.Models
{
    public class Cram : IExponent
    {

        public event ExpStatusChangedDelegate ExpStatusChangedEvent;

        public Matrix<double> Calculate(Matrix<double> a, Matrix<double> n)
        {
            Matrix<Complex> U = new MatrixComplex(a.Col, a.Row);
            Matrix<Complex> N = new MatrixComplex(n.Col, n.Row);
            //Matrix<Complex> N = n * Globals.Alpha[0].Real;           
            var aa = a.Cast<Complex>();
            var nn = n.Cast<Complex>();
            U = U.Unity();
            var dx = 100.0 / 7.0;
            for (int i = 1; i <= 7; i++)
            {
                var temp = aa - (U * Globals.Theta[i]);
                var temp1 = temp.Inverse();
                var _n = temp1 * nn * Globals.Alpha[i];
                var str = "";
                N = N + _n;
                ExpStatusChangedEvent?.Invoke((int)(i * dx));
            }
            Matrix<double> result = N.Cast<double>();
            result *= 2;
            result += n * Globals.Alpha[0].Real;
            result.RemoveMinuses();
            return result;
        }
        private Matrix<double> testCram(Matrix<double> a, Matrix<double> n) 
        {
            throw new NotImplementedException();
			//Matrix<Complex> N = new MatrixComplex(n.Col, n.Row);
			//N = N.Unity();

			//Matrix<Complex> Ii = new MatrixComplex(a.Col, a.Row);
			//Ii = Ii.Unity();


			//Matrix<Complex> Inv = new MatrixComplex(a.Col, a.Row);

			//for (int i = 1; i <= 7; i++)
			//{
   //             Inv = Ii * Globals.Theta[i] * (-1) + a;
			//	Inv = Inv.Inverse();
			//	N = N + Inv * n *Globals.Alpha[i];
			//}

			//Matrix<double> result = N.Real() * 2;

			//result = result + n * Globals.Alpha[0].Real;
			//return result;
		}
    }
}
