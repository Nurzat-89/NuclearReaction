using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuclearData.Models
{
    public abstract class Endf
    {
        public List<Isotope> Isotopes { get; set; }
        protected string LibFolder { get; set; }
        protected string Extension { get; set; }
        public List<NuclearDataReader> NuclearData { get; set; }
        public Endf()
        {
            NuclearData = new List<NuclearDataReader>();
            Isotopes = new List<Isotope>();
            NuclearData.Add(new DecayDataReader());
            NuclearData.Add(new NeutronDataReader());
        }

        protected void InitializeIsotopes() 
        {
            var elements = GetAllElements(Constants.FILETYP.DECAY);
            foreach (var element in elements)
            {
                var isotope = new Isotope(element.Z, element.A);
                foreach (var data in NuclearData)
                {
                    var fn = GetIsotopeFile(element.Z, element.A, data.ReactionType);
                    isotope = data.Read(isotope, element.Z, element.A, fn);
                }
                Isotopes.Add(isotope);
            }
        }
        public void SetNuclearData()
        {
            for (int i = 0; i < Isotopes.Count; i++)
            {
                foreach (var data in NuclearData)
                {
                    var fn = GetIsotopeFile(Isotopes[i].Z, Isotopes[i].A, data.ReactionType);
                    Isotopes[i] = data.Read(Isotopes[i], Isotopes[i].Z, Isotopes[i].A, fn);
                }
            }
        }
        public string[] GetFileNames(Constants.FILETYP ftype)
        {
            string rtyp = Globals.FileTypeDir[ftype];
            string[] filePaths = Directory.GetFiles($"{Globals.RootDir}{LibFolder}{rtyp}", $"*{Extension}", SearchOption.TopDirectoryOnly);
            for (int i = 0; i < filePaths.Length; i++)
            {
                filePaths[i] = Path.GetFileName(filePaths[i]);
            }
            return filePaths;
        }
        protected abstract string GetIsotopeFile(int Z, int A, Constants.FILETYP ftype);
        protected abstract List<Element> GetAllElements(Constants.FILETYP fileType);
    }
}
