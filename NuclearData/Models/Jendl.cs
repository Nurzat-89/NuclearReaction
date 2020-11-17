using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuclearData.Models
{
    public class Jendl : Endf
    {
        public Jendl()
        {
            LibFolder = "JENDL/";
            Extension = ".dat";
            InitializeIsotopes();
        }
        protected override List<Element> GetAllElements(Constants.FILETYP fileType)
        {
            var elements = new List<Element>();
            var dir = Globals.FileTypeName[fileType];
            var files = GetFileNames(fileType);
            for (int i = 0; i < files.Length; i++)
            {
                var name = files[i].Replace(dir, "").Replace(Extension, "");
                if (name[name.Length - 1] == 'm' || name[name.Length - 2] == 'm') continue;
                var a = name.Substring(name.Length - 3, 3);
                var _a = Convert.ToInt32(a);
                name = name.Replace(a, "");
                var z = Constants.ElementNames.ToList().IndexOf(name);
                elements.Add(new Element(z, _a));
            }
            return elements;
        }

        protected override string GetIsotopeFile(int Z, int A, Constants.FILETYP ftype)
        {
            var a = A.ToString("D3");
            var name = $"{Constants.ElementNames[Z]}{a}";
            string filePath = $"{Globals.RootDir}{LibFolder}{Globals.FileTypeDir[ftype]}/{name}{Extension}";
            return filePath;
        }
    }
}
