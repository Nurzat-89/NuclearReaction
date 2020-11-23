using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using NuclearData;
using NuclearData.Models;
using Accord.Math;
using System.Numerics;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            test1();
            Random rand = new Random();
            double[,] matrix1 = new double[2200, 2200];
            for (int i = 0; i < 2200; i++)
            {
                for (int j = 0; j < 2200; j++)
                {
                    matrix1[i, j] = rand.NextDouble();
                }
            }
            double[,] matrix2 = new double[2200, 2200];
            for (int i = 0; i < 2200; i++)
            {
                for (int j = 0; j < 2200; j++)
                {
                    matrix2[i, j] = rand.NextDouble();
                }
            }
            //var matrix = Matrix.Dot(matrix1, matrix2);
            var mc = MathNet.Numerics.LinearAlgebra.Matrix<Complex>.Build;
            Complex[,] matrix3 = new Complex[2, 2];
            var mat = mc.DenseOfArray(matrix3);
            var inv = mat.Inverse();
            //Accord.Math.ComplexMatrix.Multiply()
            //var reactor = new Reactor();
            //File.Move("oldfilename", "newfilename");


            /*string[] filePaths = Directory.GetFiles($"{Globals.RootDir}JENDL/decay2", "*.endf", SearchOption.TopDirectoryOnly);
            for (int i = 0; i < filePaths.Length; i++)
            {
                filePaths[i] = Path.GetFileName(filePaths[i]);
                var old = filePaths[i];
                var newf = filePaths[i].Replace("_", "-");
                newf = newf.Replace("dec-", "");
                newf = newf.Replace(".endf", "");
                var str = newf.Split('-');
                var z = Convert.ToInt32(str[0]);
                if (str[2].Contains('m')) continue;
                var name = str[1];
                var _a = Convert.ToInt32(str[2]);

                //var str = filePaths[i].Substring(4, 3);
                //newf = newf.Remove(4, 3);
                //newf = newf.Replace(str, "");
                var fn = name + "" + str[2] + ".dat";
                File.Move($"{Globals.RootDir}JENDL/decay2/" + old, $"{Globals.RootDir}JENDL/decay/" + fn);
            }*/

            //Endf tendl = new Tendl();
            //Endf endfB = new EndfB();
            //Endf jeff = new Jendl();
            //tendl.Isotopes = endfB.Isotopes;
            //tendl.SetNuclearData();
        }

        private static void test1() 
        {

        }
    }
}
