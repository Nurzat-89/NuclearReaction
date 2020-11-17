using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace NuclearCalculation.Models
{
    public class MatrixComplex:Matrix<Complex>
    {
        public MatrixComplex(int col, int row) : base(col, row)
        {

        }
        public MatrixComplex()
        {

        }
        public override Matrix<Complex> Pow(int p)
        {
            Matrix<Complex> result = new MatrixComplex(Col, Row);

            result = result.Unity();

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

        protected override Matrix<Complex> Add(Matrix<Complex> A)
        {
            MatrixComplex result = new MatrixComplex(A.Col, A.Row);
            if (A.Col != this.Col || A.Row != this.Row)
            {
                Console.WriteLine("\nThese matrices is not equal\n");
                return this;
            }
            else
            {
                for (int i = 0; i < A.Col; i++)
                    for (int j = 0; j < A.Row; j++)
                        result.Arr[i, j] = this.Arr[i, j] + A.Arr[i, j];
                return result;
            }
        }
        protected override Matrix<Complex> Devide(Complex k)
        {
            for (int i = 0; i < Col; i++)
                for (int j = 0; j < Row; j++)
                    Arr[i, j] = Arr[i, j] / k;
            return this;
        }
        protected override Matrix<Complex> Multiply(Matrix<Complex> B)
        {
            MatrixComplex result = new MatrixComplex(this.Col, B.Row);
            if (this.Row == B.Col)
            {
                for (int i = 0; i < this.Col; i++)
                    for (int j = 0; j < B.Row; j++)
                    {
                        Complex sum = 0.0;
                        for (int k = 0; k < this.Row; k++)
                        {
                            sum += this.Arr[i, k] * B.Arr[k, j];
                        }
                        result.Arr[i, j] = sum;
                    }
                return result;
            }
            else
            {
                Console.WriteLine("\nThese matrices cannot be multiplied\n");
                return this;
            }
        }
        protected override Matrix<Complex> Multiply(Complex k)
        {
            for (int i = 0; i < Col; i++)
                for (int j = 0; j < Row; j++)
                    Arr[i, j] = Arr[i, j] * k;
            return this;
        }
        protected override Matrix<Complex> Substract(Matrix<Complex> B)
        {
            MatrixComplex result = new MatrixComplex(B.Col, B.Row);
            if (B.Col != this.Col || B.Row != this.Row)
            {

                Console.WriteLine("\nThese matrices is not equal\n");
                return this;
            }
            else
            {
                for (int i = 0; i < B.Col; i++)
                    for (int j = 0; j < B.Row; j++)
                        result.Arr[i, j] = this.Arr[i, j] - B.Arr[i, j];
                return result;
            }
        }

        public override Matrix<Complex> Unity()
        {
            var unity = new MatrixComplex(this.Col, this.Row);
            for (int i = 0; i < Col; i++)
            {
                unity.Arr[i, i] = new Complex(1.0, 0.0);
            }
            return unity;
        }

        protected override Matrix<Complex> Devide(Matrix<Complex> A)
        {
            Matrix<Complex> result = new MatrixComplex(A.Col, A.Row);
            result = A.Inverse();
            result = this * result;
            return result;
        }

        public override Matrix<Complex> Inverse()
        {
            Matrix<Complex> Temp = new MatrixComplex(Col, Row);
            Matrix<Complex> X = new MatrixComplex(Col, Row);
            Matrix<Complex> E = new MatrixComplex(Col, Row);
            E = E.Unity();
            Complex kf = new Complex();
            int RANG = Row;
            Temp.Arr = (Complex[,])Arr.Clone();

            for (int p = 0; p < RANG; p++)
            {
                for (int i = p + 1; i < RANG; i++)
                {
                    if (Temp.Arr[p, p] == 0.0) kf = 0;
                    else kf = -Temp.Arr[i, p] / Temp.Arr[p, p];

                    for (int j = p; j < RANG; j++)
                        Temp.Arr[i, j] = Temp.Arr[i, j] + kf * Temp.Arr[p, j];

                    for (int j = 0; j < RANG; j++)
                        E.Arr[i, j] = E.Arr[i, j] + kf * E.Arr[p, j];
                }
            }

            for (int k = 0; k < RANG; k++)
            {
                X.Arr[RANG - 1, k] = E.Arr[RANG - 1, k] / Temp.Arr[RANG - 1, RANG - 1];

                for (int i = RANG - 2; i >= 0; i--)
                {
                    Complex sum = 0.0;
                    for (int j = i + 1; j < RANG; j++)
                        sum = sum + X.Arr[j, k] * Temp.Arr[i, j];

                    X.Arr[i, k] = (E.Arr[i, k] - sum) / Temp.Arr[i, i];
                }
            }
            return X;
        }
    }
}
