using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalysisCode
{
    public class Isotope
    {
        #region Properties

        public int A, Z, I;
        public int ZAID;
        public int MAT;
        public string Name;
        public string ElementName;
        public double AtomicMass;
        public double HalfLife;
        public double DecayConst;
        public double NRTYPES;
        public double DecayEnergy;
        public double[] DecayProbob = { 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 };
        public enum RTYPE { GAMMA, BETA, EC, IT, ALFA, N, SF, P }; 
        public int[] DecayType = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public bool STABLE;
        public double CS_ng_avg;
        public double CS_n2n;
        public double CS_nf;
        public double CS_na;
        public List<double> En_ng { get; set; }
        public List<double> Cs_ng { get; set; }
        public int cs_ng_file_num;
        string[] RTYPNAME = { "GAMMA", "BETA", "EC", "IT", "ALFA", "N", "SF", "P" };

        #endregion

        #region Methods

        public Isotope()
        {
	        STABLE = false;
            En_ng = new List<double>();
            Cs_ng = new List<double>();
        }

        public void ShowIsotope()
        {
            Console.Write("\n-----------------------------------------------\n");
            if (Name != null) Console.Write("| Information of " + Name + " isotope:\n");
            Console.Write("| Z=" + Z + "  A=" + A+ "  Amass=" + AtomicMass + " amu\n");
            Console.Write("| HF=" + HalfLife + "\n");
            Console.Write("| CS_avg=" + (CS_ng_avg / Constants.barn) + "\n");

            for (int i = 0; i < NRTYPES; i++)
            {
                Console.Write("| DECAY MODE = " + RTYPNAME[DecayType[i]] + ":\n");
                Console.Write("| DE=" + DecayEnergy + " eV\tDP=" + DecayProbob[DecayType[i]] * 100 + " %\n");
            }
            Console.Write("-----------------------------------------------\n");
        }

        public static string ShowIsotope(Isotope isotope)
        {
            string str = "";
            if (isotope.Name != null) str += "Information of " + isotope.Name + " isotope:"+ Environment.NewLine;
            str += "Z=" + isotope.Z + "  A=" + isotope.A + Environment.NewLine +"  Amass=" + isotope.AtomicMass + " amu"+ Environment.NewLine;
            str += "HF=" + isotope.HalfLife + Environment.NewLine;
            str += "CS=" + (isotope.CS_ng_avg / Constants.barn) + Environment.NewLine;

            for (int i = 0; i < isotope.NRTYPES; i++)
            {
                str += "DECAY MODE = " + isotope.RTYPNAME[isotope.DecayType[i]] + ":"+ Environment.NewLine;
                str += "DE=" + isotope.DecayEnergy + " eV\nDP=" + isotope.DecayProbob[isotope.DecayType[i]] * 100 + " %"+ Environment.NewLine;
            }
            return str;
        }

        #endregion
    }
}
