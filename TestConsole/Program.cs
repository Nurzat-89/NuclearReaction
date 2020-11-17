using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using NuclearCalculation.Models;
using NuclearData;
using NuclearData.Models;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            var reactor = new Reactor();
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
    }
}
