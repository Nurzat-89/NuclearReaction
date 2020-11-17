using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalysisCode
{
    public class BurnUp
    {
        #region Properties
        public Matrix Exp { get; set; }
        public double NeutronfluxLevel { get; set; } // neutron flux level
        public int FluxNumberOfOneGroup { get; set; }
        public int NuclNum { get; set; }
        public bool isOneGroupCalculation { get; set; }
        public int InitialIndex { get; set; }
        public Matrix A { get; set; }
        public Matrix InitailDensities;
        public Matrix NuclideDensity;
        public double[] HeatDensityOfEachNuclide { get; set; }
        public double[] OneGroupFluxLevel { get; set; }
        public Matrix MatrixDecayProbOfNuclides;
        public Matrix MatrixCaptureProbOfNuclides;
        public List<Isotope> Isotopes { get; set; }

        public Matrix MatrixDerivativeOfBurnUp;
        #endregion

        #region Methods
        public Matrix DerivativeBurnUpMatrixByLambda()
        {
            Matrix dA = new Matrix(NuclNum, NuclNum);
            dA.Zero();

            for (int i = 0; i < NuclNum; i++)
            {
                for (int j = 0; j < NuclNum; j++)
                {
                    if (MatrixCaptureProbOfNuclides.Arr[i, j] != 0.0) dA.Arr[i, j] += NeutronfluxLevel * Isotopes[j].CS_ng_avg;
                }
                dA.Arr[i, i] += -NeutronfluxLevel * Isotopes[i].CS_ng_avg;
            }
            return dA;
        }

        public BurnUp(List<Isotope> isotopes, double flux)
        {
            Isotopes = isotopes;
            NuclNum = Isotopes.Count;
            Exp = new Matrix(NuclNum, NuclNum);
            A = new Matrix(NuclNum, NuclNum);
            InitailDensities = new Matrix(NuclNum, 1);
            NuclideDensity = new Matrix(NuclNum, 1);
            HeatDensityOfEachNuclide = new double[NuclNum];
            OneGroupFluxLevel = new double[NuclNum];
            MatrixDecayProbOfNuclides = new Matrix(NuclNum, NuclNum);
            MatrixCaptureProbOfNuclides = new Matrix(NuclNum, NuclNum);
            MatrixDerivativeOfBurnUp = new Matrix(NuclNum, NuclNum);

            int index =  Isotopes.FindIndex(x => x.ZAID == 82209);
            InitailDensities.Arr[index, 0] = 1.0;
            //NeutronfluxLevel = flux;
            //SetMatrixDecayProb();
            //SetMatrixCaptureProb();
        }

        public BurnUp(int nucNumber, double flux = 1.0E14)
        {            
            #region Init
            Exp = new Matrix(NuclNum, NuclNum);
            A = new Matrix(NuclNum, NuclNum);

            InitailDensities = new Matrix(NuclNum, 1);
            NuclideDensity = new Matrix(NuclNum, 1);
            HeatDensityOfEachNuclide = new double[NuclNum];
            OneGroupFluxLevel = new double[NuclNum];
            MatrixDecayProbOfNuclides = new Matrix(NuclNum, NuclNum);
            MatrixCaptureProbOfNuclides = new Matrix(NuclNum, NuclNum);
            MatrixDerivativeOfBurnUp = new Matrix(NuclNum, NuclNum);
            #endregion

            double initialDens = 0.0;
            double ng_cs = 0.0;
            for (int k = 0; k < NuclNum; k++)
            {
                initialDens = 0.0;
                if (Isotopes[k].A == 56 && Isotopes[k].Z == 26) initialDens = 1.0;
                ng_cs = 0.0;
                if (Isotopes[k].cs_ng_file_num != -1) ng_cs = Isotopes[k].CS_ng_avg;
                if (Isotopes[k].DecayProbob[4] > 1.0 || Isotopes[k].DecayProbob[1] > 1.0 || Isotopes[k].DecayProbob[2] > 1.0)
                {
                    int ii = 0;
                }
                SetNuclides(k, Isotopes[k].Name, Isotopes[k].A, Isotopes[k].Z, Isotopes[k].AtomicMass, initialDens, Isotopes[k].HalfLife, Isotopes[k].DecayEnergy, Isotopes[k].DecayProbob[(int)Isotope.RTYPE.ALFA], Isotopes[k].DecayProbob[(int)Isotope.RTYPE.BETA], Isotopes[k].DecayProbob[(int)Isotope.RTYPE.EC], ng_cs);

            }

            A.Zero();
            InitailDensities.Zero();
            MatrixDecayProbOfNuclides.Zero();
            MatrixCaptureProbOfNuclides.Zero();
        }

        public void SetNuclides(int numNuc, string _name, int A, int Z, double atomMass, double _InitialDensity, double _halfLife, double decayEnergy, double alfaDecay_prob, double betaMinusDecay_prob, double betaPlusDecay_prob, double _capCS)
        {
            NuclideDensity.Arr[numNuc, 0] = _InitialDensity;// * concen * barn;
            InitailDensities.Arr[numNuc, 0] = _InitialDensity;// * concen * barn;
            if (_InitialDensity == 1.0) InitialIndex = numNuc;
            if (alfaDecay_prob > 1.0)
                return;
        }

        public void SetNuclide(Isotope isotope)
        {

        }

        public void SetMatrixDecayProb()
        {
            int ind_Alfa = 0;
            int ind_MinusBeta = 0;
            int ind_PlusBeta = 0;

            for (int i = 0; i < NuclNum; i++)
            {
                ind_Alfa = -1;
                ind_MinusBeta = -1;
                ind_PlusBeta = -1;

                for (int j = 0; j < NuclNum; j++)
                {
                    if ((Isotopes[j].A == (Isotopes[i].A + 4)) && ((Isotopes[j].Z == (Isotopes[i].Z + 2)))) ind_Alfa = j;
                    if ((Isotopes[j].A == Isotopes[i].A) && ((Isotopes[j].Z == (Isotopes[i].Z - 1)))) ind_MinusBeta = j;
                    if ((Isotopes[j].A == Isotopes[i].A) && ((Isotopes[j].Z == (Isotopes[i].Z + 1)))) ind_PlusBeta = j;

                }

                if (ind_Alfa != -1)
                {
                    if (Isotopes[ind_Alfa].DecayProbob[(int)Isotope.RTYPE.ALFA] != 0.0)
                        MatrixDecayProbOfNuclides.Arr[i,ind_Alfa] = Isotopes[ind_Alfa].DecayProbob[(int)Isotope.RTYPE.ALFA];
                    if (Isotopes[ind_Alfa].DecayProbob[(int)Isotope.RTYPE.ALFA] >= 1.0)
                        Isotopes[ind_Alfa].ShowIsotope();
                }

                if (ind_MinusBeta != -1)
                {
                    if (Isotopes[ind_MinusBeta].DecayProbob[(int)Isotope.RTYPE.BETA] != 0.0)
                        MatrixDecayProbOfNuclides.Arr[i,ind_MinusBeta] = Isotopes[ind_MinusBeta].DecayProbob[(int)Isotope.RTYPE.BETA];
                    if (Isotopes[ind_MinusBeta].DecayProbob[(int)Isotope.RTYPE.BETA] >= 1.0)
                        Isotopes[ind_MinusBeta].ShowIsotope();
                }

                if (ind_PlusBeta != -1)
                {
                    if (Isotopes[ind_PlusBeta].DecayProbob[(int)Isotope.RTYPE.EC] != 0.0)
                        MatrixDecayProbOfNuclides.Arr[i, ind_PlusBeta] = Isotopes[ind_PlusBeta].DecayProbob[(int)Isotope.RTYPE.EC];
                    if (Isotopes[ind_PlusBeta].DecayProbob[(int)Isotope.RTYPE.EC] >= 1.0)
                        Isotopes[ind_PlusBeta].ShowIsotope();
                }
            }

        }
        public void SetMatrixCaptureProb()
        {
            int ind_Capture = 0;
            for (int i = 0; i < NuclNum; i++)
            {
                ind_Capture = -1;
                for (int j = 0; j < NuclNum; j++)
                    if ((Isotopes[j].A == (Isotopes[i].A - 1)) && ((Isotopes[j].Z == Isotopes[i].Z))) ind_Capture = j;

                if (ind_Capture != -1)
                    if (Isotopes[ind_Capture].CS_ng_avg != 0.0) MatrixCaptureProbOfNuclides.Arr[i,ind_Capture] = 1.0;
            }
        }

        public void SetMatrixA()
        {
            for (int i = 0; i < NuclNum; i++)
            {
                for (int j = 0; j < NuclNum; j++)
                {
                    if (MatrixDecayProbOfNuclides.Arr[i, j] != 0.0)
                        A.Arr[i, j] += Isotopes[j].DecayConst;
                    if (MatrixCaptureProbOfNuclides.Arr[i, j] != 0.0)
                        A.Arr[i, j] += NeutronfluxLevel * Isotopes[j].CS_ng_avg;
                }
                A.Arr[i, i] += -NeutronfluxLevel * Isotopes[i].CS_ng_avg;
                A.Arr[i, i] += -Isotopes[i].DecayConst;
            }

            MatrixDerivativeOfBurnUp = DerivativeBurnUpMatrixBySigma();
        }
        public void ResetAllToInitialState(double InitialFlux)
        {
            A.Zero();
            NeutronfluxLevel = InitialFlux;

            NuclideDensity.Zero();

            for (int i = 0; i < NuclNum; i++)
            {
                NuclideDensity.Arr[i, 0] = InitailDensities.Arr[i, 0];
            }
            SetMatrixA();
        }
        public Matrix DerivativeBurnUpMatrixBySigma()
        {
            Matrix dA = new Matrix(NuclNum, NuclNum);
            dA.Zero();

            for (int i = 0; i < NuclNum; i++)
            {
                for (int j = 0; j < NuclNum; j++)
                {
                    if (MatrixCaptureProbOfNuclides.Arr[i, j] != 0.0) dA.Arr[i, j] += NeutronfluxLevel * Isotopes[j].CS_ng_avg;
                }
                dA.Arr[i, i] += -NeutronfluxLevel * Isotopes[i].CS_ng_avg;
            }
            return dA;
        }
        public double SensitivityOfNuclideAfterTime(string name, string nameCS, double years, int mesh = 10)
        {
            double concen = Constants.NaturalLeadDensity * Constants.N_Avogadro / 208.0;
            int index = -1;
            int indexCS = -1;
            double scalar = 0;
            double dT = years * 365 / mesh;
            for (int i = 0; i < NuclNum; i++) if (name == Isotopes[i].Name) index = i;
            for (int i = 0; i < NuclNum; i++) if (nameCS == Isotopes[i].Name) indexCS = i;

            Matrix Temp = new Matrix(10, 10);
            Temp.Zero();
            if (index == -1) Console.Write("\nERROR: '" + name + "' name of nuclide does not exist, put correct name!\n\n");
            else
            if (indexCS == -1) Console.Write("\nERROR: '" + nameCS + "' name of nuclide does not exist, put correct name!\n\n");
            else
            {
                Matrix dA = new Matrix(NuclNum, NuclNum);
                dA.Zero();

                for (int i = 0; i < NuclNum; i++)
                {
                    for (int j = 0; j < NuclNum; j++) if (MatrixCaptureProbOfNuclides.Arr[i,j] != 0.0 && j == indexCS) dA.Arr[i,j] += NeutronfluxLevel;
                    if (i == indexCS) dA.Arr[i, i] += -NeutronfluxLevel;
                }
                MatrixDerivativeOfBurnUp = dA;

                List<Matrix> N = new List<Matrix>(mesh);

                for (int i = 0; i < mesh; i++)
                {
                    N[i].setMatrixScale(NuclNum, 1);
                    N[i] = NuclideDensity;
                    NumberDensityChangeAfterDays(dT);
                }

                List<Matrix> N_adj = new List<Matrix>(mesh);

                N_adj[mesh - 1].setMatrixScale(NuclNum, 1);
                N_adj[mesh - 1].Zero();
                N_adj[mesh - 1].Arr[index, 0] = 1.0;

                double dt = dT * 86400;
                Matrix M_t = new Matrix(NuclNum, NuclNum);

                M_t = A.Transpose();
                M_t = M_t * dt;
                M_t = M_t.Exp();
                for (int i = mesh - 2; i >= 0; i--)
                {
                    N_adj[i].setMatrixScale(NuclNum, 1);
                    N_adj[i].Zero();
                    N_adj[i] = M_t * N_adj[i + 1];
                    //cout << "N_adj[i] = " << N_adj[i] << "\n";
                    //N_adj[i].showMatrix();
                }
                //MatrixDerivativeOfBurnUp.showMatrix();
                for (int i = 0; i < mesh; i++)
                {
                    Temp = MatrixDerivativeOfBurnUp * N[i];
                    //Temp.showMatrix();
                    Temp = N_adj[i].Transpose() * Temp;

                    scalar += Temp.Arr[0, 0];
                    //cout << "scalar = " << scalar << "\n";
                }
                //cout << "scalar = " << scalar << "\n";
                scalar = scalar * dt;
                //cout << "scalar = " << scalar* captureCS[indexCS] << "\n";
                scalar = scalar * Isotopes[indexCS].CS_ng_avg / NuclideDensity.Arr[index, 0];
                //cout << "scalar = " << NuclideDensity.arr[index][0] << "\n";
            }
            return scalar;
        }
        public double SensitivityOfDecayDataAfterTime(string name, string nameCS, double years, int mesh = 10)
        {
            double concen = Constants.NaturalLeadDensity * Constants.N_Avogadro / 208.0;
            int index = -1;
            int indexDC = -1;
            double scalar = 0;
            double dT = years * 365 / mesh;
            for (int i = 0; i < NuclNum; i++) if (name == Isotopes[i].Name) index = i;
            for (int i = 0; i < NuclNum; i++) if (nameCS == Isotopes[i].Name) indexDC = i;

            Matrix Temp = new Matrix(10, 10);
            Temp.Zero();
            if (index == -1) Console.Write("\nERROR: '" + name + "' name of nuclide does not exist, put correct name!\n\n");
            else
                if (indexDC == -1) Console.Write("\nERROR: '" + nameCS + "' name of nuclide does not exist, put correct name!\n\n");
            else
            {
                Matrix dA = new Matrix(NuclNum, NuclNum);
                dA.Zero();

                for (int i = 0; i < NuclNum; i++)
                {
                    for (int j = 0; j < NuclNum; j++) if (MatrixDecayProbOfNuclides.Arr[i,j] != 0.0 && j == indexDC) dA.Arr[i,j] += 1.0;
                    if (i == indexDC) dA.Arr[i,i] += -1.0;
                }
                MatrixDerivativeOfBurnUp = dA;

                List<Matrix> N = new List<Matrix>(mesh);

                for (int i = 0; i < mesh; i++)
                {
                    N[i].setMatrixScale(NuclNum, 1);
                    N[i] = NuclideDensity;
                    NumberDensityChangeAfterDays(dT);
                }

                List<Matrix> N_adj = new List<Matrix>(mesh);

                N_adj[mesh - 1].setMatrixScale(NuclNum, 1);
                N_adj[mesh - 1].Zero();
                N_adj[mesh - 1].Arr[index,0] = 1.0;

                double dt = dT * 86400;
                Matrix M_t = new Matrix(NuclNum, NuclNum);

                M_t = A.Transpose();
                M_t = M_t * dt;
                M_t = M_t.Exp();
                for (int i = mesh - 2; i >= 0; i--)
                {
                    N_adj[i].setMatrixScale(NuclNum, 1);
                    N_adj[i].Zero();
                    N_adj[i] = M_t * N_adj[i + 1];
                    //cout << "N_adj[i] = " << N_adj[i] << "\n";
                    //N_adj[i].showMatrix();
                }
                //MatrixDerivativeOfBurnUp.showMatrix();
                for (int i = 0; i < mesh; i++)
                {
                    Temp = MatrixDerivativeOfBurnUp * N[i];
                    //Temp.showMatrix();
                    Temp = N_adj[i].Transpose() * Temp;

                    scalar += Temp.Arr[0,0];
                    //cout << "scalar = " << scalar << "\n";
                }
                //cout << "scalar = " << scalar << "\n";
                scalar = scalar * dt;
                //cout << "scalar = " << scalar* captureCS[indexCS] << "\n";
                scalar = scalar * Isotopes[indexDC].DecayConst / NuclideDensity.Arr[index,0];
                //cout << "scalar = " << NuclideDensity.arr[index][0] << "\n";
            }
            return scalar;
        }
        public double SensitivityAnaliticalAfterTime(string name, string nameCS, double years, int mesh = 100)
        {
            double concen = Constants.NaturalLeadDensity * Constants.N_Avogadro / 208.0;
            int index = -1;
            int indexCS = -1;
            double scalar = 0;
            double dT = years * 365 / mesh;
            for (int i = 0; i < NuclNum; i++) if (name == Isotopes[i].Name) index = i;
            for (int i = 0; i < NuclNum; i++) if (nameCS == Isotopes[i].Name) indexCS = i;

            Matrix Temp = new Matrix(10,10);
            Temp.Zero();
            if (index == -1) Console.Write("\nERROR: '" + name + "' name of nuclide does not exist, put correct name!\n\n");
            else
            if (indexCS == -1) Console.Write("\nERROR: '" + nameCS + "' name of nuclide does not exist, put correct name!\n\n");
            else
            {
                ResetAllToInitialState(NeutronfluxLevel);
                double cs = Isotopes[indexCS].CS_ng_avg;
                double d_cs = Isotopes[indexCS].CS_ng_avg * 0.01;
                Isotopes[indexCS].CS_ng_avg = Isotopes[indexCS].CS_ng_avg + d_cs;
                ResetAllToInitialState(NeutronfluxLevel);
                NumberDensityChangeAfterDays(365 * years);
                double density = NuclideDensity.Arr[index,0];

                Isotopes[indexCS].CS_ng_avg = cs;
                ResetAllToInitialState(NeutronfluxLevel);
                NumberDensityChangeAfterDays(365 * years);
                double sens = 0.0;
                if (d_cs == 0.0) sens = 0.0;
                else
                    sens = (density - NuclideDensity.Arr[index,0]) / d_cs;

                sens = sens * Isotopes[indexCS].CS_ng_avg / NuclideDensity.Arr[index, 0];

                return sens;
            }
            return 0.0;
        }

        //public void DensityTimeMeshAndWriteToFile(double meshDay, int numMesh, string FileName)
        //{
        //    ReadWriteFile rw(FileName);

        //    double sec = meshDay * OneDaySec;

        //    rw.file << 0 << "\t" << HeatDensity() << "\t" << AnaliticalCalcOfHeatDensity() << "\t";

        //    for (int j = 0; j < NuclNum; j++)
        //        rw.file << NuclideDensity.arr[j][0] << "\t";
        //    rw.file << "\n";

        //    NumberDensityChangeAfterDays(meshDay);

        //    for (int i = 1; i < numMesh; i++)
        //    {
        //        rw.file << i << "\t" << HeatDensity() << "\t" << AnaliticalCalcOfHeatDensity() << "\t";
        //        //cout << " Heat density = " << HeatDensity() << "\n";
        //        for (int j = 0; j < NuclNum; j++)
        //        {
        //            rw.file << NuclideDensity.arr[j][0] << "\t";
        //        }
        //        rw.file << "\n";
        //        NuclideDensity = exp * NuclideDensity;
        //        for (int i = 0; i < NuclNum; i++)
        //            if (NuclideDensity.arr[i][0] < 1.0E-40) NuclideDensity.arr[i][0] = 0.0;
        //    }

        //    rw.closeFile();
        //}
        //public void DensityChangeTimeLogScaleAndWriteToFile(double YearIrradiation, char* FileName);
        public void NumberDensityChangeAfterDays(double days)
        {
            Exp.Col = A.Col;
            Exp.Row = A.Row;
            double sec = days * Constants.OneDaySec;
            Exp = A * sec;
            //A.ShowMatrix();
            double maxValue = 0.0;
            int counter = 0;
            do
            {
                Exp = Exp / 2.0;
                maxValue = Exp.MaxValueAbs();
                Console.WriteLine(" Max = " + maxValue);// << "\n";
                counter++;

            } while (maxValue >= 0.5);
            //cout << " Max = " << exp.MaxValueAbs() << "\n";
            //Exp.ShowMatrix();
            Console.WriteLine(" Starting ExpPade ...");// << "\n";

            Exp = Exp.ExpPade(6, 6);
            Console.WriteLine(" Finished ExpPade");// << "\n";

            for (int i = 0; i < counter; i++)
            {
                Exp = Exp.PowerF(2);
                Console.WriteLine(" PowerF = " + i);// << "\n";
            }

            Console.WriteLine("Exp = ");
            Exp.ShowMatrix();

            NuclideDensity = Exp * NuclideDensity;
            //Exp.ShowMatrix();

            //NuclideDensity.Norm();
        }
        public void ShowDensity()
        {
            Console.Write("\nDensities of " + NuclNum + " nuclides after irradiation:" + Environment.NewLine);
            for (int i = 0; i < NuclNum; i++)
            {
               if(NuclideDensity.Arr[i, 0] != 0.0) Console.Write(Isotopes[i].Name + "\t--->\t" + NuclideDensity.Arr[i, 0] +Environment.NewLine);
            }
        }
        public static string ShowDensity(BurnUp burnUp)
        {
            var str = "";
            str += "Densities of " + burnUp.NuclNum + " nuclides after irradiation:"+ Environment.NewLine;
            for (int i = 0; i < burnUp.NuclNum; i++)
            {
                if (burnUp.NuclideDensity.Arr[i, 0] != 0.0) str+=burnUp.Isotopes[i].Name + "->" + burnUp.NuclideDensity.Arr[i, 0] + Environment.NewLine;
            }
            return str;
        }
        public double HeatDensity()
        {
            double heat_density = 0.0;
            double concen = Constants.NaturalLeadDensity * Constants.N_Avogadro / 208.0;
            double n_gammaEnergy = 0.0;
            for (int i = 0; i < NuclNum; i++)
            {
                n_gammaEnergy = Constants.MassOfNeutron + (Isotopes[i].AtomicMass - Isotopes[i].AtomicMass) * Constants.aem;
                //cout << "n_gammaEnergy = " << NeutronfluxLevel << "\n";
                HeatDensityOfEachNuclide[i] = (Isotopes[i].DecayEnergy * Isotopes[i].DecayConst + n_gammaEnergy * NeutronfluxLevel * Isotopes[i].CS_ng_avg) * concen * NuclideDensity.Arr[i,0] * Constants.q_electron * 1E6;
                heat_density += HeatDensityOfEachNuclide[i];
            }
            //heat_density = heat_density * q_electron * 1E6;
            //cout << "heat_density = " << heat_density << "\n";
            return heat_density;
        }
        public void WriteToFileHeatDensityOfEeachNuclide(string filename)
        {

        }
        public double AnaliticalCalcOfHeatDensity()
        {
            double concen = Constants.NaturalLeadDensity * Constants.N_Avogadro / 208.0;
            double MacroCS = 0.0;
            for (int i = 0; i < NuclNum; i++)
                MacroCS += NuclideDensity.Arr[i, 0] * Isotopes[i].CS_ng_avg * concen;

            double Energy = (Constants.MassOfNeutron * 4 - Constants.MassOfHe4) * Constants.q_electron * 1e6 * MacroCS * NeutronfluxLevel / 4;
            return Energy;
        }
        //public double ReadOneGroupCrossSectionsFromFile(int indexOfNuclide);
        //public void ReadOneGroupFluxLevelFromFile(int fluxIndex);
        #endregion
    }
}
