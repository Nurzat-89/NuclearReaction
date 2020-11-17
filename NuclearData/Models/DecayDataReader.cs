using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NuclearData.Constants;

namespace NuclearData.Models
{
    public class DecayDataReader : NuclearDataReader
    {
        public DecayDataReader()
        {
            MF = 8;
            MT = 457;
            ReactionType = FILETYP.DECAY;
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

                Record r = ENDFSplitCONT(line);
                isotope.AtomicMass = r.c2;

                line = streamReader.ReadLine();
                r = ENDFSplitCONT(line);
                if (r.c1 == 0.0)    isotope.HalfLife = Constants.STABLE;
                else                isotope.HalfLife = r.c1;
                

                line = streamReader.ReadLine();
                line = streamReader.ReadLine();
                r = ENDFSplitCONT(line);
                int rt = Convert.ToInt16(r.n2);

                for (int i = 0; i < rt; i++)
                {
                    line = streamReader.ReadLine();
                    r = ENDFSplitCONT(line);
                    var decay = new Decay
                    {
                        DecayProb = r.n1,
                        DecayEnergy = r.l1,
                        Id = (int)r.c1
                    };
                    if (isotope.Decays.Count(x => x.Key == DECAYTYPE[decay.Id]) == 0)
                        isotope.Decays.Add(DECAYTYPE[decay.Id], decay);
                }
            }
            return isotope;
        }
    }
}
