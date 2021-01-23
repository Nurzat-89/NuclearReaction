using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace NuclearCalculation.Models
{
    public static class Globals
    {
        public delegate void ExpStatusChangedDelegate(int count);

        public static readonly double[] MMPA_a12 = {
            5.19639720874541e-6,
            -1.58887455974832e-4,
            1.97407148544813e-3,
            -1.19289002583794e-2,
            4.79238202896580e-2,
            -1.52250075898093e-1,
            3.42207028551248e-1,
            -4.37433515001117e-1,
            2.04811856320297e-1,
            1.15260842884047e-1,
            -1.23122052981765e-1,
            -1.34885826765661e-2,
            2.62009616934767e-2
        };
        public static readonly double[] MMPA_a16 = {
            9.55818297829682e-6  ,
            -2.21884266813879e-4 ,
            2.34816021434733e-3  ,
            -1.48316170495578e-2 ,
            6.20732505511125e-2  ,
            -1.79379941734168e-1 ,
            3.52530860768316e-1  ,
            -4.26657273240572e-1 ,
            2.10349191740789e-1  ,
            1.50152179516416e-1  ,
             -2.12029252834189e-1,
             -3.32538652145767e-2,
             1.22178202678754e-1 ,
             4.35315041682305e-3 ,
             -4.55089821578535e-2,
             -1.60727919677468e-4,
             8.04903136564369e-3 
        };
        public static readonly double[] MMPA_a28 = {
            7.69458396243680e-10  ,
            -3.22627179248301e-8  ,
            6.44439457424640e-7   ,
            -8.15109343402427e-6  ,
            7.30114104026411e-5   ,
            -4.90985306962261e-4  ,
            2.56678427090052e-3   ,
            -1.06438217432729e-2  ,
            3.53063629378636e-2   ,
            -9.35659121096769e-2  ,
             1.95920884545500e-1  ,
             -3.15115232698687e-1 ,
             3.62061277744097e-1  ,
             -2.32462061889856e-1 ,
             -4.87401222134409e-2 ,
             2.42163199304149e-1  ,
             -1.27733928410003e-1 ,
             -1.28005047860850e-1 ,
             1.47052397448686e-1  ,
             5.08674398882920e-2  ,
             -1.06761307507097e-1 ,
             -1.59572970902370e-2 ,
             5.78761288109387e-2  ,
             3.75708391755245e-3  ,
             -2.25453782741934e-2 ,
             -5.82950429866301e-4 ,
             5.57282450020625e-3  ,
             4.37693751702772e-5  ,
             -6.49580473175483e-4
        };
        public static readonly double[] MMPA_a32 = {
            3.28979735872738e-11 ,
            -1.58916844491099e-9 ,
            3.67820454991818e-8  ,
            -5.42102978872146e-7 ,
            5.70945430126668e-6  ,
            -4.56738376635576e-5 ,
            2.87599439571872e-4  ,
            -1.45743552929181e-3 ,
            6.02719933663635e-3  ,
            -2.04839279890385e-2 ,
             5.72047094494963e-2 ,
             -1.30239342084535e-1,
             2.37375193939405e-1 ,
             -3.33263630944967e-1,
             3.27390685838193e-1 ,
             -1.52635962819998e-1,
             -1.14728463172040e-1,
             2.41197225880137e-1 ,
             -8.15420042770902e-2,
             -1.55339492153136e-1,
             1.35971357413276e-1 ,
             7.33867740449378e-2 ,
             -1.15986977045075e-1,
             -2.79633313486442e-2,
             7.37831013682762e-2 ,
             8.52011363362550e-3 ,
             -3.57914361107692e-2,
             -1.94605446533440e-3,
             1.24721515959643e-2 ,
             2.92704265189227e-4 ,
             -2.75700953444178e-3,
             -2.14229591230169e-5,
             2.88145489362067e-4
        };
        public static readonly double[] ThetaReal = {
            0.0,
            -8.8977731864688888199,
            -3.7032750494234480603,
            -0.2087586382501301251,
            3.9933697105785685194,
            5.0893450605806245066,
            5.6231425727459771248,
            2.2697838292311127097
        };
        public static readonly double[] ThetaImag = {
            0.0,
            1.6630982619902085304E1,
            1.3656371871483268171E1,
            1.0991260561901260913E1,
            6.0048316422350373178,
            3.5888240290270065102,
            1.1940690463439669766,
            8.4617379730402214019
        };
        public static readonly double[] AlphaReal = {
            1.8321743782540412751E-14,
            -7.1542880635890672853E-5,
            9.4390253107361688779E-3,
            -3.7636003878226968717E-1,
            -2.3498232091082701191E01,
            4.6933274488831293047E01,
            -2.7875161940145646468E01,
            4.8071120988325088907E00
        };
        public static readonly double[] AlphaImag = {
            0.0,
            1.4361043349541300111E-4,
            -1.7184791958483017511E-2,
            3.3518347029450104214E-1,
            -5.8083591297142074004,
            4.5643649768827760791E1,
            -1.0214733999056451434E2,
            -1.3209793837428723881
        };

        public static List<Complex> Theta = new List<Complex>()
        {
            new Complex(ThetaReal[0],ThetaImag[0]),
            new Complex(ThetaReal[1],ThetaImag[1]),
            new Complex(ThetaReal[2],ThetaImag[2]),
            new Complex(ThetaReal[3],ThetaImag[3]),
            new Complex(ThetaReal[4],ThetaImag[4]),
            new Complex(ThetaReal[5],ThetaImag[5]),
            new Complex(ThetaReal[6],ThetaImag[6]),
            new Complex(ThetaReal[7],ThetaImag[7]),
        };
        public static Dictionary<string, int> TimeScale = new Dictionary<string, int>()
        {
            {"sec"      ,1          },
            {"mins"     ,60         },
            {"hours"    ,3600       },
            {"days"     ,86400      },
            {"months"   ,2592000    },
            {"years"    ,31536000   },
        };

        public static List<Complex> Alpha = new List<Complex>()
        {
            new Complex(AlphaReal[0], AlphaImag[0]),
            new Complex(AlphaReal[1], AlphaImag[1]),
            new Complex(AlphaReal[2], AlphaImag[2]),
            new Complex(AlphaReal[3], AlphaImag[3]),
            new Complex(AlphaReal[4], AlphaImag[4]),
            new Complex(AlphaReal[5], AlphaImag[5]),
            new Complex(AlphaReal[6], AlphaImag[6]),
            new Complex(AlphaReal[7], AlphaImag[7]),
        };
        public static Dictionary<Type, Type > MatrixTypes = new Dictionary<Type, Type>() {
            {typeof(double), typeof(MatrixDouble) },
            {typeof(Complex), typeof(MatrixComplex) },
        }; 
        public static double Factorial(int n)
        {
            double s = 1.0;
            if (n != 0)
                for (int i = 1; i <= n; i++) s = s * Convert.ToDouble(i);
            return s;
        }
        public static T DeepClone<T>(T obj)
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, obj);
                ms.Position = 0;

                return (T)formatter.Deserialize(ms);
            }
        }
    }
}
