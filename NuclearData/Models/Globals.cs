using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NuclearData.Constants;

namespace NuclearData.Models
{
    public static class Globals
    {
        public static string MyDocuments => Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public static string RootDir => $"{MyDocuments}/xsdir/";
        public static Dictionary<FILETYP, string> FileTypeDir = new Dictionary<FILETYP, string>() { 
               { FILETYP.DECAY, "decay/" }, 
               { FILETYP.NEUTRON, "neutron/" }, 
               { FILETYP.FISSION, "nfy/" },
        };
        public static Dictionary<FILETYP, string> FileTypeName = new Dictionary<FILETYP, string>() {
               { FILETYP.DECAY, "dec-" },
               { FILETYP.NEUTRON, "n-" },
               { FILETYP.FISSION, "nfy-" },
        };
        public static string GetIsotopeFile(int Z, int A, FILETYP ftype)
        {
            string rtyp = FileTypeDir[ftype] + FileTypeName[ftype];
            string sz = Z.ToString("D3");
            string sa = A.ToString("D3");
            string filePath = rtyp + sz + "_" + ElementNames[Z] + "_" + sa + ".endf";
            return RootDir + filePath;
        }

        public static string GetIsotopeFile(int zaid, FILETYP ftype)
        {
            string rtyp = FileTypeDir[ftype] + FileTypeName[ftype];
            int z = zaid / 1000;
            int a = zaid - z * 1000;

            string sz = z.ToString("D3");
            string sa = a.ToString("D3");
            string filePath = rtyp + sz + "_" + ElementNames[z] + "_" + sa + ".endf";
            return RootDir + filePath;
        }

        public static string GetIsotopeFile(string name, int A, FILETYP ftype)
        {
            string rtyp = FileTypeDir[ftype] + FileTypeName[ftype];
            var z = ElementNames.ToList().IndexOf(name);
            if (z == -1) return string.Empty;

            string sz = z.ToString("D3");
            string sa = A.ToString("D3");
            string filePath = rtyp + sz + "_" + ElementNames[z] + "_" + sa + ".endf";
            return RootDir + filePath;
        }
        public static string[] GetFileNames(FILETYP ftype) 
        {
            string rtyp = FileTypeDir[ftype];
            string[] filePaths = Directory.GetFiles($"{RootDir}{rtyp}", "*.endf", SearchOption.TopDirectoryOnly);
            for (int i = 0; i < filePaths.Length; i++)
            {
                filePaths[i] = Path.GetFileName(filePaths[i]);                    
            }
            return filePaths;
        }

        public static List<Element> GetAllElements(FILETYP fileType) 
        {
            var elements = new List<Element>();
            var dir = FileTypeName[fileType];
            var files = GetFileNames(fileType);
            for (int i = 0; i < files.Length; i++)
            {
                files[i] = files[i].Replace(dir, "");
                files[i] = files[i].Replace(".endf", "");
                var str = files[i].Split('_');
                int z = Convert.ToInt32(str[0]);
                if (str[2].Contains("m")) continue;
                int a = Convert.ToInt32(str[2]);
                elements.Add(new Element(z, a));
            }
            return elements; 
        }
    }
}
