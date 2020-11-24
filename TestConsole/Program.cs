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
using System.Reflection;

namespace TestConsole
{
    class Program
    {
        public class testClass
        {
            public string Name { get; set; }
            public int value { get; set; }
            public string dim { get; set; }
        }
        static void Main(string[] args)
        {
            var tests = new List<testClass>
            {
                new testClass() { Name = "1r", value = 1, dim = "1k" },
                new testClass() { Name = "2r", value = 2, dim = "2k" },
                new testClass() { Name = "3r", value = 3, dim = "3k" },
                new testClass() { Name = "4r", value = 4, dim = "4k" },
                new testClass() { Name = "5r", value = 5, dim = "5k" },
                new testClass() { Name = "6r", value = 6, dim = "6k" },
                new testClass() { Name = "7r", value = 7, dim = "7k" },
                new testClass() { Name = "8r", value = 8, dim = "8k" }
            };
            
            
            ProceesData(tests);

            //test1();
            //Random rand = new Random();
            //double[,] matrix1 = new double[2200, 2200];
            //for (int i = 0; i < 2200; i++)
            //{
            //    for (int j = 0; j < 2200; j++)
            //    {
            //        matrix1[i, j] = rand.NextDouble();
            //    }
            //}
            //double[,] matrix2 = new double[2200, 2200];
            //for (int i = 0; i < 2200; i++)
            //{
            //    for (int j = 0; j < 2200; j++)
            //    {
            //        matrix2[i, j] = rand.NextDouble();
            //    }
            //}
            ////var matrix = Matrix.Dot(matrix1, matrix2);
            //var mc = MathNet.Numerics.LinearAlgebra.Matrix<Complex>.Build;
            //Complex[,] matrix3 = new Complex[2, 2];
            //var mat = mc.DenseOfArray(matrix3);
            //var inv = mat.Inverse();
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
            Console.ReadLine();
        }

        private static void test1() 
        {

        }
        public static Dictionary<string, object> DictionaryFromType(object atype)
        {
            if (atype == null) return new Dictionary<string, object>();
            Type t = atype.GetType();
            PropertyInfo[] props = t.GetProperties();
            Dictionary<string, object> dict = new Dictionary<string, object>();
            foreach (PropertyInfo prp in props)
            {
                object value = prp.GetValue(atype, new object[] { });
                dict.Add(prp.Name, value);
            }
            return dict;
        }
        public static void ProceesData<T>(IList<T> param1)
        {

            Type t = typeof(T);
            PropertyInfo[] props = t.GetProperties();
            Dictionary<string, object> dict = new Dictionary<string, object>();
            foreach (PropertyInfo prp in props)
            {
                var tt = prp.PropertyType;
                //object value = prp.GetValue(atype, new object[] { });
                //dict.Add(prp.Name, value);
            }


            foreach (var currentItem in param1)
            {
                var d = DictionaryFromType(currentItem);
                foreach (var value in d)
                {
                    Console.WriteLine(value.Key + " = " + value.Value);
                }
                Console.WriteLine();
            }
        }
    }
}
