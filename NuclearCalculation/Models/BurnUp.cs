using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NuclearData;
using NuclearData.Models;

namespace NuclearCalculation.Models
{
    public class BurnUp
    {
        public List<Isotope> Isotopes { get; set; }
        public Matrix<double> Matrix { get; set; }
        public Matrix<double> DecayProbability { get; set; }
        public Matrix<double> CaptureProbability { get; set; }
        public NeutronSpectra NeutronSpectra { get; set; }
        public BurnUp(List<Isotope> isotopes, NeutronSpectra neutronSpectra)
        {
            Isotopes = isotopes;
            NeutronSpectra = neutronSpectra;
            initialize(isotopes.Count, neutronSpectra);
        }

        private void initialize(int count, NeutronSpectra neutronSpectra)
        {
            Matrix = new MatrixDouble(count, count);
            DecayProbability = new MatrixDouble(count, count);
            CaptureProbability = new MatrixDouble(count, count);
            setAvgCrossSections(neutronSpectra);
            setDecayProbabilityMatrix();
            setCaptureProbabilityMatrix();
            SetBurnMatrix();
        }

        private void setAvgCrossSections(NeutronSpectra neutronSpectra)
        {
            foreach (var isotope in Isotopes)
                foreach (var cs in isotope.CrossSections)
                    cs.Value.SetAvgCs(neutronSpectra);
        }
        private void setDecayProbabilityMatrix()
        {
            for (int i = 0; i < Isotopes.Count; i++)
            {
                int iAlfa = Isotopes.FindIndex(x => x.A == Isotopes[i].A + 4 && x.Z == Isotopes[i].Z + 2);
                int iBeta = Isotopes.FindIndex(x => x.A == Isotopes[i].A     && x.Z == Isotopes[i].Z - 1);
                int iEcup = Isotopes.FindIndex(x => x.A == Isotopes[i].A     && x.Z == Isotopes[i].Z + 1);

                try 
                {
                    if (iAlfa != -1)
                    {
                        DecayProbability.Arr[i, iAlfa] = Isotopes[iAlfa].Decays[Constants.RTYPE.ALFA].DecayProb;
                    }
                } 
                catch (Exception ex) { }
                try 
                {
                    if (iBeta != -1)
                    {
                        DecayProbability.Arr[i, iBeta] = Isotopes[iBeta].Decays[Constants.RTYPE.BETA].DecayProb;
                    }
                } 
                catch (Exception ex) { }
                try 
                {
                    if (iEcup != -1)
                    {
                        DecayProbability.Arr[i, iEcup] = Isotopes[iEcup].Decays[Constants.RTYPE.EC].DecayProb;
                    }
                } 
                catch (Exception ex) { }
            }

        }
        private void setCaptureProbabilityMatrix()
        {
            for (int i = 0; i < Isotopes.Count; i++)
            {
                int index = Isotopes.FindIndex(x => x.A == Isotopes[i].A - 1 && x.Z == Isotopes[i].Z);
                if (index != -1)
                    try { if (Isotopes[index].CrossSections[Constants.REACT.N_G].AvgCs != 0.0) CaptureProbability.Arr[i, index] = 1.0; } catch(Exception ex) { }
            }
        }
        public void SetBurnMatrix()
        {
            for (int i = 0; i < Isotopes.Count; i++)
            {
                for (int j = 0; j < Isotopes.Count; j++)
                {
                    if (DecayProbability.Arr[i, j] != 0.0)
                        Matrix.Arr[i, j] += Isotopes[j].DecayConst;
                    if (CaptureProbability.Arr[i, j] != 0.0)
                        Matrix.Arr[i, j] += NeutronSpectra.Flux * Isotopes[j].CrossSections[Constants.REACT.N_G].AvgCs;
                }
                try { Matrix.Arr[i, i] += -NeutronSpectra.Flux * Isotopes[i].CrossSections[Constants.REACT.N_G].AvgCs; } catch (Exception ex) { }
                Matrix.Arr[i, i] += -Isotopes[i].DecayConst;
            }
        }
    }
}
