using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace NuclearCalculation.Models
{
    [Serializable]
    public abstract class Matrix<T> where T: struct
    {
        public T[,] Arr { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }
        public Matrix(int col, int row)
        {
            Col = col;
            Row = row;
            Arr = new T[col, row];
        }
        public Matrix()
        {

        }
        public abstract Matrix<T> Clone();
        public abstract void Zero();
        public abstract T MaxValueAbs();
        public void SetMatrix(int col, int row)
        {
            Col = col;
            Row = row;
            Arr = new T[col, row];
        }
        public Matrix<T2> Cast<T2>() where T2 : struct
        {
            var matrixType = Globals.MatrixTypes[typeof(T2)]; 
            var instance = Activator.CreateInstance(matrixType) as Matrix<T2>;
            instance.SetMatrix(Col, Row);
            for (int i = 0; i < Col; i++)
            {
                for (int j = 0; j < Row; j++)
                {
                    dynamic value = null;
                    if(typeof(T2) == typeof(Complex))
                    {
                        value = new Complex((double)Convert.ChangeType(Arr[i, j], typeof(double)), 0.0);
                    }
                    if (typeof(T2) == typeof(double))
                    {
                        value = ((Complex)Convert.ChangeType(Arr[i, j], typeof(Complex))).Real;
                    }
                    if (value != null)
                        instance.Arr[i, j] = (T2)Convert.ChangeType(value, typeof(T2));
                }
            }
            return instance;
        }
        protected abstract Matrix<T> Add(Matrix<T> A);
        protected abstract Matrix<T> Substract(Matrix<T> A);
        protected abstract Matrix<T> Multiply(Matrix<T> A);
        protected abstract Matrix<T> Multiply(T k);
        protected abstract Matrix<T> Devide(T k);
        protected abstract Matrix<T> Devide(Matrix<T> A);
        public abstract Matrix<T> Unity();
        public abstract Matrix<T> Pow(int p);
        public abstract Matrix<T> Inverse();

        public static Matrix<T> operator +(Matrix<T> A, Matrix<T> B)
        {
            return A.Add(B);
        }
        public static Matrix<T> operator -(Matrix<T> A, Matrix<T> B)
        {
            return A.Substract(B);
        }        
        public static Matrix<T> operator *(Matrix<T> A, Matrix<T> B)
        {
            return A.Multiply(B);
        }
        public static Matrix<T> operator /(Matrix<T> A, Matrix<T> B)
        {
            return A.Devide(B);
        }

        public static Matrix<T> operator *(Matrix<T> A, T k)
        {
            return A.Multiply(k);
        }
        public static Matrix<T> operator /(Matrix<T> A, T k)
        {
            return A.Devide(k);
        }
        
    }
}
