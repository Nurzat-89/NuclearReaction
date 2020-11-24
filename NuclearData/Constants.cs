using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuclearData
{
    public static class Constants
    {
        public const double STABLE = 1.0E40;
        public const double barn = 1.0E-24;
        public const double k = 1.38064852E-23;
        public const double ln2 = 0.69314718056;
        public const double e = 2.718281828459;
        public const double q_electron = 1.60217662e-19;
        public const double NaturalLeadDensity = 11.34; // g/cm^3
        public const double N_Avogadro = 6.02214129E23; // 1/mole
        public const double aem = 931.494095; // atomic unit of mass  MeV/c^2 
        public const double MassOfHe4 = 4.00260325413 * aem;
        public const double MassOfNeutron = 939.5654133; // MeV/c^2
        public const double MassOfProton = 938.2720813; // MeV/c^2
        public const double c = 299792458.0; // meter/sec 
        public const double OneYearSec = 31536000.0;
        public const double OneMonthSec = 2592000.0;
        public const double OneDaySec = 86400.0;
        public const double OneHourSec = 3600.0;
        public enum FILETYP { DECAY, NEUTRON, FISSION };
        public enum RTYPE { GAMMA, BETA, EC, IT, ALFA, N, SF, P, BETA_N, BETA_A, UNDEF };
        public enum REACT { N_el, N_inl, N_tot, N_G, N_2N, N_P, N_A};
        public static Dictionary<int, REACT> REACTIONTYPE = new Dictionary<int, REACT>() {
            {1, REACT.N_tot },
            {2, REACT.N_el },
            {3, REACT.N_inl },
            {102, REACT.N_G },
            {16, REACT.N_2N },
            {103, REACT.N_P },
            {107, REACT.N_A },
        };
        public static Dictionary<REACT, string> REACTname = new Dictionary<REACT, string>()
        {
            {REACT.N_G, "(n,g)" },
            {REACT.N_A, "(n,a)" },
            {REACT.N_2N, "(n,2n)" },
            {REACT.N_el, "(n,el)" },
            {REACT.N_inl, "(n,inl)" },
            {REACT.N_P, "(n,p)" },
            {REACT.N_tot, "(n,tot)" },
        };
        public static Dictionary<double, RTYPE> DECAYTYPE = new Dictionary<double, RTYPE>() {
            {0, RTYPE.GAMMA },
            {1, RTYPE.BETA },
            {1.4, RTYPE.BETA_A },
            {1.5, RTYPE.BETA_N },
            {2, RTYPE.EC },
            {3, RTYPE.IT },
            {4, RTYPE.ALFA },
            {5, RTYPE.N },
            {5.5, RTYPE.UNDEF },
            {6, RTYPE.SF },
            {7, RTYPE.P }
        };
        public static readonly string[] ElementNames = { 
            "Nn", "H", "He", 
            "Li", "Be", "B", "C", "N", "O", "F" ,                       "Ne", 
            "Na", "Mg", "Al", "Si", "P", "S", "Cl",                     "Ar", 
            "K", "Ca", "Sc", "Ti", "V", "Cr", "Mn", "Fe", "Co", "Ni", 
            "Cu", "Zn", "Ga", "Ge", "As", "Se", "Br",                   "Kr", 
            "Rb", "Sr", "Y", "Zr", "Nb", "Mo", "Tc", "Ru", "Rh", "Pd", 
            "Ag", "Cd", "In", "Sn", "Sb", "Te", "I",                    "Xe", 
            "Cs", "Ba", 
            "La", "Ce", "Pr", "Nd", "Pm", "Sm", "Eu", "Gd", "Tb", "Dy", "Ho", "Er", "Tm", "Yb", "Lu", 
            "Hf", "Ta", "W", "Re", "Os", "Ir", "Pt", 
            "Au", "Hg", "Tl", "Pb", "Bi", "Po", "At", "Rn", 
            "Fr", "Ra", 
            "Ac", "Th", "Pa", "U", "Np", "Pu", "Am", "Cm", "Bk", "Cf", "Es", "Fm", "Md", "No", "Lr", 
            "Rf", "Db", "Sg", "Bh", "Hs", "Mt", "Ds", "Rg" };
    }
}
