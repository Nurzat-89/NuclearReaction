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
        private Matrix<double> _density;
        public List<NuclideDensity> NuclideDensities { get
            {
                return _nuclideDensities;
            }
            set
            {
                _nuclideDensities = value;
            }
        }
        public Matrix<double> Density { get 
            {
                return _density;
            } 
            set 
            {
                _density = value;
                int i = 0;
                foreach (var nuclDens in _nuclideDensities)
                {
                    nuclDens.Density = _density.Arr[i, 0];
                    i++;
                }
            } 
        }
        public Matrix<double> InitialDensity { get; set; }
        public DensityArray(List<NuclideDensity> nuclideDensities)
        {
            _nuclideDensities = nuclideDensities;
            _density = new MatrixDouble(nuclideDensities.Count, 1);
            InitialDensity = new MatrixDouble(nuclideDensities.Count, 1);
            int i = 0;
            foreach (var nuclide in nuclideDensities)
            {
                _density.Arr[i, 0] = nuclide.Density;
                InitialDensity.Arr[i, 0] = nuclide.Density;
                i++;
            }
        }
        public void Normolize() 
        {
            _density.Normolize();
            int i = 0;
            foreach (var nuclDens in _nuclideDensities)
            {
                nuclDens.Density = _density.Arr[i, 0];
                i++;
            }
        }
    }
}
