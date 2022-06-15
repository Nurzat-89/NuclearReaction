using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuclearCalculation.Models
{
    [Serializable]
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
                throw new Exception("These matrices is not equal");
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
            MatrixDouble result = new MatrixDouble(this.Col, this.Row);
            for (int i = 0; i < Col; i++)
                for (int j = 0; j < Row; j++)
                   result.Arr[i, j] = Arr[i, j] / k;
            return result;
        }
        protected override Matrix<double> Multiply(Matrix<double> B)
        {
            MatrixDouble result = new MatrixDouble(this.Col, B.Row);
            if (this.Row == B.Col)
            {
                result.Arr  = Accord.Math.Matrix.Dot(Arr, B.Arr);                
                return result;
            }
            else
            {
                throw new Exception("These matrices cannot be multiplied");
            }
        }
        protected override Matrix<double> Multiply(double k)
        {
            MatrixDouble result = new MatrixDouble(Col, Row);
            for (int i = 0; i < Col; i++)
                for (int j = 0; j < Row; j++)
                    result.Arr[i, j] = Arr[i, j] * k;
            return result;
        }
        protected override Matrix<double> Substract(Matrix<double> B)
        {
            MatrixDouble result = new MatrixDouble(B.Col, B.Row);
            if (B.Col != this.Col || B.Row != this.Row)
            {
                throw new Exception("These matrices is not equal");
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
            else if (p == 1) result = Clone();
            else
            {
                result = Clone();
                for (int i = 1; i < p; i++)
                    result = result * this;
            }
            return result;
        }

        protected override Matrix<double> Devide(Matrix<double> A)
        {
            var result = A.Inverse();
            result = this * result;
            return result;
        }
        public override Matrix<double> Inverse()
        {
            Matrix<double> X = new MatrixDouble(Col, Row);
            X.Arr = Accord.Math.Matrix.Inverse(Arr);
            return X;
        }
        public  Matrix<double> InverseOld()
        {
            Matrix<double> X = new MatrixDouble(Col, Row);
            Matrix<double> E = new MatrixDouble(Col, Row);
            E = E.Unity();
            double kf;
            int RANG = Row;
            var Temp = Clone();
            for (int p = 0; p < RANG; p++)
            {
                for (int i = p + 1; i < RANG; i++)
                {
                    if (Temp.Arr[p, p] == 0.0) kf = 0;
                    else kf = -Temp.Arr[i, p] / Temp.Arr[p, p];
                    
                    for (int j = 0; j < RANG; j++)
                    {
                        E.Arr[i, j] = E.Arr[i, j] + kf * E.Arr[p, j];
                        if (j >= p) Temp.Arr[i, j] = Temp.Arr[i, j] + kf * Temp.Arr[p, j];
                    }
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

        public override void Zero()
        {
            for (int i = 0; i < Col; i++)
            {
                for (int j = 0; j < Row; j++)
                {
                    Arr[i, j] = 0.0;
                }
            }
        }

        public override double MaxValueAbs()
        {
            double max = Math.Abs(Arr[0, 0]);
            for (int i = 0; i < Col; i++)
            {
                for (int j = 0; j < Row; j++)
                {
                    if (Math.Abs(Arr[i, j]) > max)
                        max = Arr[i, j];
                }
            }
            return max;
        }

        public override Matrix<double> Clone()
        {
            Matrix<double> result = new MatrixDouble(Col, Row);
            for (int i = 0; i < Col; i++)
            {
                for (int j = 0; j < Row; j++)
                {
                    result.Arr[i, j] = Arr[i, j];
                }
            }
            return result;
        }

        public override double Sum()
        {
            double sum = 0.0;
            for (int i = 0; i < Col; i++)
            {
                for (int j = 0; j < Row; j++)
                {
                    sum += Arr[i, j];                     
                }
            }
            return sum;
        }

        public override void Normolize()
        {
            var sum = Sum();
            for (int i = 0; i < Col; i++)
            {
                for (int j = 0; j < Row; j++)
                {
                    Arr[i, j] = Arr[i, j] / sum;
                }
            }
        }

        public override void RemoveMinuses()
        {
            for (int i = 0; i < Col; i++)
            {
                for (int j = 0; j < Row; j++)
                {
                    if (Arr[i, j] < 0.0) Arr[i, j] = 0.0;
                }
            }
        }
    }
}
