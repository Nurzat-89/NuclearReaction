using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NuclearData.Constants;

namespace NuclearData.Models
{
    public class NeutronDataReader : NuclearDataReader
    {
        public NeutronDataReader()
        {
            MF = 3;
            MT = 102;
            ReactionType = FILETYP.NEUTRON;
        }
        public override Isotope Read(Isotope isotope, int Z, int A, string fileName)
        {
            int mat, mfs, mts;
            string s, line;

            FileStream fileStream;
            try
            {
                fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            }
            catch (FileNotFoundException ex)
            {
                return isotope;
            }

            if (fileStream == null) return isotope;
            bool found = false;
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                while ((line = streamReader.ReadLine()) != null)
                {
                    if (line.Length < 75) continue;

                    s = line.Substring(66, 4); mat = Convert.ToInt16(s);
                    s = line.Substring(70, 2); mfs = Convert.ToInt16(s);
                    s = line.Substring(72, 3); mts = Convert.ToInt16(s);
                    if (mfs == MF && mts == MT)
                    {
                        found = true;
                        mfs = MF;
                        mts = MT;
                        break;
                    }

                    if ((mfs > MF) || ((mfs == MF) && (mts > MT)))
                    {
                        mfs = 0;
                        mts = 0;
                        break;
                    }
                }

                if (found)
                {
                    int i = 0;
                    line = streamReader.ReadLine();
                    line = streamReader.ReadLine();
                    Record r = ENDFSplitCONT(line);
                    int ns = Convert.ToInt16(r.c1);
                    var crossSection = new CrossSection(MT);
                    i = -1;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        if (line.Length < 75) continue;

                        s = line.Substring(66, 4); mat = Convert.ToInt16(s);
                        s = line.Substring(70, 2); mfs = Convert.ToInt16(s);
                        s = line.Substring(72, 3); mts = Convert.ToInt16(s);
                        var csValue = new CrossSectionValue();

                        r = ENDFSplitCONT(line);
                        i++; crossSection.CrossSectionValues.Add(new CrossSectionValue() { EneV = r.c1, CsBarn = r.c2 }); if (i >= ns) break;
                        i++; crossSection.CrossSectionValues.Add(new CrossSectionValue() { EneV = r.l1, CsBarn = r.l2 }); if (i >= ns) break;
                        i++; crossSection.CrossSectionValues.Add(new CrossSectionValue() { EneV = r.n1, CsBarn = r.n2 }); if (i >= ns) break;

                        if (mfs != MF || mts == 2) break;
                    }

                    isotope.CrossSections.Add(Constants.REACTIONTYPE[crossSection.Id], crossSection);                    
                }
                return isotope;
            }
        }
    }
}
