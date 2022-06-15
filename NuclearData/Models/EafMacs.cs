using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuclearData.Models
{
    public class EafMacs : MacsEndfBase
    {
        public EafMacs():base("eaf2010.txt")
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
            catch (FileNotFoundException)
            {
                return;
            }
            MacsList.Clear();
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                string line = "";
                while ((line = streamReader.ReadLine()) != null)
                {
                    var str = line.Split(',');
                    var s1 = str[1].Trim();
                    var s4 = str[4].Trim();
                    var s5 = str[5].Trim();
                    var s6 = str[6].Trim();
                    var macs = new Macs();
                    var za = s4.Split('-');
                    if (string.IsNullOrEmpty(za[1]) || za[1].ToUpper().Contains('M') || za[1].ToUpper().Contains('N')) continue;
                    string elname = za[0];
                    int z = Constants.ElementNames.Select(x => x.ToUpper()).ToList().IndexOf(elname);
                    int a = Convert.ToInt32(za[1].Replace("G", ""));
                    var element = new Element(z, a);
                    macs.DataLib = s1;
                    macs.Element = element;
                    var value = 0.0;
                    try
                    {
                        value = double.Parse(s5, System.Globalization.CultureInfo.InvariantCulture);
                    }
                    catch (Exception) { }
                    macs.kT = value;
                    try
                    {
                        value = double.Parse(s6, System.Globalization.CultureInfo.InvariantCulture);
                    }
                    catch (Exception) { }
                    macs.AvgCs = value;
                    MacsList.Add(macs);
                }

            }
        }
    }
}
