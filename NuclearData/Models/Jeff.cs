using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuclearData.Models
{
    public class Jeff : Endf
    {
        public Jeff()
        {
            LibFolder = "Jeff/";
            Extension = ".jeff33";
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
                var str = files[i].Split('-');
                int z = Convert.ToInt32(str[0]);
                if (str[2].Contains("m")) continue;
                int a = Convert.ToInt32(str[2].Replace("g", ""));
                elements.Add(new Element(z, a));
            }
            return elements;
        }

        protected override string GetIsotopeFile(int Z, int A, Constants.FILETYP ftype)
        {
            var name = Z + "-" + Constants.ElementNames[Z] + "-" + A + "g";
            string filePath = $"{Globals.RootDir}{LibFolder}{Globals.FileTypeDir[ftype]}/{name}{Extension}";
            return filePath;
        }
    }
}
