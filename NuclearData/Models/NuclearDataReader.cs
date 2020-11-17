using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NuclearData.Constants;

namespace NuclearData.Models
{
    public abstract class NuclearDataReader : INuclearDataReader
    {
        public FILETYP ReactionType { get; set; }
        private const int FIELD_WIDTH = 11;
        protected int MF { get; set; }
        protected int MT { get; set; }
        public abstract Isotope Read(Isotope isotope, int Z, int A, string fileName);
        public FileStream GetFileStream(int Z, int A, FILETYP fileType) 
        {
            string fn = Globals.GetIsotopeFile(Z, A, fileType);

            FileStream fileStream;
            try
            {
                fileStream = new FileStream(fn, FileMode.Open, FileAccess.Read);
            }
            catch (FileNotFoundException ex)
            {
                return null;
            }
            return fileStream;
        }
        public Record ENDFSplitCONT(string line)
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
        private double ENDFPadExp(string str)
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
    }
}
