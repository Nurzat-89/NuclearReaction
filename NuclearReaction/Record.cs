using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalysisCode
{
    public class Record
    {
        #region Fields
        public double c1;
        public double c2;
        public double l1;
        public double l2;
        public double n1;
        public double n2;
        #endregion

        #region Properties

        #endregion

        #region Methods

        public Record()
        {
            c1 = 0.0; c2 = 0.0; l1 = 0; l2 = 0; n1 = 0; n2 = 0;
        }
        public Record(double a, double b, double c, double d, double e, double f)
        {
            c1 = a; c2 = b; l1 = c; l2 = d; n1 = e; n2 = f;
        }
        public void SetRecord(double a, double b, double c, double d, double e, double f)
        {
            c1 = a; c2 = b; l1 = c; l2 = d; n1 = e; n2 = f;
        }

        #endregion
    }
}
