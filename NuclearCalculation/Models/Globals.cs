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
        public static int Factorial(int n)
        {
            int s = 1;
            if (n != 0)
                for (int i = 1; i <= n; i++) s = s * i;

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
