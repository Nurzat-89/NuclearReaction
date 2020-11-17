using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace NuclearCalculation.Models
{
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
