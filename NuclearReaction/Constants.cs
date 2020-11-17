using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalysisCode
{
    public static class Constants
    {
        public const double STABLE = 1.0E40;
        public const double barn = 1.0E-24;
        public const double k = 1.38064852E10-23;
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
    }
}
