using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuclearData.Models
{
    public class EndfB : Endf
    {
        public EndfB()
        {
            LibFolder = "ENDFB-VIII/";
            Extension = ".endf";
            InitializeIsotopes();
        }

        protected override List<Element> GetAllElements(Constants.FILETYP fileType)
        {
            var elements = new List<Element>();
            var dir = Globals.FileTypeName[fileType];
            var files = GetFileNames(fileType);
            for (int i = 0; i < files.Length; i++)
            {
                files[i] = files[i].Replace(dir, "");
                files[i] = files[i].Replace(Extension, "");
                var str = files[i].Split('_');
                int z = Convert.ToInt32(str[0]);
                if (str[2].Contains("m")) continue;
                int a = Convert.ToInt32(str[2]);
                elements.Add(new Element(z, a));
            }
            return elements;
        }

        protected override string GetIsotopeFile(int Z, int A, Constants.FILETYP ftype)
        {
            string sz = Z.ToString("D3");
            string sa = A.ToString("D3");
            var name = sz + "_" + Constants.ElementNames[Z] + "_" + sa;
            string filePath = $"{Globals.RootDir}{LibFolder}{Globals.FileTypeDir[ftype]}/{Globals.FileTypeName[ftype]}{name}{Extension}";
            return filePath;
        }        
    }
}
