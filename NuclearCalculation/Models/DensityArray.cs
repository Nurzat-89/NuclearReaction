using NuclearData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuclearCalculation.Models
{
    public class DensityArray
    {
        private List<NuclideDensity> _nuclideDensities;
        public List<NuclideDensity> NuclideDensities { get
            {
                return _nuclideDensities;
            }
            set
            {
                _nuclideDensities = value;
            }
        }
        public Matrix<double> Density { get; set; }
        public Matrix<double> InitialDensity { get; set; }
        public DensityArray(List<NuclideDensity> nuclideDensities)
        {
            _nuclideDensities = nuclideDensities;
            Density = new MatrixDouble(nuclideDensities.Count, 1);
            InitialDensity = new MatrixDouble(nuclideDensities.Count, 1);
            int i = 0;
            foreach (var nuclide in nuclideDensities)
            {
                Density.Arr[i, 0] = nuclide.Density;
                InitialDensity.Arr[i, 0] = nuclide.Density;
                i++;
            }
        }
        public void Normolize() 
        {
            Density.Normolize();
        }
    }
}
