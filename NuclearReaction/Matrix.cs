using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Accord.Math;
namespace CatalysisCode
{
    public class Matrix
    {
        #region Properties

        public int Row { get; set; }
        public int Col { get; set; }
        public double[,] Arr { get; set; }
        public Complex[,] ArrComplex { get; set; }

        private static readonly double[] thetaReal = {
            0.0,
            -8.8977731864688888199,
            -3.7032750494234480603,
            -0.2087586382501301251,
            3.9933697105785685194,
            5.0893450605806245066,
            5.6231425727459771248,
            2.2697838292311127097
        };
        private static readonly double[] thetaImag = {
            0.0,
            1.6630982619902085304E1,
            1.3656371871483268171E1,
            1.0991260561901260913E1,
            6.0048316422350373178,
            3.58882402902700651E2,
            1.1940690463439669766,
            8.4617379730402214019
        };
        private static readonly double[] alphaReal = {
            1.8321743782540412751E-14,
            -7.1542880635890672853E-5,
            9.4390253107361688779E-3,
            -3.7636003878226968717E-1,
            -2.3498232091082701191E01,
            4.6933274488831293047E01,
            -2.7875161940145646468E01,
            4.8071120988325088907E00
        };
        private static readonly double[] alphaImag = {
            0.0,
            1.4361043349541300111E-4,
            -1.7184791958483017511E-2,
            3.3518347029450104214E-1,
            -5.8083591297142074004,
            4.5643649768827760791E1,
            -1.0214733999056451434E2,
            -1.3209793837428723881
        };

        public static List<Complex> Theta { get; set; }
        public static List<Complex> Alpha { get; set; }

        #endregion

        #region Methods

        public Matrix(int col, int row)
        {
            Col = col;
            Row = row;
            Arr = new double[col + 1, row + 1];
            ArrComplex = new Complex[col, row];
            Arr[col, row] = 0.0;
            for (int i = 0; i < Col; i++)
            {
                Arr[i, Row] = 0.0;
            }
            for (int i = 0; i < Row; i++)
            {
                Arr[Col, i] = 0.0;
            }
            Theta = new List<Complex>();
            Alpha = new List<Complex>();
            for (int i = 0; i <= 7; i++)
            {
                Alpha.Add(new Complex(alphaReal[i], alphaImag[i]));
                Theta.Add(new Complex(thetaReal[i], thetaImag[i]));
            }

        }
        double Factorial(int n)
        {
            int s = 1;
            if (n != 0)
                for (int i = 1; i <= n; i++) s = s * i;

            double res = (double)s;
            return res;
        }
        public void ShowMatrix()
        {
            Console.WriteLine("\nMatrix:\n");
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Row; j++)
                    Console.Write($"{Arr[i,j]}\t");
                Console.WriteLine("");
            }
        }
        public void ShowComplexMatrix()
        {
            Console.WriteLine("\nComplex Matrix:\n");
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Row; j++)
                    Console.Write($"{ArrComplex[i, j]}\t");
                Console.WriteLine("");
            }
        }
        public void setMatrixScale(int _m, int _n)
        {
            Col = _m;
            Row = _n;
        }
        public static Matrix operator + (Matrix A, Matrix B)
        {
            Matrix result = new Matrix(B.Col, B.Row);
            if (B.Col != A.Col || B.Row != A.Row)
            {

                Console.WriteLine("\nThese matrices is not equal\n");
                return A;
            }
            else
            {
                for (int i = 0; i < B.Col; i++)
                    for (int j = 0; j < B.Row; j++)
                        result.Arr[i, j] = A.Arr[i, j] + B.Arr[i, j];
                return result;
            }
        }
        public static Matrix operator -(Matrix A, Matrix B)
        {
            Matrix result = new Matrix(B.Col, B.Row);
            if (B.Col != A.Col || B.Row != A.Row)
            {

                Console.WriteLine("\nThese matrices is not equal\n");
                return A;
            }
            else
            {
                for (int i = 0; i < B.Col; i++)
                    for (int j = 0; j < B.Row; j++)
                        result.Arr[i, j] = A.Arr[i, j] - B.Arr[i, j];
                return result;
            }
        }
        public static Matrix operator *(Matrix A, Matrix B)
        {
            Matrix result = new Matrix(A.Col, B.Row);
            if (A.Row == B.Col)
            {
                for (int i = 0; i < A.Col; i++)
                    for (int j = 0; j < B.Row; j++)
                    {
                        double sum = 0.0;
                        for (int k = 0; k < A.Row; k++)
                        {
                            sum += A.Arr[i, k] * B.Arr[k, j];

                        }
                        result.Arr[i, j] = sum;
                    }
                return result;
            }
            else
            {
                Console.WriteLine("\nThese matrices cannot be multiplied\n");
                return A;
            }
        }
        public static Matrix operator *(Matrix A, double k)
        {
            Matrix result = new Matrix(A.Col, A.Row);
            for (int i = 0; i < A.Col; i++)
                for (int j = 0; j < A.Row; j++)
                    result.Arr[i, j] = A.Arr[i, j] * k;
            return result;
        }
        public static Matrix operator /(Matrix A, double k)
        {
            Matrix result = new Matrix(A.Col, A.Row);
            for (int i = 0; i < A.Col; i++)
                for (int j = 0; j < A.Row; j++)
                    result.Arr[i, j] = A.Arr[i, j] / k;
            return result;
        }
        public static Matrix operator *(Matrix A, Complex k)
        {
            Matrix result = new Matrix(A.Col, A.Row);
            for (int i = 0; i < A.Col; i++)
                for (int j = 0; j < A.Row; j++)
                {
                    result.ArrComplex[i, j] = new Complex(A.Arr[i, j], 0.0);
                    result.ArrComplex[i, j] = A.ArrComplex[i, j] * k;
                }
            return result;
        }
        public static Matrix operator /(Matrix A, Complex k)
        {
            Matrix result = new Matrix(A.Col, A.Row);
            for (int i = 0; i < A.Col; i++)
                for (int j = 0; j < A.Row; j++)
                {
                    result.ArrComplex[i, j] = new Complex(A.Arr[i, j], 0.0);
                    result.ArrComplex[i, j] = A.ArrComplex[i, j] / k;
                }
            return result;
        }
        public static Matrix operator /(Matrix A, Matrix B)
        {
            Matrix result = new Matrix(B.Col, B.Row);
            result = B.Inverse();

            result = A * result;
            return result;
        }
        public double MaxValue()
        {
            return Arr.Cast<double>().Max();
        }
        public double MinValue()
        {
            return Arr.Cast<double>().Min();

        }
        public double MaxValueAbs()
        {
            double min = Math.Abs(Arr.Cast<double>().Min());
            double max = Math.Abs(Arr.Cast<double>().Max());
            if (min > max) return min;
            else return max;
        }
        public double MinValueAbs()
        {
            double min = Math.Abs(Arr.Cast<double>().Where(x => x < 0.0).Max());
            double max = Math.Abs(Arr.Cast<double>().Where(x => x >= 0.0).Min());
            if (min > max) return max;
            else return min;
        }
        public Matrix PowerF(int p)
        {
            Matrix result = new Matrix(Col, Row);

            result.Unity();

            if (p == 0) { }
            else if (p == 1) result = this;
            else
            {
                result = this;
                for (int i = 1; i < p; i++)
                    result = result * this;
            }
            return result;
        }

        public void Unity()
        {
            for (int i = 0; i < Col; i++)
                for (int j = 0; j < Row; j++)
                    if (i == j)
                    {
                        Arr[i, j] = 1.0;
                        ArrComplex[i, j] = new Complex(1.0, 0.0);
                    }
                    else
                    {
                        Arr[i, j] = 0.0;
                        ArrComplex[i, j] = new Complex(0.0, 0.0);
                    }
        }
        public void Zero()
        {
            for (int i = 0; i < Col; i++)
                for (int j = 0; j < Row; j++)
                    Arr[i,j] = 0.0;
        }
        public double Determinant()
        {
            Matrix Temp = new Matrix(Col, Row);
            double k;
            int RANG = Row;

            for (int i = 0; i < Col; i++)
                for (int j = 0; j < Row; j++)
                    Temp.Arr[i, j] = Arr[i, j];

            for (int p = 0; p < RANG; p++)
            {
                for (int i = p + 1; i < RANG; i++)
                {
                    if (Temp.Arr[p,p] == 0.0) k = 0;
                    else k = -Temp.Arr[i,p] / Temp.Arr[p,p];

                    for (int j = p; j < RANG; j++) Temp.Arr[i,j] = k * Temp.Arr[p,j] + Temp.Arr[i,j];

                }
            }

            double det_l = 1;

            for (int i = 0; i < RANG; i++)
            {
                det_l = det_l * Temp.Arr[i,i];
            }



            return det_l;
        }
        public double MinorMatrix(Matrix M, int I, int J)
        {
            Matrix Result = new Matrix(M.Col, M.Row);
            for (int i = 0; i < M.Col; i++)
            {
                if (i >= I)
                    for (int k = 0; k < M.Row; k++)
                        Result.Arr[i,k] = M.Arr[i + 1,k];

                for (int j = 0; j < M.Row; j++)
                {
                    if (j >= J)                        
                            Result.Arr[i, j] = M.Arr[i, j + 1];
                }
            }

            Result.Col = M.Col - 1;
            Result.Row = M.Row - 1;
            return Result.Determinant();
        }
        public Matrix Inverse()
        {           
            Matrix Temp = new Matrix(Col, Row);
            Matrix X = new Matrix(Col, Row);
            Matrix E = new Matrix(Col, Row);
            E.Unity();
            double kf;
            int RANG = Row;
            Temp.Arr = (double[,])Arr.Clone();

            for (int p = 0; p < RANG; p++)
            {
                for (int i = p + 1; i < RANG; i++)
                {
                    if (Temp.Arr[p,p] == 0.0) kf = 0;
                    else kf = -Temp.Arr[i,p] / Temp.Arr[p,p];

                    for (int j = p; j < RANG; j++)
                        Temp.Arr[i,j] = Temp.Arr[i,j] + kf * Temp.Arr[p,j];

                    for (int j = 0; j < RANG; j++)
                        E.Arr[i,j] = E.Arr[i,j] + kf * E.Arr[p,j];
                }
            }

            for (int k = 0; k < RANG; k++)
            {
                X.Arr[RANG - 1,k] = E.Arr[RANG - 1,k] / Temp.Arr[RANG - 1,RANG - 1];

                for (int i = RANG - 2; i >= 0; i--)
                {
                    double sum = 0.0;
                    for (int j = i + 1; j < RANG; j++)
                        sum = sum + X.Arr[j,k] * Temp.Arr[i,j];

                    X.Arr[i,k] = (E.Arr[i,k] - sum) / Temp.Arr[i,i];
                }
            }
            return X;
        }
        public Matrix InverseComplex()
        {
            Matrix Temp = new Matrix(Col, Row);
            Matrix X = new Matrix(Col, Row);
            Matrix E = new Matrix(Col, Row);
            E.Unity();
            Complex kf = new Complex(0.0, 0.0);
            int RANG = Row;
            Temp.ArrComplex = (Complex[,])ArrComplex.Clone();

            for (int p = 0; p < RANG; p++)
            {
                for (int i = p + 1; i < RANG; i++)
                {
                    if (Temp.ArrComplex[p, p] == 0.0) kf = new Complex(0.0, 0.0);
                    else kf = -Temp.ArrComplex[i, p] / Temp.ArrComplex[p, p];

                    for (int j = p; j < RANG; j++)
                        Temp.ArrComplex[i, j] = Temp.ArrComplex[i, j] + kf * Temp.ArrComplex[p, j];

                    for (int j = 0; j < RANG; j++)
                        E.ArrComplex[i, j] = E.ArrComplex[i, j] + kf * E.ArrComplex[p, j];
                }
            }

            for (int k = 0; k < RANG; k++)
            {
                X.ArrComplex[RANG - 1, k] = E.ArrComplex[RANG - 1, k] / Temp.ArrComplex[RANG - 1, RANG - 1];

                for (int i = RANG - 2; i >= 0; i--)
                {
                    Complex sum = new Complex(0.0, 0.0);
                    for (int j = i + 1; j < RANG; j++)
                        sum = sum + X.ArrComplex[j, k] * Temp.ArrComplex[i, j];

                    X.ArrComplex[i, k] = (E.ArrComplex[i, k] - sum) / Temp.ArrComplex[i, i];
                }
            }
            return X;
        }
        public Matrix Transpose()
        {
            Matrix T = new Matrix(Row, Col);

            for (int i = 0; i < Col; i++)
                for (int j = 0; j < Row; j++)
                    T.Arr[j, i] = Arr[i, j];
            return T;
        }
        public void Norm()
        {
            double sum = 0.0;
            for (int i = 0; i < Col; i++)
                for (int j = 0; j < Row; j++)
                    sum = sum + Arr[i,j];

            for (int i = 0; i < Col; i++)
                for (int j = 0; j < Row; j++)
                    Arr[i,j] = Arr[i,j] / sum;
        }
        public Matrix Exp()
        {
            Matrix exp = new Matrix(Col, Row);
            exp = this;

            int counter = 0;
            do
            {
                exp = exp / 2.0;
                //cout << " Max = " << exp.MaxValueAbs() << "\n";
                counter++;
            } while (exp.MaxValueAbs() >= 0.5);
            //cout << " Max = " << exp.MaxValueAbs() << "\n";

            exp = exp.ExpPade(6, 6);

            for (int i = 0; i < counter; i++)
            {
                exp = exp.PowerF(2);
                //exp.showMatrix();
                //Sleep(3000);
            }


            return exp;
            //NuclideDensity.Norm();
        }
        public Matrix ExpTaylor()
        {
            Matrix result = new Matrix(Col, Row);
            result.Zero();
            Matrix temp = new Matrix(Col, Row);
            result.Zero();
            for (int i = 0; i < 14; i++)
            {
                temp = PowerF(i);
                double t = 1 / Factorial(i);
                temp = temp * t;
                result = result + temp;
            }
            return result;
        }
        public Matrix GaussElm()
        {
            Matrix Num = new Matrix(1, Col);
            int n = Col;
            Num.Arr[0,n - 1] = 1.0;
            Num.Arr[0, n - 2] = -Arr[n - 1, n - 1] / Arr[n - 1, n - 2];
            double sum = 0.0;
            for (int i = n - 3; i >= 1; i--)
            {
                sum = 0.0;
                for (int j = i + 1; j < n; j++)
                    sum = sum + Arr[i + 1,j] * Num.Arr[0,j];
                Num.Arr[0,i] = -sum / Arr[i + 1,i];
            }
            Num.Arr[0, 0] = -(Arr[1, 7] * Num.Arr[0, 7] + Arr[1, 1] * Num.Arr[0, 1]) / Arr[1, 0];

            sum = 0.0;
            for (int i = 0; i < n; i++)
                sum += Num.Arr[0,i];

            double kk = 100.0 / sum;
            for (int i = 0; i < n; i++)
                Num.Arr[0, i] = Num.Arr[0, i] * kk;

            return Num;
        }
        public Matrix ExpPade(int p, int q)
        {
            Matrix N_pq = new Matrix(Col, Row);
            Matrix D_pq = new Matrix(Col, Row);
            Matrix temp = new Matrix(Col, Row);
            Matrix result = new Matrix(Col, Row);
            double ff;
            N_pq.Zero();
            D_pq.Zero();
            for (int k = 0; k <= p; k++)
            {
                ff = Factorial(p + q - k) * Factorial(p) / (Factorial(p + q) * Factorial(k) * Factorial(p - k));
                temp = this.PowerF(k);
                N_pq = N_pq + (temp * ff);
            }

            for (int k = 0; k <= q; k++)
            {
                ff = Factorial(p + q - k) * Factorial(q) / (Factorial(p + q) * Factorial(k) * Factorial(q - k));
                temp = (this) * (-1.0);
                temp = temp.PowerF(k);
                D_pq = D_pq + (temp * ff);
            }
            result = N_pq / D_pq;
            return result;
        }

        public static Matrix SubComplexMatrix(Matrix A, Matrix B)
        {
            if (A.Col != B.Col || A.Row != B.Row) throw new Exception("A and B matrix sizes are not equal!");
            Matrix result = new Matrix(A.Col, A.Row);
            Complex[,] complex = new Complex[A.Col, A.Row]; 
            for (int i = 0; i < A.Col; i++) 
                for (int j = 0; j < A.Row; j++)
                {
                    complex[i, j] = new Complex(A.Arr[i, j], 0);
                    complex[i, j] = complex[i, j] - B.ArrComplex[i, j];
                }

            result.ArrComplex = complex;
            return result;
        }

        public static Matrix MultComplexMatrix(Matrix A, Matrix B)
        {

           // for (int i = 0; i < B.Col; i++)
             //   for (int j = 0; j < B.Row; j++)
                    //B.ArrComplex[i, j] = new Complex(B.Arr[i, j], 0.0);

            Matrix result = new Matrix(A.Col, B.Row);
            if (A.Row == B.Col)
            {
                for (int i = 0; i < A.Col; i++)
                    for (int j = 0; j < B.Row; j++)
                    {
                        Complex sum = new Complex(0.0, 0.0);
                        for (int k = 0; k < A.Row; k++)
                        {
                            sum += A.ArrComplex[i, k] * B.ArrComplex[k, j];
                        }
                        result.ArrComplex[i, j] = sum;
                    }
                return result;
            }
            else
            {
                Console.WriteLine("\nThese matrices cannot be multiplied\n");
                return A;
            }
        }

        public static Matrix AddComplexMatrix(Matrix A, Matrix B)
        {
            Matrix result = new Matrix(B.Col, B.Row);
            if (B.Col != A.Col || B.Row != A.Row)
            {

                Console.WriteLine("\nThese matrices is not equal\n");
                return A;
            }
            else
            {
                for (int i = 0; i < B.Col; i++)
                    for (int j = 0; j < B.Row; j++)
                        result.ArrComplex[i, j] = A.ArrComplex[i, j] + B.ArrComplex[i, j];
                return result;
            }
        }

        public static Matrix RealMatrix(Matrix A) 
        {
            Matrix result = new Matrix(A.Col, A.Row);
            for (int i = 0; i < A.Col; i++)
                for (int j = 0; j < A.Row; j++)
                {
                    result.Arr[i, j] = A.ArrComplex[i, j].Real;
                }
            return result;
        }

        public static Matrix ExpCram(Matrix A, Matrix N0)
        {
            Matrix U = new Matrix(A.Col, A.Row);
            Matrix N = new Matrix(N0.Col, N0.Row);
            N = N0 * Alpha[0].Real;
            for (int i = 0; i < N.Col; i++)
                for (int j = 0; j < N.Row; j++)
                {
                    N.ArrComplex[i, j] = new Complex(N.Arr[i, j], 0.0);
                    N0.ArrComplex[i, j] = new Complex(N0.Arr[i, j], 0.0);
                }

            for (int i = 0; i < A.Col; i++)
                for (int j = 0; j < A.Row; j++)
                    A.ArrComplex[i, j] = new Complex(A.Arr[i, j], 0);

            U.Unity();
            Complex[,] example = new Complex[A.Col, A.Row];
            //var inv = example.Inverse();
            //U.ShowComplexMatrix();
            for (int i = 1; i <= 7; i++)
            {
                var temp = SubComplexMatrix(A, U * Theta[i]);
                var temp1 = temp.InverseComplex();

                var n = MultComplexMatrix(temp1, N0 * Alpha[i]);
                N = AddComplexMatrix(N, n);
            }

            N = RealMatrix(N) * 2;

            return N;
        } 

        #endregion
    }
}
