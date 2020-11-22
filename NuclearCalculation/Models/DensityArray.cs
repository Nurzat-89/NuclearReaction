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
        public DensityArray(List<NuclideDensity> nuclideDensities)
        {
            _nuclideDensities = nuclideDensities;
            Density = new MatrixDouble(nuclideDensities.Count, 1);
            int i = 0;
            foreach (var nuclide in nuclideDensities)
            {
                Density.Arr[i, 0] = nuclide.Density;
                i++;
            }
        }
        public void Normolize() 
        {
            double sum = 0.0;
            for (int i = 0; i < Density.Col; i++)
                for (int j = 0; j < Density.Row; j++)
                    sum = sum + Density.Arr[i, j];

            for (int i = 0; i < Density.Col; i++)
                for (int j = 0; j < Density.Row; j++)
                    Density.Arr[i, j] = Density.Arr[i, j] / sum;
        }
    }
}
