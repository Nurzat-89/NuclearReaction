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
        public NeutronSpectra NeutronSpectra { get; set; }
        public List<Macs> MacsList { get; set; }
        public BurnUp(List<Isotope> isotopes, NeutronSpectra neutronSpectra)
        {
            Isotopes = isotopes;
            NeutronSpectra = neutronSpectra;
            initialize(isotopes.Count, neutronSpectra);
        }
        public BurnUp(List<Isotope> isotopes, NeutronSpectra neutronSpectra, List<Macs> macsList)
        {
            Isotopes = isotopes;
            NeutronSpectra = neutronSpectra;
            initialize(isotopes.Count, macsList);
        }
        private void initialize(int count, NeutronSpectra neutronSpectra)
        {
            setAvgCrossSections(neutronSpectra);
            initilaize(count);
        }
        private void initialize(int count, List<Macs> macsList)
        {
            MacsList = macsList;
            setAvgCrossSections(macsList);
            initilaize(count);
        }

        private void initilaize(int count)
        {
            Matrix = new MatrixDouble(count, count);
            SetBurnMatrix();
        }

        public void setAvgCrossSections(NeutronSpectra neutronSpectra)
        {
            foreach (var isotope in Isotopes)
                foreach (var cs in isotope.CrossSections)
                    cs.Value.SetAvgCs(neutronSpectra);
        }
        public void setAvgCrossSections(List<Macs> macsList)
        {
            foreach (var isotope in Isotopes)
            {
                var macs = macsList.FirstOrDefault(x => x.Element.ZAID == isotope.ZAID);
                try
                {
                    if (macs != null) isotope.CrossSections[Constants.REACT.N_G].AvgCs = macs.AvgCs;
                }
                catch(Exception) { }
            }
        }
        public void SetBurnMatrix()
        {
            Matrix.Zero();

            for (int i = 0; i < Isotopes.Count; i++)
            {
                int iAlfa = Isotopes.FindIndex(x => x.A == Isotopes[i].A + 4 && x.Z == Isotopes[i].Z + 2);  // alfa decay
                int iBeta = Isotopes.FindIndex(x => x.A == Isotopes[i].A && x.Z == Isotopes[i].Z - 1);      // beta decay
                int iEcup = Isotopes.FindIndex(x => x.A == Isotopes[i].A && x.Z == Isotopes[i].Z + 1);      // EC decay
                int iCapt = Isotopes.FindIndex(x => x.A == Isotopes[i].A - 1 && x.Z == Isotopes[i].Z);      // (n,g) 

                try
                {
                    if (iAlfa != -1)
                    {
                        double prob = Isotopes[iAlfa].Decays[Constants.RTYPE.ALFA].DecayProb;
                        Matrix.Arr[i, iAlfa] += Isotopes[iAlfa].DecayConst * prob;
                    }
                }
                catch (Exception) { }
                try
                {
                    if (iBeta != -1)
                    {
                        double prob = Isotopes[iBeta].Decays[Constants.RTYPE.BETA].DecayProb;
                        Matrix.Arr[i, iBeta] += Isotopes[iBeta].DecayConst * prob;
                    }
                }
                catch (Exception) { }
                try
                {
                    if (iEcup != -1)
                    {
                        double prob = Isotopes[iEcup].Decays[Constants.RTYPE.EC].DecayProb;
                        Matrix.Arr[i, iEcup] += Isotopes[iEcup].DecayConst * prob;
                    }
                }
                catch (Exception) { }
                try 
                {
                    if (iCapt != -1)
                    {
                        Matrix.Arr[i, iCapt] += NeutronSpectra.Flux * Isotopes[iCapt].CrossSections[Constants.REACT.N_G].AvgCs * Constants.barn;                        
                    }
                }            
                catch (Exception) { }

                try { Matrix.Arr[i, i] += -NeutronSpectra.Flux * Isotopes[i].CrossSections[Constants.REACT.N_G].AvgCs * Constants.barn; } catch (Exception) { }
                Matrix.Arr[i, i] += -Isotopes[i].DecayConst;
            }
        }        
        public void SetBurnMatrix_old()
        {
            Matrix.Zero();
            for (int i = 0; i < Isotopes.Count; i++)
            {
                for (int j = 0; j < Isotopes.Count; j++)
                {
                    //if (DecayProbability.Arr[i, j] != 0.0)
                      //  Matrix.Arr[i, j] += Isotopes[j].DecayConst;
                    //if (CaptureProbability.Arr[i, j] != 0.0)
                      //  Matrix.Arr[i, j] += NeutronSpectra.Flux * Isotopes[j].CrossSections[Constants.REACT.N_G].AvgCs * Constants.barn;
                }
                try { Matrix.Arr[i, i] += -NeutronSpectra.Flux * Isotopes[i].CrossSections[Constants.REACT.N_G].AvgCs * Constants.barn; } catch (Exception ex) { }
                Matrix.Arr[i, i] += -Isotopes[i].DecayConst;
            }
        }
    }
}
