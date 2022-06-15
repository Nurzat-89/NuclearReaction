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
using NuclearCalculation.Models;
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
        public struct filedata
        {
            public string c1;
            public string c2;
            public string c3;
            public string c4;
            public string c5;
            public string c6;
            public string getstr() 
            {
                return $"{c1}\t{c2}\t{c3}\t{c4}\t{c5}\t{c6}\n";
            }
        }
        static void Main(string[] args)
        {

            testInverse();
            /*var initNames = new string[] { "H-1", "H-2", "He-3", "He-4", "Li-6", "Li-7", "Be-9", "B-10", "B-11", "C-12", "C-13", "N-14", "N-15", "O-16", "O-17", "O-18", "F-19", "Ne-20", "Ne-21", "Ne-22", "Na-23", "Mg-24", "Mg-25", "Mg-26", "Al-27", "", "Si-28", "Si-29", "Si-30", "P-31", "S-32", "S-33", "S-34", "S-36", "Cl-35", "Cl-37", "Ar-36", "Ar-38", "Ar-40", "K-39", "K-40", "K-41", "Ca-40", "Ca-42", "Ca-43", "Ca-44", "Ca-46", "Ca-48", "Sc-45", "Ti-46", "Ti-47", "Ti-48", "Ti-49", "Ti-50", "V-50", "V-51", "Cr-50", "Cr-52", "Cr-53", "Cr-54", "Mn-55", "Fe-54", "Fe-56", "Fe-57", "Fe-58", "Co-59", "Ni-58", "Ni-60", "Ni-61", "Ni-62", "Ni-64", "Cu-63", "Cu-65", "Zn-64", "Zn-66", "Zn-67", "Zn-68", "Zn-70", "Ga-69", "Ga-71", "Ge-70", "Ge-72", "Ge-73", "Ge-74", "Ge-76", "As-75", "Se-74", "Se-76", "Se-77", "Se-78", "Se-80", "Se-82", "Br-79", "Br-81", "Kr-78", "Kr-80", "Kr-82", "Kr-83", "Kr-84", "Kr-86", "Rb-85", "Rb-87", "Sr-84", "Sr-86", "Sr-87", "Sr-88", "Y-89", "Zr-90", "Zr-91", "Zr-92", "Zr-94", "Zr-96", "Nb-93", "Mo-92", "Mo-94", "Mo-95", "Mo-96", "Mo-97", "Mo-98", "Mo-100", "Ru-96", "Ru-98", "Ru-99", "Ru-100", "Ru-101", "Ru-102", "Ru-104", "Rh-103", "Pd-102", "Pd-104", "Pd-105", "Pd-106", "Pd-108", "Pd-110", "Ag-107", "Ag-109", "Cd-106", "Cd-108", "Cd-110", "Cd-111", "Cd-112", "Cd-113", "Cd-114", "Cd-116", "In-113", "In-115", "Sn-112", "Sn-114", "Sn-115", "Sn-116", "Sn-117", "Sn-118", "Sn-119", "Sn-120", "Sn-122", "Sn-124", "Sb-121", "Sb-123", "Te-120", "Te-122", "Te-123", "Te-124", "Te-125", "Te-126", "Te-128", "Te-130", "I-127", "Xe-124", "Xe-126", "Xe-128", "Xe-129", "Xe-130", "Xe-131", "Xe-132", "Xe-134", "Xe-136", "Cs-133", "Ba-130", "Ba-132", "Ba-134", "Ba-135", "Ba-136", "Ba-137", "Ba-138", "La-138", "La-139", "Ce-136", "Ce-138", "Ce-140", "Ce-142", "Pr-141", "Nd-142", "Nd-143", "Nd-144", "Nd-145", "Nd-146", "Nd-148", "Nd-150", "Sm-144", "Sm-147", "Sm-148", "Sm-149", "Sm-150", "Sm-152", "Sm-154", "Eu-151", "Eu-153", "Gd-154", "Gd-155", "Gd-156", "Gd-157", "Gd-158", "Gd-160", "Tb-159", "Dy-158", "Dy-160", "Dy-161", "Dy-162", "Dy-163", "Dy-164", "Ho-165", "Er-162", "Er-164", "Er-166", "Er-167", "Er-168", "Er-170", "Tm-169", "Yb-168", "Yb-170", "Yb-171", "Yb-172", "Yb-173", "Yb-174", "Yb-176", "Lu-175", "Lu-176", "Hf-174", "Hf-176", "Hf-177", "Hf-178", "Hf-179", "Hf-180", "Ta-180", "Ta-181", "W-180", "W-182", "W-183", "W-184", "W-186", "Re-185", "Re-187", "Os-184", "Os-186", "Os-187", "Os-188", "Os-189", "Os-190", "Os-192", "Ir-191", "Ir-193", "", "Pt-190", "Pt-192", "Pt-194", "Pt-195", "Pt-196", "Pt-198", "Au-197", "Hg-196", "Hg-198", "Hg-199", "Hg-200", "Hg-201", "Hg-202", "Hg-204", "Tl-203", "Tl-205", "Pb-204", "Pb-206", "Pb-207", "Pb-208", "Bi-209", "Th-232", "U-234", "U-235", "U-238" };
            FileStream fileStream;
            try
            {
                fileStream = new FileStream("F://isotopes1.txt", FileMode.Open, FileAccess.Read);
            }
            catch (FileNotFoundException)
            {
                return;
            }
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                string line = "";
                var oddfile = "";
                var evenfile = "";
                while ((line = streamReader.ReadLine()) != null)
                {
                    var str = line.Split('\t');
                    var filedata = new filedata
                    {
                        c1 = str[0],
                        c2 = str[1],
                        c3 = str[2],
                        c4 = str[3],
                        c5 = str[4],
                        c6 = str[5]
                    };

                    var a = Convert.ToInt32(filedata.c4);
                    if (initNames.ToList().Contains(filedata.c1))
                    {
                        if (a % 2 != 0)
                        {
                            oddfile += filedata.getstr();
                        }
                        else
                        {
                            evenfile += filedata.getstr();
                        }
                    }
                }
                File.WriteAllText("F://oddisotopes.txt", oddfile);
                File.WriteAllText("F://evenisotopes.txt", evenfile);
            }*/

            #region comment
            /*
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
            #endregion
            Console.ReadLine();
        }

        private static void testInverse() 
        {
            var matrix = new MatrixDouble(3, 3);
            matrix.Arr[0, 0] = 1; matrix.Arr[0, 1] = 2; matrix.Arr[0, 2] = 3;
            matrix.Arr[1, 0] = 4; matrix.Arr[1, 1] = 5; matrix.Arr[1, 2] = 6;
            matrix.Arr[2, 0] = 7; matrix.Arr[2, 1] = 8; matrix.Arr[2, 2] = 9;

            var inv = matrix.Inverse();
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
