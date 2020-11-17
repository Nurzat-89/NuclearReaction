using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalysisCode
{
    public class Endf
    {
        #region Fields

        const int MAX_DBLDATA = 50000;
        const int MAX_INTDATA = 1000;
        const int MAX_SUBBLOCK = 500;

        const int MAX_DBLDATA_LARGE = 2000000;
        const int MAX_INTDATA_LARGE = 500000;
        const int MAX_SUBBLOCK_LARGE = 100000;

        const int MAX_DBLDATA_SMALL = 100;
        const int MAX_INTDATA_SMALL = 10;
        const int MAX_SUBBLOCK_SMALL = 10;

        const int MAX_SECTION = 1000;

        const int FIELD_WIDTH = 11;
        const int COLUMN_NUM = 6;

        int mat;     // ENDF MAT number
        int mf;     // ENDF MF number
        int mt;     // ENDF MT number
        Record head;     // Head Record
        int pos;     // pointer to current block
        int ni;     // current number of integer data
        int nx;     // current number of double data

        #endregion

        #region Properties

        public NeutronSpectra NeutronSpectra { get; set; }
        public List<Isotope> Isotopes { get; set;}
        public int IsotopeQnt { get; set; }
        public static string[] ElementNames = { " ", "H", "He", "Li", "Be", "B", "C", "N", "O", "F", "Ne", "Na", "Mg", "Al", "Si", "P", "S", "Cl", "Ar", "K", "Ca", "Sc", "Ti", "V", "Cr", "Mn", "Fe", "Co", "Ni", "Cu", "Zn", "Ga", "Ge", "As", "Se", "Br", "Kr", "Rb", "Sr", "Y", "Zr", "Nb", "Mo", "Tc", "Ru", "Rh", "Pd", "Ag", "Cd", "In", "Sn", "Sb", "Te", "I", "Xe", "Cs", "Ba", "La", "Ce", "Pr", "Nd", "Pm", "Sm", "Eu", "Gd", "Tb", "Dy", "Ho", "Er", "Tm", "Yb", "Lu", "Hf", "Ta", "W", "Re", "Os", "Ir", "Pt", "Au", "Hg", "Tl", "Pb", "Bi", "Po", "At", "Rn", "Fr", "Ra", "Ac", "Th", "Pa", "U", "Np", "Pu", "Am", "Cm", "Bk", "Cf", "Es", "Fm" };
        public enum FILETYP { DECAY, NEUTRON, FISSION };

        #endregion

        #region Methods

        public Endf(NeutronSpectra neutronSpectra)
        {
            NeutronSpectra = neutronSpectra;
            Isotopes = new List<Isotope>();
            ReadAllNuclides();
        }
        
        public string IsotopeFileName(Isotope iso, int ZA, FILETYP ftype)
        {
            string rtyp = "_";
            if (ftype == FILETYP.DECAY) rtyp = "decay/dec-";
            if (ftype == FILETYP.NEUTRON) rtyp = "neutron/n-";
            if (ftype == FILETYP.FISSION) rtyp = "nfy/nfy-";

            int Z = ZA / 1000;
            int A = ZA - Z * 1000;
            iso.A = A;
            iso.Z = Z;
            iso.ZAID = ZA;
            int z = 1000 + Z;
            string sz = z.ToString();
            sz = sz.Substring(1, 3);
            int a = 1000 + A;
            string sa = a.ToString();
            sa = sa.Substring(1, 3);
            string nm = ElementNames[Z] + sa;
            iso.Name = nm;
            iso.ElementName = ElementNames[Z];
            string filePath = "xsdir/" + rtyp + sz + "_" + ElementNames[Z] + "_" + sa + ".endf";
            return filePath;
        }

        public void ReadAllNuclides()
        {
            int i = 0;

            for (int z = 1; z <= 94; z++) // From H to Pu
            {
                for (int a = (int)(z * 1.5); a < z * 3; a++)
                {
                    var tempIso = new Isotope();
                    int zaid = z * 1000 + a;
                    int yes = GetRadDecInf(tempIso, zaid);
                    GetNeuRecInfMF3(tempIso, zaid, 102);

                    if (yes != -1)
                    {
                        Isotopes.Add(tempIso);
                        i++;
                    }
                }
            }
            Console.WriteLine("\nFound nuclides = " + i);
            IsotopeQnt = i;
        }

        public Isotope GetIsotope(int ZAID)
        {
            return Isotopes.FirstOrDefault(x => x.ZAID == ZAID);
        }
        public Isotope GetIsotope(string name)
        {
            return Isotopes.FirstOrDefault(x => x.Name == name);
        }
        public Isotope GetIsotope(int Z, int A)
        {
            return Isotopes.FirstOrDefault(x => x.Z == Z && x.A == A);
        }
        public IEnumerable<Isotope> GetIsotopes(int ZAID1, int ZAID2)
        {
            return Isotopes.Where(x => x.ZAID >= ZAID1 && x.ZAID <= ZAID2);
        }
        public IEnumerable<Isotope> GetIsotopes(string Name)
        {
            return Isotopes.Where(x => x.ElementName == Name);
        }
        public IEnumerable<Isotope> GetIsotopes(string Name1, string Name2)
        {
            var Z1 = Array.FindIndex(ElementNames, row => row == Name1);
            var Z2 = Array.FindIndex(ElementNames, row => row == Name2);
            return GetIsotopesByZ(Z1, Z2);
        }
        public IEnumerable<Isotope> GetIsotopesByZ(int Z1, int Z2)
        {
            return Isotopes.Where(x => x.Z >= Z1 && x.Z <= Z2);
        }

        public void ShowIsotopes()
        {
            foreach (var iso in Isotopes)
                iso.ShowIsotope();
        }

        public static string ShowIsotopes(IEnumerable<Isotope> isotopes)
        {
            string str = "";
            foreach (var iso in isotopes)
                str += Isotope.ShowIsotope(iso);
            return str;
        }

        double ENDFPadExp(string str)
        {
            /*** if blank, return zero */
            if (str == "           ") return (0.0);

            /*** search for E, if exists return the floating point number */
            bool found = false;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i].ToString().ToUpper() == "E") found = true;
            }
            if (found) return double.Parse(str, System.Globalization.CultureInfo.InvariantCulture);

            int len = str.Length;
            int p1 = 0, p2 = 0, p3 = 0;

            /**** sign */
            int sig = 1;
            for (p1 = 0; p1 < len; p1++)
            {
                if (str[p1] == ' ') continue;
                else if (str[p1] == '+') sig = 1;
                else if (str[p1] == '-') sig = -1;
                else if ((str[p1] >= '0' && str[p1] <= '9') || str[p1] == '.') break;
            }

            /**** find + or - */
            found = false;
            char q = '+';
            for (p2 = p1; p2 < len; p2++)
            {
                if (str[p2] == '+' || str[p2] == '-')
                {
                    found = true;
                    q = str[p2];
                    break;
                }
                else if (str[p2] == ' ') continue;
            }

            /*** reconstruct the real number */
            char[] num = new char[20];
            int k = 0;
            for (int i = 0; i < (p2 - p1); i++)
            {
                if (str[i + p1] == ' ') continue;
                num[k++] = str[i + p1];
            }

            if (found)
            {
                num[k++] = 'e';
                num[k++] = q;
                for (p3 = p2 + 1; p3 < len; p3++)
                {
                    if (str[p3] == ' ') continue;
                    num[k++] = str[p3];
                }
            }
            num[k] = '\0';

            return sig * double.Parse(new string(num), System.Globalization.CultureInfo.InvariantCulture);
        }

        Record ENDFSplitCONT(string line)
        {
            Record r = new Record();
            int p = 0;
            string s;

            s = line.Substring(p, FIELD_WIDTH); p += FIELD_WIDTH; r.c1 = ENDFPadExp(s);
            s = line.Substring(p, FIELD_WIDTH); p += FIELD_WIDTH; r.c2 = ENDFPadExp(s);
            s = line.Substring(p, FIELD_WIDTH); p += FIELD_WIDTH; r.l1 = ENDFPadExp(s);
            s = line.Substring(p, FIELD_WIDTH); p += FIELD_WIDTH; r.l2 = ENDFPadExp(s);
            s = line.Substring(p, FIELD_WIDTH); p += FIELD_WIDTH; r.n1 = ENDFPadExp(s);
            s = line.Substring(p, FIELD_WIDTH); r.n2 = ENDFPadExp(s);

            return (r);
        }

        int GetRadDecInf(Isotope iso, int ZAID)
        {
            int mat = 0, mfs, mts;
            string s, line;
            int mfsearch = 8, mtsearch = 457;
            string fn = IsotopeFileName(iso, ZAID, FILETYP.DECAY);
            FileStream fileStream;
            try
            {
                fileStream = new FileStream(fn, FileMode.Open, FileAccess.Read);
            }
            catch (FileNotFoundException ex)
            {
                return -1;
            }
            bool found = false;
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                while ((line = streamReader.ReadLine()) != null)
                {
                    if (line.Length < 75) continue;

                    s = line.Substring(66, 4); mat = Convert.ToInt16(s);
                    s = line.Substring(70, 2); mfs = Convert.ToInt16(s);
                    s = line.Substring(72, 3); mts = Convert.ToInt16(s);
                    if (mfs == mfsearch && mts == mtsearch)
                    {
                        found = true;
                        mfs = mfsearch;
                        mts = mtsearch;
                        //Record r = ENDFSplitCONT();
                        break;
                    }

                    /*** not found */
                    if ((mfs > mfsearch) || ((mfs == mfsearch) && (mts > mtsearch)))
                    {
                        mfs = 0;
                        mts = 0;
                        break;
                    }
                }

                Record r = ENDFSplitCONT(line);
                iso.AtomicMass = r.c2;

                line = streamReader.ReadLine();
                r = ENDFSplitCONT(line);
                if (r.c1 == 0.0)
                {
                    iso.HalfLife = Constants.STABLE;
                    iso.DecayConst = Constants.ln2 / Constants.STABLE;
                }
                else
                {
                    iso.HalfLife = r.c1;
                    iso.DecayConst = Constants.ln2 / r.c1;
                }

                line = streamReader.ReadLine();
                line = streamReader.ReadLine();
                r = ENDFSplitCONT(line);
                int rt = Convert.ToInt16(r.n2);

                iso.NRTYPES = r.n2;
                if (r.n2 == 0) iso.STABLE = true;
                iso.DecayProbob[0] = 0.0;
                iso.DecayProbob[1] = 0.0;
                iso.DecayProbob[2] = 0.0;
                iso.DecayProbob[3] = 0.0;
                iso.DecayProbob[4] = 0.0;
                iso.DecayProbob[5] = 0.0;
                iso.DecayProbob[6] = 0.0;

                for (int i = 0; i < rt; i++)
                {
                    line = streamReader.ReadLine();
                    r = ENDFSplitCONT(line);
                    iso.DecayEnergy = r.l1;

                    iso.DecayProbob[(int)r.c1] = r.n1;
                    iso.DecayType[i] = (int)r.c1;
                }
            }

            if (found) return 1;
            else return 0;
        }

        int GetNeuRecInfMF3(Isotope iso, int ZAID, int MT)
        {
            int mat = 0, mfs, mts;
            string s, line;
            int mfsearch = 3, mtsearch = MT;
            string fn = IsotopeFileName(iso, ZAID, FILETYP.NEUTRON);

            FileStream fileStream;
            try
            {
                fileStream = new FileStream(fn, FileMode.Open, FileAccess.Read);
            }
            catch (FileNotFoundException ex)
            {
                return -1;
            }

            bool found = false;
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                while ((line = streamReader.ReadLine()) != null)
                {
                    if (line.Length < 75) continue;

                    s = line.Substring(66, 4); mat = Convert.ToInt16(s);
                    s = line.Substring(70, 2); mfs = Convert.ToInt16(s);
                    s = line.Substring(72, 3); mts = Convert.ToInt16(s);
                    if (mfs == mfsearch && mts == mtsearch)
                    {
                        found = true;
                        mfs = mfsearch;
                        mts = mtsearch;
                        //Record r = ENDFSplitCONT();
                        break;
                    }

                    /*** not found */
                    if ((mfs > mfsearch) || ((mfs == mfsearch) && (mts > mtsearch)))
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
                    int NumCSData = Convert.ToInt16(r.c1);

                    i = -1;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        if (line.Length < 75) continue;

                        s = line.Substring(66, 4); mat = Convert.ToInt16(s);
                        s = line.Substring(70, 2); mfs = Convert.ToInt16(s);
                        s = line.Substring(72, 3); mts = Convert.ToInt16(s);

                        r = ENDFSplitCONT(line);

                        i++; iso.En_ng.Add(r.c1); iso.Cs_ng.Add(r.c2); if (i >= NumCSData) break;
                        i++; iso.En_ng.Add(r.l1); iso.Cs_ng.Add(r.l2); if (i >= NumCSData) break;
                        i++; iso.En_ng.Add(r.n1); iso.Cs_ng.Add(r.n2); if (i >= NumCSData) break;

                        if (mfs != mfsearch || mts == 2) break;

                    }

                     
                    //////////////////////////////////////////////////
                    //  
                    //  This part should be implemented with Maxwell distribution		
                    //
                    //////////////////////////////////////////////////
                    double cs_sum = 0.0;
                    double flux_sum = 0.0;

                    for (int k = 0; k < i; k++)
                    {
                        var temp_flux = NeutronSpectra.MaxwellCurve(iso.En_ng[k]);
                        cs_sum += iso.Cs_ng[k] * temp_flux;
                        flux_sum += temp_flux;
                    }
                    iso.CS_ng_avg = cs_sum / flux_sum * Constants.barn;
                    iso.cs_ng_file_num = 0;
                    return NumCSData;
                }
                else
                {
                    iso.cs_ng_file_num = -1;
                    return (-1);
                }
            }
        }

        void WriteCSToFile(string fn, int DataCount)
        {

        }
        
        #endregion
    }
}
