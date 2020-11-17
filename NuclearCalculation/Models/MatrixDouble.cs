using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuclearCalculation.Models
{
    public class MatrixDouble : Matrix<double>
    {
        public MatrixDouble(int col, int row) : base(col, row)
        {

        }
        public MatrixDouble()
        {

        }
        protected override Matrix<double> Add(Matrix<double> A)
        {
            MatrixDouble result = new MatrixDouble(A.Col, A.Row);
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
        protected override Matrix<double> Devide(double k)
        {
            for (int i = 0; i < Col; i++)
                for (int j = 0; j < Row; j++)
                    Arr[i, j] = Arr[i, j] / k;
            return this;
        }
        protected override Matrix<double> Multiply(Matrix<double> B)
        {
            MatrixDouble result = new MatrixDouble(this.Col, B.Row);
            if (this.Row == B.Col)
            {
                for (int i = 0; i < this.Col; i++)
                    for (int j = 0; j < B.Row; j++)
                    {
                        double sum = 0.0;
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
        protected override Matrix<double> Multiply(double k)
        {
            for (int i = 0; i < Col; i++)
                for (int j = 0; j < Row; j++)
                    Arr[i, j] = Arr[i, j] * k;
            return this;
        }
        protected override Matrix<double> Substract(Matrix<double> B)
        {
            MatrixDouble result = new MatrixDouble(B.Col, B.Row);
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

        public override Matrix<double> Unity()
        {
            var unity = new MatrixDouble(this.Col, this.Row);
            for (int i = 0; i < Col; i++)
            {
                unity.Arr[i, i] = 1.0;
            }
            return unity;
        }

        public override Matrix<double> Pow(int p)
        {
            Matrix<double> result = new MatrixDouble(Col, Row);

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

        protected override Matrix<double> Devide(Matrix<double> A)
        {
            Matrix<double> result = new MatrixDouble(A.Col, A.Row);
            result = A.Inverse();

            result = this * result;
            return result;
        }

        public override Matrix<double> Inverse()
        {
            Matrix<double> Temp = new MatrixDouble(Col, Row);
            Matrix<double> X = new MatrixDouble(Col, Row);
            Matrix<double> E = new MatrixDouble(Col, Row);
            E = E.Unity();
            double kf;
            int RANG = Row;
            Temp.Arr = (double[,])Arr.Clone();

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
                    double sum = 0.0;
                    for (int j = i + 1; j < RANG; j++)
                        sum = sum + X.Arr[j, k] * Temp.Arr[i, j];

                    X.Arr[i, k] = (E.Arr[i, k] - sum) / Temp.Arr[i, i];
                }
            }
            return X;
        }
    }
}
