using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuclearData.Models
{
    public class EndfMacs: MacsEndfBase
    {
        public EndfMacs():base("ngamma.txt")
        {
        }

        protected override void dataRead() 
        {
            var fn = $"{ Globals.RootDir}MACS/{fileName}";

            FileStream fileStream;
            try
            {
                fileStream = new FileStream(fn, FileMode.Open, FileAccess.Read);
            }
            catch (FileNotFoundException ex)
            {
                return;
            }
            MacsList.Clear();
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                string line = "";
                line = streamReader.ReadLine();
                while ((line = streamReader.ReadLine()) != null)
                {
                    var str = line.Split(';');
                    var s1 = str[0].Trim();
                    var s2 = str[1].Trim();
                    var s4 = str[3].Trim();
                    var s5 = str[4].Trim();
                    var macs = new Macs();
                    var za = s2.Split('-');
                    if (string.IsNullOrEmpty(za[2]) || za[2].ToUpper().Contains('M')) continue;
                    int z = Convert.ToInt32(za[0]);
                    int a = Convert.ToInt32(za[2].Replace("G", ""));
                    var element = new Element(z, a);
                    macs.DataLib = s1;
                    macs.Element = element;
                    macs.kT = Convert.ToDouble(s4);
                    var value = 0.0;
                    try
                    {
                        value = double.Parse(s5, System.Globalization.CultureInfo.InvariantCulture);
                    }
                    catch (Exception) { }
                    macs.AvgCs = value * 1.0E-3;
                    MacsList.Add(macs);
                }
                
            }
            
        }
    }
}
